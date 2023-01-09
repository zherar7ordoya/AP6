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
    public class VistaTipoArticulo_Ubicacion
    {
        System.Windows.Forms.Form frmTipoArticulo_Ubicacion;
        E_Articulo oArticulo;
        BLL_Articulo oBLLArticulo;
        List<Control> ListaControles;
        EdicionDGV oEdicionDgv;

        public VistaTipoArticulo_Ubicacion(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada referencia al formulario que llega al parámetro del constructor
                frmTipoArticulo_Ubicacion = pForm;
                //Recorro form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmTipoArticulo_Ubicacion.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_VerificarTipoUbicacion").Puntero).Click += btn_VerificarTipoUbicacion_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                frmTipoArticulo_Ubicacion.Load += frmTipoArticulo_Ubicacion_Load;

                oEdicionDgv = new EdicionDGV();
                oArticulo = new E_Articulo();
                oBLLArticulo = new BLL_Articulo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmTipoArticulo_Ubicacion_Load(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;

            try
            {
                oEdicionDgv.EditarDGV(_dgv);
                ActualizarGrilla();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        //Boton verificar tipo y ubicacion.
        private void btn_VerificarTipoUbicacion_Click(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;

            try
            {
                //Obtengo el articulo seleccionado de la grilla.
                oArticulo = (E_Articulo)_dgv.CurrentRow.DataBoundItem;
                //Condicionales para determinar el mensaje que se va a mostrar de acuerdo al calculo realizado por el sistema.
                //Si el porcentaje de valorizacion obtenido es mayor o igual a 0.00 y menor o igual 0.75, 
                //es un articulo de tipo A.
                if (oBLLArticulo.ObtenerTipoArticulo(oArticulo) >= Convert.ToDecimal(0.00) && oBLLArticulo.ObtenerTipoArticulo(oArticulo) <= Convert.ToDecimal(0.75))
                {
                    MessageBox.Show("Articulo tipo: A \n" +
                        "Ubicacion: Estanteria Nro: 1 \n\n" +
                        "Nota: En caso de no poder almacenar el articulo en dicha estanteria, aclarar en las observaciones del articulo la ubicacion del mismo.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Si el porcentaje de valorizacion obtenido es mayor a 0.75, y menor o igual a 0.95,
                //es un articulo tipo B.
                else if (oBLLArticulo.ObtenerTipoArticulo(oArticulo) > Convert.ToDecimal(0.75) && oBLLArticulo.ObtenerTipoArticulo(oArticulo) <= Convert.ToDecimal(0.95))
                {
                    MessageBox.Show("Articulo tipo: B \n" +
                        "Ubicacion: Estanteria Nro: 2 \n\n" +
                        "Nota: En caso de no poder almacenar el articulo en dicha estanteria, aclarar en las observaciones del articulo la ubicacion del mismo.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Si el porcentaje de valorizacion obtenido es mayor a 0.95 y menor o igual a 1.00,
                //es un articulo tipo C.
                else if (oBLLArticulo.ObtenerTipoArticulo(oArticulo) > Convert.ToDecimal(0.95) && oBLLArticulo.ObtenerTipoArticulo(oArticulo) <= Convert.ToDecimal(1.0001))
                {
                    MessageBox.Show("Articulo tipo: C \n" +
                        "Ubicacion: Estanteria Nro: 3/4 \n\n" +
                        "Nota: En caso de no poder almacenar el articulo en dicha estanteria, aclarar en las observaciones del articulo la ubicacion del mismo.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Evento KeyUp del txt busqueda.
        private void txt_Busqueda_KeyUp(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
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

        #endregion

        private void ActualizarGrilla()
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Articulos").Puntero;
            try
            {
                _dgv.DataSource = null;
                _dgv.DataSource = oBLLArticulo.ListarOrdenadoPrecioCosto();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private List<E_Articulo>Consultar(string pDescripcion)
        {
            try
            {
                return oBLLArticulo.Consultar(pDescripcion);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
