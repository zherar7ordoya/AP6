using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;
using Entidad;
using ServiciosDGV;
using ServiciosI;
using PermisoComposite;


namespace Controlador_Vista
{
    public class VistaMovimiento : Iabmc<E_Movimiento>
    {
        System.Windows.Forms.Form frmMovimiento;
        List<Control> ListaControles;
        BLL_Movimiento oBLLMovimiento;
        E_Movimiento oMovimiento;
        BLL_Empleado oBLLEmpleado;
        EdicionDGV oEdicionDgv;
        BLL_Articulo oBLLArticulo;
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;
        BLL_Permiso oBLLPermiso;
        BLL_LogIn oBLLLogin;
        string _articulo; DateTime _fecha; string _accion; int _cantidad; decimal _precioCosto;  decimal _precioVenta; int _empleado;
        string Accion;

        public VistaMovimiento(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privadada referencia al formulario que llega al parámetro del constructor.
                frmMovimiento = pForm;
                //Recorro el form en buscar de controles.
                foreach (System.Windows.Forms.Control c in frmMovimiento.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarMovimiento").Puntero).Click += btn_GuardarMov_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMovimiento").Puntero).Click += btn_CancelarMov_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_AltaMovimiento").Puntero).Click += btn_AltaMov_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModMovimiento").Puntero).Click += btn_ModMov_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaMovimiento").Puntero).Click += btn_BajaMov_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;

                frmMovimiento.Load += frmMovimiento_Load;
                oBLLMovimiento = new BLL_Movimiento();
                oMovimiento = new E_Movimiento();
                oEdicionDgv = new EdicionDGV();
                oBLLEmpleado = new BLL_Empleado();
                oBLLArticulo = new BLL_Articulo();
                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();
                oBLLPermiso = new BLL_Permiso();
                oBLLLogin = new BLL_LogIn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmMovimiento_Load(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Movimientos").Puntero;

            try
            {
                oEdicionDgv.EditarDGV(dgv);
                ActualizarGrilla();
                DesactivarComponentes();
                CargarComboArticulo();
                CargarComboEmpleado();
                VerificarPermisos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_AltaMov_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
                Accion = "A";
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_GuardarMov_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones
                //Valido que la fecha no sea mayor a la fecha actual.
                if (DateTime.Parse(((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero).Value.ToShortDateString()) > DateTime.Now.Date)
                {
                    MessageBox.Show("Ingreso incorrecto de fecha de movimiento. Debe ser igual o menor a la fecha actual.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de movimiento.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar la cantidad en movimiento!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero).Focus();
                    return;
                }
                //Valido el formato de la cantidad.
                Regex exp3 = new Regex("^[0-9]+$");

                if (!exp3.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de cantidad. Deben ser solo numeros.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de precio de costo.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el precio de costo calculado!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero).Focus();
                    return;
                }
                //Valido formato decimal para precio de costo y precio de venta.
                Regex exp5 = new Regex("^[0-9]*\\,?[0-9]*$");

                if (!exp5.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de precio de costo. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayor a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de precio de venta.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el precio de de venta calculado!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero).Focus();
                    return;
                }

                if (!exp5.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de precio de venta. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayor a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                if (Accion == "A")
                {
                    _articulo = ((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Articulo").Puntero).SelectedValue.ToString();
                    _fecha = ((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero).Value;
                    _accion = ((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Accion").Puntero).Text.ToString();
                    _cantidad = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero).Text);
                    _precioCosto = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero).Text);
                    _precioVenta = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero).Text);
                    _empleado = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero).SelectedValue.ToString());

                    Alta(oMovimiento);
                }
                else if(Accion == "M")
                {
                    _articulo = ((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Articulo").Puntero).SelectedValue.ToString();
                    _fecha = ((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero).Value;
                    _accion = ((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Accion").Puntero).Text.ToString();
                    _cantidad = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero).Text);
                    _precioCosto = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero).Text);
                    _precioVenta = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero).Text);
                    _empleado = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero).SelectedValue.ToString());

                    Modificar(oMovimiento);
                }

                ActualizarGrilla();
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ModMov_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Movimientos").Puntero;
            
            try
            {
                TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdMovimiento").Puntero;
                ComboBox cbArticulo = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Articulo").Puntero;
                DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero;
                ComboBox cbAccion = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Accion").Puntero;
                TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
                TextBox txtPCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero;
                TextBox txtPVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero;
                ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;

                //Activo componentes.
                ActivarComponentes();

                //Me aseguro de haya una marca seleccionada.
                if (dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un movimiento a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                //Obtengo la marca.
                oMovimiento = (E_Movimiento)dgv.CurrentRow.DataBoundItem;

                //Paso valores de la grilla a los txt.
                txtId.Text = oMovimiento.Id.ToString();
                cbArticulo.Text = oMovimiento.oArticulo.Codigo;
                dtFecha.Value = oMovimiento.Fecha;
                cbAccion.Text = oMovimiento.Accion;
                txtCantidad.Text = oMovimiento.cantidadMov.ToString();
                txtPCosto.Text = oMovimiento.precioCostoCalculado.ToString();
                txtPVenta.Text = oMovimiento.precioVentaCalculado.ToString();
                cbEmpleado.Text = oMovimiento.oEmpleado.Dni.ToString();

                //Establezco la variable Accion en modo MODIFICAR..
                Accion = "M";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_BajaMov_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Movimientos").Puntero;

                //Establezco condicion.
                if (!string.IsNullOrEmpty(oMovimiento.Id.ToString()))
                {
                    //Me aseguro que haya una marca seleccionada.
                    if (dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar el movimiento a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Pregunto si deseo eliminar la marca.
                    oMovimiento = (E_Movimiento)dgv.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que desea eliminar el movimiento: " + oMovimiento.Id + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        //Se elimina la marca.
                        Baja(oMovimiento);
                        //Refresco grilla.
                        ActualizarGrilla();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_CancelarMov_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Evento KeyUp del txt de busqueda.
        private void txt_Busqueda_KeyUp(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Movimientos").Puntero;
            TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
            string pFecha;
            pFecha = txtBusqueda.Text;

            try
            {
                if (txtBusqueda.Text == string.Empty)
                {
                    ActualizarGrilla();
                }
                else
                {
                    dgv.DataSource = Consultar(pFecha);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion


        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Movimientos").Puntero;

            try
            {
                dgv.DataSource = null;
                dgv.DataSource = Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerificarPermisos()
        {
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
            Button btnAlta = (Button)ListaControles.Find(x => x.Nombre == "btn_AltaMovimiento").Puntero;
            Button btnBaja = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaMovimiento").Puntero;
            Button btnMod = (Button)ListaControles.Find(x => x.Nombre == "btn_ModMovimiento").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarMovimiento").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMovimiento").Puntero;
            Button btnReporte = (Button)ListaControles.Find(x => x.Nombre == "btn_ReporteMovimiento").Puntero;
            TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Movimientos").Puntero;

            try
            {
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnAlta, btnBaja, btnMod, btnGuardar, btnCancelar, btnReporte };
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
                    }
                    else
                    {
                        boton.Visible = false;
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
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesactivarComponentes()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdMovimiento").Puntero;
            ComboBox cbArticulo = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Articulo").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero;
            ComboBox cbAccion = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Accion").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtPCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero;
            TextBox txtPVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarMovimiento").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMovimiento").Puntero;

            try
            {
                txtId.Enabled = false;
                cbArticulo.Enabled = false;
                dtFecha.Enabled = false;
                cbAccion.Enabled = false;
                txtCantidad.Enabled = false;
                txtPCosto.Enabled = false;
                txtPVenta.Enabled = false;
                cbEmpleado.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ActivarComponentes()
        {
            ComboBox cbArticulo = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Articulo").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero;
            ComboBox cbAccion = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Accion").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtPCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero;
            TextBox txtPVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero;
            ComboBox cbEmpleado = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarMovimiento").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMovimiento").Puntero;

            try
            {
                cbArticulo.Enabled = true;
                dtFecha.Enabled = true;
                cbAccion.Enabled = true;
                txtCantidad.Enabled = true;
                txtPCosto.Enabled = true;
                txtPVenta.Enabled = true;
                cbEmpleado.Enabled = true;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void Limpiar()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdMovimiento").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_Fecha").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            TextBox txtPCosto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioCosto").Puntero;
            TextBox txtPVenta = (TextBox)ListaControles.Find(x => x.Nombre == "txt_PrecioVenta").Puntero;

            try
            {
                txtId.Text = string.Empty;
                dtFecha.Value = DateTime.Now;
                txtCantidad.Text = string.Empty;
                txtPCosto.Text = string.Empty;
                txtPVenta.Text = string.Empty;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboArticulo()
        {
            try
            {
                ComboBox cbArticulo = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Articulo").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbArticulo.DataSource = oBLLArticulo.Listar();
                //Establezco el valor real.
                cbArticulo.ValueMember = "Codigo";
                //Establezco el valor que muestro.
                cbArticulo.DisplayMember = "Codigo";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
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
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        public void Alta(E_Movimiento oMovimiento)
        {
            try
            {
                oMovimiento.oArticulo.Codigo = _articulo;
                oMovimiento.Fecha = _fecha;
                oMovimiento.Accion = _accion;
                oMovimiento.cantidadMov = _cantidad;
                oMovimiento.precioCostoCalculado = _precioCosto;
                oMovimiento.precioVentaCalculado = _precioVenta;
                oMovimiento.oEmpleado.Dni = _empleado;

                oBLLMovimiento.Alta(oMovimiento);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Movimiento pObjeto)
        {
            try
            {
                oBLLMovimiento.Baja(oMovimiento);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Movimiento pObjeto)
        {
            try
            {
                oMovimiento.oArticulo.Codigo = _articulo;
                oMovimiento.Fecha = _fecha;
                oMovimiento.Accion = _accion;
                oMovimiento.cantidadMov = _cantidad;
                oMovimiento.precioCostoCalculado = _precioCosto;
                oMovimiento.precioVentaCalculado = _precioVenta;
                oMovimiento.oEmpleado.Dni = _empleado;

                oBLLMovimiento.Modificar(oMovimiento);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Movimiento> Consultar(string pFecha)
        {
            try
            {
                return oBLLMovimiento.Consultar(pFecha);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Movimiento> Listar()
        {
            try
            {
                return oBLLMovimiento.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }

}
