using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.Servicios.Excepciones;
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
    public partial class FormOperacionFormaPago : Form
    {
        public FormOperacionFormaPago(Operacion operacion)
        {
            _operacion = operacion;
            InitializeComponent();
        }
        public FormOperacionFormaPago(OperacionFormaPago opFormaPago) : this(opFormaPago.Operacion)
        {
            _opFormaPago = opFormaPago;
            _esModificacion = true;
        }

        private Operacion _operacion = null;
        private OperacionFormaPago _opFormaPago = null;
        private bool _esModificacion = false;
        private IAbmc<FormaPago> _abmcFormaPago = BLLFormaPago.ObtenerInstancia();

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOperacionFormaPago_Load(object sender, EventArgs e)
        {
            try
            {
                if (_operacion == null)
                    throw new NegocioException("No se indicó la operación para agregar la forma de pago.");
                CargarComboFormasPago();

                if (_esModificacion)
                {
                    cmbFormasPago.SelectedItem = _opFormaPago.FormaPago;
                    txtImporte.Value = _opFormaPago.Importe;
                    cmbFormasPago.Enabled = false;
                    btnGuardar.Text = "Modificar";
                    btnGuardar.Image = Properties.Resources.document_edit;
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.Close();
            }
        }

        private void CargarComboFormasPago()
        {
            IList<FormaPago> lstFPago = _abmcFormaPago.ObtenerTodos();

            lstFPago = lstFPago
                .Where(fp => 
                    ( !_esModificacion && fp.Activa && !_operacion.ObtenerFormasDePago().Any(fop => fop.FormaPago.Equals(fp)))
                    || _esModificacion && fp.Equals(_opFormaPago.FormaPago))
                .ToList();

            if (_esModificacion)
            {
                UtilUI.ObtenerInstancia()
                    .CargarComboDesdeList(cmbFormasPago, lstFPago);            
            }
            else
            {
                UtilUI.ObtenerInstancia()
                    .CargarComboDesdeList(cmbFormasPago, lstFPago, true, "<Seleccione...>");                
            }
            cmbFormasPago.SelectedIndex = 0;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var fPago = cmbFormasPago.SelectedItem as FormaPago;
                if (fPago == null)
                    throw new NegocioException("Debe seleccionar una forma de pago");
                var importe = txtImporte.Value;
                if(importe <= 0)
                    throw new NegocioException("Debe indicar un importe válido mayor a cero");

                if (_esModificacion)
                {
                    _opFormaPago.Importe = importe;                    
                }
                else
                {
                    //_opFormaPago = new OperacionFormaPago(_operacion, fPago)
                    //{                        
                    //    Importe = importe,
                    //    Modificable = true,
                    //    ArancelGasto = (fPago is IArancelable ? (fPago as IArancelable).ArancelGasto : 0)
                    //};
                    _operacion.AgregarFormaDePago(fPago, true, importe, (fPago is IArancelable ? (fPago as IArancelable).ArancelGasto : 0));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }

        private void cmbFormasPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtTipoFPago.Text = "";
                txtArancelGasto.Text = "";
                var fPago = cmbFormasPago.SelectedItem as FormaPago;
                if (fPago != null)
                {
                    txtTipoFPago.Text = fPago.GetType().Name;
                    txtArancelGasto.Text = (fPago is IArancelable
                        ? ((fPago as IArancelable).ArancelGasto/100).ToString("p2")
                        : "");
                 }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
    }
}
