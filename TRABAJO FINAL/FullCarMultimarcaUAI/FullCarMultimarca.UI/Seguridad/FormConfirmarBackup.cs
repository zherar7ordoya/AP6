
using FullCarMultimarca.BLL.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.UI.Base;
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
