using FullCarMultimarca.Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.Impresiones
{
    public partial class FormImprimirFormulario : Form
    {
        public FormImprimirFormulario()
        {
            InitializeComponent();
        }

        private void FormImprimirFormulario_Load(object sender, EventArgs e)
        {
            try
            {
                PrintDocument prtdoc = new PrintDocument();
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;

                foreach (string impresora in PrinterSettings.InstalledPrinters)
                {
                    cmbImpresoras.Items.Add(impresora);
                    if (impresora == strDefaultPrinter)
                    {
                        cmbImpresoras.SelectedIndex = cmbImpresoras.Items.Count - 1;
                    }
                }

                if (cmbImpresoras.Items.Count == 0)
                    throw new NegocioException("No tiene impresoras disponibles");
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.Close();
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

     
    }
}
