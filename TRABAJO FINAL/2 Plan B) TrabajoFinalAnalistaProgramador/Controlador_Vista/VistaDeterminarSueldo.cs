using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using BLL;
using ServiciosI;
using ServiciosEncriptacion;
using PermisoComposite;
using System.Text.RegularExpressions;
using ServiciosDGV;
using Microsoft.Reporting.WinForms;

namespace Controlador_Vista
{
    public class VistaDeterminarSueldo
    {
        System.Windows.Forms.Form frmDeterminarSueldo;
        E_Empleado oEmpleado;
        E_Gerente oGerente;
        BLL_Empleado oBLLEmpleado;
        BLL_Gerente oBLLGerente;
        E_SueldoNeto oSueldoNeto;
        BLL_SueldoNeto oBLLSueldoNeto;
        List<Control> ListaControles;
        BLL_Usuario oBLLUsuario;
        E_Usuario oUsuario;
        BLL_LogIn oBLLLogin;
        BLL_Permiso oBLLPermiso;
        EdicionDGV oEdicionDgv;
        //Declaro variables.
        DateTime _fecha; int _empleado; decimal _sueldoBruto; int _cantInasistencia; string _puntualidad; int _horasExtra; int _dniGerente; decimal _importe;
        //Variable utilizada para determinar las distintas acciones. (Alta, Modificacion).
        string Accion;

        public VistaDeterminarSueldo(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privadada referencia al formulario que llega al parámetro del constructor
                frmDeterminarSueldo = pForm;
                //Recorro el dgv en busca de los controles.
                foreach (System.Windows.Forms.Control c in frmDeterminarSueldo.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_NuevoSueldo").Puntero).Click += btn_NuevoSueldo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaSueldo").Puntero).Click += btn_BajaSueldo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarSueldo").Puntero).Click += btn_CancelarSueldo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarSueldo").Puntero).Click += btn_GuardarSueldo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CalcularSueldoNeto").Puntero).Click += btn_CalcularSueldoNeto_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_Regular").Puntero).CheckedChanged += rb_Regular_CheckedChanged;
                ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_Mala").Puntero).CheckedChanged += rb_Mala_CheckedChanged;
                ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_MuyBuena").Puntero).CheckedChanged += rb_MuyBuena_CheckedChanged;
                ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_Excelente").Puntero).CheckedChanged += rb_Excelente_CheckedChanged;
                frmDeterminarSueldo.Load += frmDeterminarSueldo_Load;

                oSueldoNeto = new E_SueldoNeto();
                oBLLSueldoNeto = new BLL_SueldoNeto();
                oEmpleado = new E_Empleado();
                oBLLEmpleado = new BLL_Empleado();
                oBLLGerente = new BLL_Gerente();
                oGerente = new E_Gerente();
                oBLLUsuario = new BLL_Usuario();
                oUsuario = new E_Usuario();
                oBLLLogin = new BLL_LogIn();
                oBLLPermiso = new BLL_Permiso();
                oEdicionDgv = new EdicionDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmDeterminarSueldo_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_SueldosNetos").Puntero;
                oEdicionDgv.EditarDGV(dgv);
                ActualizarGrilla();
                DesactivarComponentes();
                CargarComboEmpleado();
                CargarComboGerente();
                CargarComboSueldoBruto();
                VerificarPermisos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Nuevo sueldo.
        private void btn_NuevoSueldo_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
                Accion = "A";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Guardar sueldo.
        private void btn_GuardarSueldo_Click(object sender, EventArgs e)
        {
            RadioButton rbExcelente = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Excelente").Puntero;
            RadioButton rbMuyBuena = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_MuyBuena").Puntero;
            RadioButton rbRegular = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Regular").Puntero;
            RadioButton rbMala = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Mala").Puntero;

            #region Validaciones
            //Valido que no quede en blanco el txt de precio de costo.
            if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ImporteSueldoNeto").Puntero).Text))
            {
                MessageBox.Show("Debe ingresar el importe de sueldo neto!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ImporteSueldoNeto").Puntero).Focus();
                return;
            }
            //Valido el formato de numero decimal.
            Regex exp = new Regex("^[0-9]*\\,?[0-9]*$");

            if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ImporteSueldoNeto").Puntero).Text))
            {
                MessageBox.Show("Ingreso incorrecto de formato de importe de sueldo neto. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayor a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            try
            {
                //Si la accion es Alta.
                if (Accion == "A")
                {
                    _fecha = ((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaSueldo").Puntero).Value;
                    _empleado = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero).Text);
                    _sueldoBruto = decimal.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_SueldoBruto").Puntero).Text);
                    _cantInasistencia = int.Parse(((NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_CantidadInasistencias").Puntero).Value.ToString());

                    if (rbExcelente.Checked == true)
                    {
                        _puntualidad = ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_Excelente").Puntero).Text;
                    }
                    else if (rbMuyBuena.Checked == true)
                    {
                        _puntualidad = ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_MuyBuena").Puntero).Text;
                    }
                    else if (rbRegular.Checked == true)
                    {
                        _puntualidad = ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_Regular").Puntero).Text;
                    }
                    else
                    {
                        _puntualidad = ((RadioButton)ListaControles.Find(x => x.Nombre == "rb_Mala").Puntero).Text;
                    }

                    _horasExtra = int.Parse(((NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_HorasExtras").Puntero).Value.ToString());
                    _dniGerente = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero).Text);
                    _importe = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ImporteSueldoNeto").Puntero).Text);

                    //Llamo al metodo para dar de alta.
                    Alta(oSueldoNeto);
                }
                
                //Refresco grilla.
                ActualizarGrilla();
                //Limpio txt.
                Limpiar();
                //Aviso.
                MessageBox.Show("El sueldo neto fue almacenado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Desactivo componentes.
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Baja sueldo.
        private void btn_BajaSueldo_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_SueldosNetos").Puntero;

                try
                {
                    //Establezco condicion.
                    if (!string.IsNullOrEmpty(oSueldoNeto.Id.ToString()))
                    {
                        //Me aseguro que haya un sueldo seleccionado.
                        if (dgv.CurrentRow == null)
                        {
                            MessageBox.Show("Debe seleccionar el sueldo a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            return;
                        }
                        //Pregunto si deseo eliminar el sueldo.
                        oSueldoNeto = (E_SueldoNeto)dgv.CurrentRow.DataBoundItem;
                        if (MessageBox.Show("¿Está seguro que desea eliminar el sueldo nro. " + oSueldoNeto.Id.ToString() + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                        ) == DialogResult.Yes)
                        {
                            //Se elimina el sueldo.
                            Baja(oSueldoNeto);
                            //Refresco grilla.
                            ActualizarGrilla();
                        }
                    }
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
                
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Si pulso el rb regular, desactivo el txt importe y lo pongo en 0, ya que se considera insuficiente para premio.
        private void rb_Regular_CheckedChanged(object sender, EventArgs e)
        {
            TextBox txtImportePunt = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImportePuntualidad").Puntero;
            try
            {
                txtImportePunt.Text = Convert.ToInt32(0).ToString();
                txtImportePunt.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
           
        }

        private void rb_MuyBuena_CheckedChanged(object sender, EventArgs e)
        {
            TextBox txtImportePunt = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImportePuntualidad").Puntero;

            txtImportePunt.Enabled = true;
        }

        private void rb_Excelente_CheckedChanged(object sender, EventArgs e)
        {
            TextBox txtImportePunt = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImportePuntualidad").Puntero;
            RadioButton rbRegular = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Regular").Puntero;

            txtImportePunt.Enabled = true;
        }
        //Si pulso el rb mala, desactivo el txt importe y lo pongo en 0, ya que se considera insuficiente para premio.
        private void rb_Mala_CheckedChanged(object sender, EventArgs e)
        {
            TextBox txtImportePunt = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImportePuntualidad").Puntero;
            txtImportePunt.Text = Convert.ToInt32(0).ToString();
            txtImportePunt.Enabled = false;
        }

        //Boton Cancelar.
        private void btn_CancelarSueldo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Evento KeyUp del txt busqueda.
        private void txt_Busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_SueldosNetos").Puntero;
            TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
            string pNombre;
            pNombre = txtBusqueda.Text;

            try
            {
                if (txtBusqueda.Text == string.Empty)
                {
                    ActualizarGrilla();
                }
                else
                {
                    dgv.DataSource = Consultar(pNombre);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_ReporteSueldoNeto_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_SueldosNetos").Puntero;

            
        }

        //Boton Calcular sueldo.
        private void btn_CalcularSueldoNeto_Click(object sender, EventArgs e)
        {
            ComboBox cbSueldoBruto = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_SueldoBruto").Puntero;
            TextBox txtImpInasistencia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImpInasistencia").Puntero;
            TextBox txtImportePunt = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImportePuntualidad").Puntero;
            NumericUpDown nudInasistencias = (NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_CantidadInasistencias").Puntero;
            NumericUpDown nudHorasExtra = (NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_HorasExtras").Puntero;
            Button btnCalcular = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularSueldoNeto").Puntero;
            TextBox txtImporte = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImporteSueldoNeto").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarSueldo").Puntero;
            TextBox txtImpHoraExtra = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImpHoraExtra").Puntero;
            RadioButton rbExcelente = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Excelente").Puntero;
            RadioButton rbMuyBuena = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_MuyBuena").Puntero;
            RadioButton rbRegular = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Regular").Puntero;
            RadioButton rbMala = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Mala").Puntero;

            try
            {
                #region Validaciones
                //Valido que la cantidad de inasistencias sea un numero entero.
                Regex exp2 = new Regex("^[0-9]+$");
                if (!exp2.IsMatch(nudInasistencias.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de cantidad de inasistencias. Debe ser un numero entero", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de importe de inasistencias.
                if (string.IsNullOrWhiteSpace(txtImpInasistencia.Text))
                {
                    MessageBox.Show("Debe ingresar el importe de inasistencias!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtImpInasistencia.Focus();
                    return;
                }
                //Valido que no se pulsen ninguno de los radioButton.
                if (rbExcelente.Checked == false && rbMuyBuena.Checked == false && rbRegular.Checked == false  && rbMala.Checked == false)
                {
                    MessageBox.Show("Debe ingresar un tipo de puntualidad!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido el formato de numero decimal.
                Regex exp = new Regex("^[0-9]*\\,?[0-9]*$");
                if (!exp.IsMatch(txtImpInasistencia.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de importe de inansistencias. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayos a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;

                }
                //Valido que no quede en blanco el txt de importe de puntualidad.
                if (string.IsNullOrWhiteSpace(txtImportePunt.Text))
                {
                    MessageBox.Show("Debe ingresar el importe de puntualidad!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtImportePunt.Focus();
                    return;
                }
                //Valido formato decimal para importe de puntualidad.
                if (!exp.IsMatch(txtImportePunt.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de importe puntualidad. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayos a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido el formato para la cantidad de horas extra.
                if (!exp2.IsMatch(nudHorasExtra.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de cantidad de horas extra. Debe ser un numero entero", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de importe de horas extra.
                if (string.IsNullOrWhiteSpace(txtImpHoraExtra.Text))
                {
                    MessageBox.Show("Debe ingresar el importe de horas extra!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtImpHoraExtra.Focus();
                    return;
                }
                //Valido formato decimal para importe de horas extra.
                if (!exp.IsMatch(txtImpHoraExtra.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de importe horas extra. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayos a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                //Creo una variable para asignarle el resultado del metodo Calcular.
                decimal importe = 0;
                //Asingno a la variable, el resultado del metodo Calcular.
                importe = Calcular(decimal.Parse(cbSueldoBruto.Text), decimal.Parse(txtImpInasistencia.Text), decimal.Parse(txtImportePunt.Text), Convert.ToInt32(nudHorasExtra.Value), decimal.Parse(txtImpHoraExtra.Text));
                //Muestro en el txt el importe calculado.
                txtImporte.Text = importe.ToString();
                //Habilito el boton Guardar.
                btnGuardar.Enabled = true;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
           
        }
        #endregion

        //Metodo Calcular.
        public decimal Calcular(decimal sdoBruto, decimal impInasistencia, decimal impPuntualidad, int horasExtra, decimal impHorasExtra)
        {
            try
            {
                return oBLLSueldoNeto.Calcular(sdoBruto, impInasistencia, impPuntualidad, horasExtra, impHorasExtra);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Actualizar grilla.
        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_SueldosNetos").Puntero;

            try
            {
                dgv.DataSource = null;
                dgv.DataSource = Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Verificar permisos.
        private void VerificarPermisos()
        {
            try
            {
                Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
                Label lblAviso = (Label)ListaControles.Find(x => x.Nombre == "lbl_Aviso").Puntero;
                Button btnNuevo = (Button)ListaControles.Find(x => x.Nombre == "btn_NuevoSueldo").Puntero;
                Button btnBaja = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaSueldo").Puntero;
                Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarSueldo").Puntero;
                Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarSueldo").Puntero;
                Button btnCalcular = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularSueldoNeto").Puntero;
                Button btnReporte = (Button)ListaControles.Find(x => x.Nombre == "btn_ReporteSueldoNeto").Puntero;
                TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_SueldosNetos").Puntero;
                //El tipo true significa que tiene los permisos, en cambio el tipo false no.
                bool tipoUsuario = true;
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnNuevo, btnBaja, btnGuardar, btnCancelar, btnCalcular, btnReporte };
                List<DataGridView> listaDgv = new List<DataGridView>() { dgv };
                List<TextBox> listaTxt = new List<TextBox>() { txtBusqueda };
                //Muestro en el label el usuario logeado.
                //Obtengo el id del usuario logeado.
                oUsuario.idUsuario = int.Parse(oBLLLogin.ObtenerUsuarioLogeado());
                //Obtengo el nombre del usuario.
                oBLLUsuario.ObtenerNombreUsuario(oUsuario);
                lblUsuario.Text = oUsuario.Nombre;
                //Verifico el pemriso que tiene ese usuario.
                oBLLUsuario.VerificarTipoUsuario(oUsuario);
                //Asigno a lista perfil, la carga de permiso.
                Perfil = oBLLPermiso.CargarPermisos(oUsuario.oPermiso.Id);

                //Recorro la lista de botones.
                foreach (Button boton in listaBotones)
                {
                    if (Perfil.Exists(x => x.Id == ((Button)boton).Tag.ToString()))
                    {
                        boton.Visible = true;
                        //Pongo variable en true.
                        tipoUsuario = true;
                    }
                    else
                    {
                        boton.Visible = false;
                        //Pongo la variable en false, para mostrar aviso (label).
                        tipoUsuario = false;
                    }

                }
                //Recorro la lista de dgv.
                foreach (DataGridView d in listaDgv)
                {
                    if (Perfil.Exists(x => x.Id == ((DataGridView)d).Tag.ToString()))
                    {
                        d.Visible = true;
                    }
                    else
                    {
                        d.Visible = false;
                    }

                }
                //Recorro la lista de txt.
                foreach (TextBox t in listaTxt)
                {
                    if (Perfil.Exists(x => x.Id == ((TextBox)t).Tag.ToString()))
                    {
                        t.Visible = true;
                    }
                    else
                    {
                        t.Visible = false;
                    }
                }

                if (tipoUsuario == false)
                {
                    lblAviso.Enabled = true;
                    lblAviso.Location = new System.Drawing.Point(70, 250);
                    lblAviso.Text = "No posee permisos para trabajar con esta opción del sistema.";
                }
                else
                {
                    lblAviso.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ActivarComponentes()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdSueldo").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaSueldo").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            ComboBox cbSueldoBruto = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_SueldoBruto").Puntero;
            NumericUpDown nudInasistencia = (NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_CantidadInasistencias").Puntero;
            TextBox txtImpInasistencia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImpInasistencia").Puntero;
            TextBox txtImportePunt = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImportePuntualidad").Puntero;
            RadioButton rbExcelente = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Excelente").Puntero;
            RadioButton rbMuyBuena = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_MuyBuena").Puntero;
            RadioButton rbRegular = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Regular").Puntero;
            RadioButton rbMala = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Mala").Puntero;
            NumericUpDown nudHorasExtra = (NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_HorasExtras").Puntero;
            Button btnCalcular = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularSueldoNeto").Puntero;
            TextBox txtImporte = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImporteSueldoNeto").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarSueldo").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarSueldo").Puntero;
            TextBox txtImpHoraExtra = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImpHoraExtra").Puntero;

            try
            {
                cbGerente.Enabled = true;
                cbSueldoBruto.Enabled = true;
                dtFecha.Enabled = true;
                cbEmpleado.Enabled = true;
                txtImpHoraExtra.Enabled = true;
                nudInasistencia.Enabled = true;
                txtImpInasistencia.Enabled = true;
                txtImporte.Enabled = true;
                txtImportePunt.Enabled = true;
                rbExcelente.Enabled = true;
                rbMuyBuena.Enabled = true;
                rbRegular.Enabled = true;
                rbMala.Enabled = true;
                nudHorasExtra.Enabled = true;
                btnCalcular.Enabled = true;
                btnCancelar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DesactivarComponentes()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdSueldo").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaSueldo").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            ComboBox cbSueldoBruto = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_SueldoBruto").Puntero;
            NumericUpDown nudInasistencia = (NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_CantidadInasistencias").Puntero;
            TextBox txtImpInasistencia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImpInasistencia").Puntero;
            TextBox txtImpHoraExtra = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImpHoraExtra").Puntero;
            TextBox txtImportePunt = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImportePuntualidad").Puntero;
            RadioButton rbExcelente = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Excelente").Puntero;
            RadioButton rbMuyBuena = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_MuyBuena").Puntero;
            RadioButton rbRegular = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Regular").Puntero;
            RadioButton rbMala = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Mala").Puntero;
            NumericUpDown nudHorasExtra = (NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_HorasExtras").Puntero;
            Button btnCalcular = (Button)ListaControles.Find(x => x.Nombre == "btn_CalcularSueldoNeto").Puntero;
            TextBox txtImporte = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImporteSueldoNeto").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarSueldo").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarSueldo").Puntero;

            try
            {
                txtId.Enabled = false;
                cbGerente.Enabled = false;
                cbSueldoBruto.Enabled = false;
                txtImpHoraExtra.Enabled = false;
                dtFecha.Enabled = false;
                cbEmpleado.Enabled = false;
                nudInasistencia.Enabled = false;
                txtImpInasistencia.Enabled = false;
                txtImporte.Enabled = false;
                txtImportePunt.Enabled = false;
                rbExcelente.Enabled = false;
                rbMuyBuena.Enabled = false;
                rbRegular.Enabled = false;
                rbMala.Enabled = false;
                nudHorasExtra.Enabled = false;
                btnCalcular.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Limpiar()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdSueldo").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaSueldo").Puntero;
            NumericUpDown nudInasistencia = (NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_CantidadInasistencias").Puntero;
            TextBox txtImpInasistencia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImpInasistencia").Puntero;
            TextBox txtImportePunt = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImportePuntualidad").Puntero;
            RadioButton rbExcelente = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Excelente").Puntero;
            RadioButton rbMuyBuena = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_MuyBuena").Puntero;
            RadioButton rbRegular = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Regular").Puntero;
            RadioButton rbMala = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Mala").Puntero;
            NumericUpDown nudHorasExtra = (NumericUpDown)ListaControles.Find(x => x.Nombre == "nud_HorasExtras").Puntero;
            TextBox txtImporte = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ImporteSueldoNeto").Puntero;

            try
            {
                txtId.Text = string.Empty;
                dtFecha.Value = DateTime.Now;
                nudInasistencia.Value = 0;
                txtImpInasistencia.Text = string.Empty; ;
                txtImporte.Text = string.Empty;
                txtImportePunt.Text = string.Empty;
                rbExcelente.Checked = false;
                rbMuyBuena.Checked = false;
                rbRegular.Checked = false;
                rbMala.Checked = false;
                nudHorasExtra.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboGerente()
        {
            try
            {
                ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbGerente.DataSource = oBLLGerente.Listar();
                //Establezco el valor real.
                cbGerente.ValueMember = "Dni";
                //Establezco el valor que muestro.
                cbGerente.DisplayMember = "Dni";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboEmpleado()
        {
            try
            {
                ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbEmpleado.DataSource = oBLLEmpleado.Listar();
                //Establezco el valor real.
                cbEmpleado.ValueMember = "Dni";
                //Establezco el valor que muestro.
                cbEmpleado.DisplayMember = "Dni";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboSueldoBruto()
        {
            try
            {
                ComboBox cbSueldoBruto = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_SueldoBruto").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbSueldoBruto.DataSource = oBLLEmpleado.Listar();
                //Establezco el valor que muestro.
                cbSueldoBruto.DisplayMember = "sueldoBruto";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        public void Alta(E_SueldoNeto oSueldoNeto)
        {
            try
            {
                oSueldoNeto.Fecha = _fecha;
                oSueldoNeto.oEmpleado.Dni = _empleado;
                oSueldoNeto.sueldoBruto = _sueldoBruto;
                oSueldoNeto.cantidadInasistencia = _cantInasistencia;
                oSueldoNeto.Puntualidad = _puntualidad;
                oSueldoNeto.horasExtra = _horasExtra;
                oSueldoNeto.oGerente.Dni = _dniGerente;
                oSueldoNeto.Importe = _importe;

                oBLLSueldoNeto.Alta(oSueldoNeto);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_SueldoNeto oSueldoNeto)
        {
            try
            {
                oBLLSueldoNeto.Baja(oSueldoNeto);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_SueldoNeto> Consultar(string pFecha)
        {
            try
            {
                return oBLLSueldoNeto.Consultar(pFecha);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_SueldoNeto> Listar()
        {
            try
            {
                return oBLLSueldoNeto.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
