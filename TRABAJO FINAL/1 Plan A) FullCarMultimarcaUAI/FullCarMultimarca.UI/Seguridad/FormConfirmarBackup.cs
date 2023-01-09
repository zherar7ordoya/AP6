using System;
using System.Windows.Forms;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BLL;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormConfirmarBackup : Form
    {
        public FormConfirmarBackup()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLCatalogo.ObtenerInstancia().CrearBackup(txtDescripcion.Text);
                this.Close();
            }
            catch (BaseCorruptaException exBC)
            {
                MostrarMensaje.MostrarError(new NegocioException(exBC.Message + "\nNo puede generar un backup en este estado."));                 
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
    }
}
