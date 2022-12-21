using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.UI.Impresiones;
using FullCarMultimarca.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.Ventas
{
    public partial class FormEnviarPorMailFormulario : Form
    {
        public FormEnviarPorMailFormulario(VistaImpresionOperacion vistaImpresion, IList<string> destinatarios)
        {
            _vistaOp = vistaImpresion;
            _destinatarios = destinatarios;
            InitializeComponent();
        }

        private IList<string> _destinatarios;
        private VistaImpresionOperacion _vistaOp;

        private void FormEnviarPorMailFormulario_Load(object sender, EventArgs e)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;

                if (_vistaOp == null)
                    throw new NegocioException("No se encontró la vista de operación.");
                if(_destinatarios.Count == 0)
                    throw new NegocioException("El cliente no tiene contactos de e-mail cargados.");

                UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbDestinatarioEmail, _destinatarios);
                if (cmbDestinatarioEmail.Items.Count > 0)
                    cmbDestinatarioEmail.SelectedIndex = 0;

                var usr = Ticket.UsuarioLogueado;
                if (usr != null)
                    txtFrom.Text = $"{usr.Nombre} {usr.Apellido}";

                txtNroOperacion.Text = _vistaOp.NroOperacion;
                txtNombreCliente.Text = _vistaOp.Cliente_Nombre;
                txtBodyMensaje.Text = $"Estimad@,{Environment.NewLine}Se adjunta copia de operación de venta correspondiente a su compra.";


            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEnviarMail_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDestinatarioEmail.SelectedItem == null)
                    throw new NegocioException("Debe seleccionar un destinatario");

                if(String.IsNullOrWhiteSpace(txtBodyMensaje.Text) || txtBodyMensaje.Text.Length < 3)
                    throw new NegocioException("Debe indicar el cuerpo del mensaje (al menos 3 caractéres)");

                //Anexamos el usuario logueado.
                string cuerpo = txtBodyMensaje.Text;
                cuerpo += $"\n{txtFrom.Text}\nFullCar Multimarca";

                this.Cursor = Cursors.WaitCursor;               

                string path = Imprimir.GuardarEnCarpetaTemporal(_vistaOp, $"{_vistaOp.NroOperacion}.pdf");

                BLLOperacion.ObtenerInstancia().EnviarOperacionAlCliente(_vistaOp.NroOperacion, (string)cmbDestinatarioEmail.SelectedItem, cuerpo, path);
                MostrarMensaje.Informacion("Correo enviado correctamente.");

                this.Close();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
