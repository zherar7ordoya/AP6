
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.UI.Base;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Excepciones;

namespace FullCarMultimarca.UI.Gestion
{
    public partial class FormFormaPago : FormEditorBase<FormaPago>
    {
        public FormFormaPago()
        {
            InitializeComponent();
        }
        public FormFormaPago(FormaPago fPago) : base(fPago)
        {
            InitializeComponent();
        }

        private string _descripcionAnterior;
        private IAbmc<FormaPago> _abmc = BLLFormaPago.ObtenerInstancia();

        protected override void IniciarFormulario()
        {
            if (!_esAlta && _elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");

            CargarCombos();

            if (!_esAlta)
            {              
                txtDescripcion.Text = _elemento.Descripcion;
                ckActivo.Checked = _elemento.Activa;
                cmbTipoGasto.SelectedItem = _elemento.GetType().Name;
                txtArancelGasto.Value = _elemento is IArancelable arancelable ? arancelable.ArancelGasto : 0;
                _descripcionAnterior = _elemento.Descripcion;
            }            

        }
        protected override void GuardarCambios()
        {
            FormaPago fAux;

            if (((ValoresComboTipoFormaPago)cmbTipoGasto.SelectedItem).Nombre == typeof(FormaPagoCredito).Name)
            {
                fAux = new FormaPagoCredito();

            }
            else if (((ValoresComboTipoFormaPago)cmbTipoGasto.SelectedItem).Nombre == typeof(FormaPagoUsado).Name)
            {
                fAux = new FormaPagoUsado();
            }
            else
                fAux = new FormaPagoContado();


            fAux.Descripcion = txtDescripcion.Text;
            fAux.Activa = ckActivo.Checked;
            if (fAux is IArancelable)
                (fAux as IArancelable).ArancelGasto = txtArancelGasto.Value;             
            

            if (_esAlta)
            {
                _abmc.Agregar(fAux);
                MostrarMensaje.Informacion("Forma de Pago agregada exitosamente.");
            }
            else
            {
                _abmc.Modificar(fAux, _descripcionAnterior);
                MostrarMensaje.Informacion("Forma de Pago modificada exitosamente");
            }
        }

        private void CargarCombos()
        {
            var lista = new List<ValoresComboTipoFormaPago>();            
            lista.Add(new ValoresComboTipoFormaPago { Nombre = typeof(FormaPagoContado).Name, Arancelable = typeof(IArancelable).IsAssignableFrom(typeof(FormaPagoContado)) });
            lista.Add(new ValoresComboTipoFormaPago { Nombre = typeof(FormaPagoCredito).Name, Arancelable = typeof(IArancelable).IsAssignableFrom(typeof(FormaPagoCredito)) });
            lista.Add(new ValoresComboTipoFormaPago { Nombre = typeof(FormaPagoUsado).Name,   Arancelable = typeof(IArancelable).IsAssignableFrom(typeof(FormaPagoUsado)) });           
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbTipoGasto, lista);
            cmbTipoGasto.SelectedIndex = 0;
        }
        private void EstablecerTamañoForm(bool esArancelable)
        {
            if (esArancelable)
            {
                grupoArancel.Visible = true;
                this.Height = 267;
            }
            else
            {
                grupoArancel.Visible = false;
                this.Height = 267 - 54;
            }

        }

        private void cmbTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var valorCmb = cmbTipoGasto.SelectedItem as ValoresComboTipoFormaPago;                
                EstablecerTamañoForm(valorCmb.Arancelable);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }

        private class ValoresComboTipoFormaPago
        {
            public string Nombre { get; set; }
            public bool Arancelable { get; set; }

            public override string ToString()
            {
                return Nombre;
            }

            public override bool Equals(object obj)
            {
                if (obj is null || !(obj is string))
                    return false;

                return this.Nombre.Equals((obj as string));
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
    
}
