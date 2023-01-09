using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using System.Windows.Forms;

namespace Controlador_Vista
{
    public class VistaDefinirConsumoPromedio
    {
        System.Windows.Forms.Form frmConsumoPromedio;
        List<Control> ListaControles;
        BLL_Movimiento oBLLMovimiento;

        public VistaDefinirConsumoPromedio(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor.
                frmConsumoPromedio = pForm;
                //Recorro frm en busca de controles.
                foreach (System.Windows.Forms.Control c in frmConsumoPromedio.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_Buscar").Puntero).Click += btn_Buscar_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Cancelar").Puntero).Click += btn_Cancelar_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Calcular").Puntero).Click += btn_Calcular_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Salir").Puntero).Click += btn_Salir_Click;

                frmConsumoPromedio.Load += frmConsumoPromedio_Load;

                oBLLMovimiento = new BLL_Movimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmConsumoPromedio_Load(object sender, EventArgs e)
        {
            Label lbl_FechaFinal = (Label)ListaControles.Find(x => x.Nombre == "lbl_FechaFinal").Puntero;

            try
            {
                lbl_FechaFinal.Text = DateTime.Now.Date.ToShortDateString();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Buscar.
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            TextBox txtDias = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DiasHabiles").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CantidadArticulos").Puntero;
            DateTimePicker dtFechaInicial = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaInicial").Puntero;
            Label lbl_FechaFinal = (Label)ListaControles.Find(x => x.Nombre == "lbl_FechaFinal").Puntero;
            Label lblCodigo = (Label)ListaControles.Find(x => x.Nombre == "lbl_CodigoArticulo").Puntero;

            try
            {
                #region Validaciones
                if(dtFechaInicial.Value >= DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha inicial debe ser menor a la fecha actual!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                //Asigno al txt, la cantidad de dias habiles obtenidos.
                txtDias.Text = oBLLMovimiento.ObtenerDiasPeriodo(DateTime.Parse(lbl_FechaFinal.Text), DateTime.Parse(dtFechaInicial.Value.ToString())).ToString();
                //Asigno al txt, la cantidad de articulos egresados en el periodo establecido.
                txtCantidad.Text = oBLLMovimiento.ObtenerCantArticulosEgresados(lblCodigo.Text, DateTime.Parse(lbl_FechaFinal.Text), dtFechaInicial.Value).ToString();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Calcular.
        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            TextBox txtConsumo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Consumo").Puntero;
            TextBox txtDias = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DiasHabiles").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CantidadArticulos").Puntero;

            try
            {
                #region Validaciones
                //Valido que no quede en blanco el txt de dias habiles.
                if (string.IsNullOrWhiteSpace(txtDias.Text))
                {
                    MessageBox.Show("Debe ingresar la cantidad de días hábiles!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtDias.Focus();
                    return;
                }
                //Valido que no quede en blanco el txt de cantidad de articulos.
                if (string.IsNullOrWhiteSpace(txtDias.Text))
                {
                    MessageBox.Show("Debe ingresar la cantidad de artículos!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtDias.Focus();
                    return;
                }
                #endregion
                //Asigno al txt, el calculo del consumo promedio diario del articulo.
                txtConsumo.Text = oBLLMovimiento.ObtenerConsumoPromedio(int.Parse(txtCantidad.Text), int.Parse(txtDias.Text)).ToString("N4");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Salir.
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsumoPromedio.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Cancelar.
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            DateTimePicker dtFechaInicial = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaInicial").Puntero;

            try
            {
                dtFechaInicial.Value = DateTime.Now.Date;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion

        private void DesactivarComponentes()
        {
            TextBox txtDias = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DiasHabiles").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CantidadArticulos").Puntero;

            try
            {
                txtDias.Enabled = false;
                txtCantidad.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
