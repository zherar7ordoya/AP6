using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using System.Windows.Forms;
using ServiciosDGV;

namespace Controlador_Vista
{
    public class VistaHistorialBackUp
    {
        System.Windows.Forms.Form frmHistorialBackUp;
        E_BackUp oBackUp;
        BLL_BackUp oBLLBackUp;
        List<Control> ListaControles;
        EdicionDGV oEdicionDgv;

        public VistaHistorialBackUp(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmHistorialBackUp = pForm;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmHistorialBackUp.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                frmHistorialBackUp.Load += frmHistorialBackUp_Load;

                oBackUp = new E_BackUp();
                oBLLBackUp = new BLL_BackUp();
                oEdicionDgv = new EdicionDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmHistorialBackUp_Load(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_HistorialBackUp").Puntero;
            try
            {
                oEdicionDgv.EditarDGV(dgv);
                ActualizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Evento KeyUp del txt de busqueda.
        private void txt_Busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_HistorialBackUp").Puntero;
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
                    dgv.DataSource = oBLLBackUp.Consultar(pFecha);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_HistorialBackUp").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLBackUp.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
