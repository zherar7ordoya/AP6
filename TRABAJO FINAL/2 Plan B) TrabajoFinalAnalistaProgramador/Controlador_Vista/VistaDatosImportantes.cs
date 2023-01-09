using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entidad;

namespace Controlador_Vista
{
    public class VistaDatosImportantes
    {
        System.Windows.Forms.Form frmDatosImportantes;
        List<Control> ListaControles;
        BLL_Articulo oBLLArticulo;
        BLL_Proveedor oBLLProveedor;
        BLL_Empleado oBLLPersona;
        BLL_SueldoNeto oBLLSueldoNeto;
        E_Usuario oUsuario;
        BLL_LogIn oBLLLogin;
        BLL_Usuario oBLLUsuario;

        public VistaDatosImportantes(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmDatosImportantes = pForm;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmDatosImportantes.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                frmDatosImportantes.Load += frmDatosImportantes_Load;

                oBLLArticulo = new BLL_Articulo();
                oBLLProveedor = new BLL_Proveedor();
                oBLLPersona = new BLL_Empleado();
                oBLLSueldoNeto = new BLL_SueldoNeto();
                oUsuario = new E_Usuario();
                oBLLLogin = new BLL_LogIn();
                oBLLUsuario = new BLL_Usuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmDatosImportantes_Load(object sender, EventArgs e)
        {
            try
            {
                CantidadExistencias();
                ObtenerCantidadArticulos();
                ObtenerValorizacionInventario();
                ObtenerPrecioVentaAlto();
                ObtenerPrecioVentaBajo();
                ObtenerCantidadProveedores();
                ObtenerCantidadEmpleados();
                ObtenerSueldoNetoAlto();
                VerUsuarioLogeado();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        private void CantidadExistencias()
        {
            Label lblCantidadExistencias = (Label)ListaControles.Find(x => x.Nombre == "lbl_CantidadExistencias").Puntero;
            try
            {
                lblCantidadExistencias.Text = oBLLArticulo.CalcularTotalExistencias().ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ObtenerCantidadArticulos()
        {
            Label lblCantidadArticulos = (Label)ListaControles.Find(x => x.Nombre == "lbl_CantidadArticulos").Puntero;

            try
            {
                lblCantidadArticulos.Text = oBLLArticulo.ObtenerCantidadArticulos().ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ObtenerValorizacionInventario()
        {
            Label lblValorizacion = (Label)ListaControles.Find(x => x.Nombre == "lbl_ValorizacionInv").Puntero;

            try
            {
                lblValorizacion.Text = oBLLArticulo.CalcularTotalValorizacionInventario().ToString("N2");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ObtenerPrecioVentaAlto()
        {
            Label lblArtCaro = (Label)ListaControles.Find(x => x.Nombre == "lbl_ArticuloCaro").Puntero;

            try
            {
                lblArtCaro.Text = oBLLArticulo.ObtenerPrecioVentaAlto().ToString("N2");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ObtenerPrecioVentaBajo()
        {
            Label lblArtBarato = (Label)ListaControles.Find(x => x.Nombre == "lbl_ArticuloBarato").Puntero;

            try
            {
                lblArtBarato.Text = oBLLArticulo.ObtenerPrecioVentaBajo().ToString("N2");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ObtenerCantidadProveedores()
        {
            Label lblCantidadProv = (Label)ListaControles.Find(x => x.Nombre == "lbl_CantidadProveedores").Puntero;

            try
            {
                lblCantidadProv.Text = oBLLProveedor.ObtenerCantidadProveedores().ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ObtenerCantidadEmpleados()
        {
            Label lblCantidadEmpl = (Label)ListaControles.Find(x => x.Nombre == "lbl_CantidadEmpleados").Puntero;

            try
            {
                lblCantidadEmpl.Text = oBLLPersona.ObtenerCantidadEmpleados().ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void ObtenerSueldoNetoAlto()
        {
            Label lblSueldoAlto = (Label)ListaControles.Find(x => x.Nombre == "lbl_MejorSueldo").Puntero;

            try
            {
                lblSueldoAlto.Text = oBLLSueldoNeto.ObtenerSueldoNetoAlto().ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerUsuarioLogeado()
        {
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;

            try
            {
                //Muestro en el label el usuario logeado.
                //Obtengo el id del usuario logeado.
                oUsuario.idUsuario = int.Parse(oBLLLogin.ObtenerUsuarioLogeado());
                //Obtengo el nombre del usuario.
                oBLLUsuario.ObtenerNombreUsuario(oUsuario);
                lblUsuario.Text = oUsuario.Nombre;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
    }
}
