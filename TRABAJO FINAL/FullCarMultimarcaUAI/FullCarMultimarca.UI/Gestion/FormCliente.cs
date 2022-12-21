using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.UI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.Gestion
{
    public partial class FormCliente : FormEditorBase<Cliente>
    {
        public FormCliente()
        {
            InitializeComponent();
        }
        public FormCliente(Cliente cliente) : base(cliente)
        {
            InitializeComponent();
        }

        public EventHandler<CUITClienteEventArgs> OnClienteCreado;

        private string _valorCUITAnterior = null;

        private IAbmc<Cliente> _abmcCliente = BLLCliente.ObtenerInstancia();
        private IAbmc<TipoContacto> _abmcTipoContacto = BLLTipoContacto.ObtenerInstancia();

        protected override void IniciarFormulario()
        {
            if (!_esAlta && _elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");
                        
            ConfigurarControlCUIT();

            CargarCombos();

            if (!_esAlta)
            {
                txtCUIT.Text = _elemento.CUIT;
                txtNombre.Text = _elemento.Nombre;
                txtApellido.Text = _elemento.Apellido;
                txtDireccion.Text = _elemento.Direccion;
                txtLocalidad.Text = _elemento.Localidad;
                txtCodigoPostal.Text = _elemento.CodigoPostal;
                cmbProvincia.SelectedItem = new Provincia { Nombre = _elemento.Provincia };

                _valorCUITAnterior = _elemento.CUIT;
            }
            else
                _elemento = new Cliente();


            ActualizarGrillaContactos();
            ActalizarControlTipoContactoSegunTipo();
        }
        protected override void GuardarCambios()
        {                   

            if (!txtCUIT.EsValido())
            {
                throw new NegocioException(txtCUIT.MensajeErrorValidacion);
            }

            _elemento.CUIT = txtCUIT.Text;
            _elemento.Apellido = txtApellido.Text;
            _elemento.Nombre = txtNombre.Text;
            _elemento.Direccion = txtDireccion.Text;
            _elemento.Localidad = txtLocalidad.Text;
            _elemento.Provincia = (cmbProvincia.SelectedItem as Provincia)?.Nombre;
            _elemento.CodigoPostal = txtCodigoPostal.Text;

            if (_esAlta)
            {
                _abmcCliente.Agregar(_elemento);
                MostrarMensaje.Informacion("Cliente agregado exitosamente.");
                OnClienteCreado?.Invoke(this, new CUITClienteEventArgs(_elemento.CUIT));
            }
            else
            {
                _abmcCliente.Modificar(_elemento, _valorCUITAnterior);
                MostrarMensaje.Informacion("Cliente modificado exitosamente");
            }
        }

        private void ConfigurarControlCUIT()
        {
            //Configurar CUIT            
            txtCUIT.CaracteresAceptados = new char[] { '-' };
            txtCUIT.MensajeErrorValidacion = "El Formato del CUIL/CUIT ingresado es inválido.";
            txtCUIT.RegularValidacion = BLL.Util.PatronValidacionCUIT;
            txtCUIT.MostrarBotonDeshacer = true;  
        }
        private void CargarCombos()
        {          
            
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbProvincia, 
                BLLProvincia.ObtenerInstancia().Obtener(), true,"<Seleccione...>");
            cmbProvincia.SelectedIndex = 0;

            var lstTiposContacto = _abmcTipoContacto
                .ObtenerTodos()
                .Where(tc => tc.Activo)
                .OrderBy(tc => tc.Descripcion);

            if (lstTiposContacto == null || lstTiposContacto.Count() == 0)
                throw new NegocioException("No puede ingresar clientes debido a que no se ha ingresado ningún tipo de contacto.");

            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbTipoContacto, 
               lstTiposContacto);
            cmbTipoContacto.SelectedIndex = 0;
        }    
      
        private void ActalizarControlTipoContactoSegunTipo()
        {
            txtContactoDato.MensajeErrorValidacion = $"Formato inválido.";
            txtContactoDato.RegularValidacion = "";
            toolTip1.SetToolTip(imgInfoTipoContacto, "");
            TipoContacto tipoContacto = (TipoContacto)cmbTipoContacto.SelectedItem;
            if(tipoContacto != null)
            {
                txtContactoDato.MensajeErrorValidacion = $"Formato de {tipoContacto} inválido.\n{tipoContacto.TextoAyuda}";
                txtContactoDato.RegularValidacion = tipoContacto.ExpresionValidacion;
                toolTip1.SetToolTip(imgInfoTipoContacto, tipoContacto.TextoAyuda);
            }               
        }
        private void ActualizarGrillaContactos()
        {
            grillaContactos.DataSource = null;
            if (_elemento.ObtenerContactos().Count > 0)
            {
                grillaContactos.DataSource = _elemento.ObtenerContactos();
            }
            if(grillaContactos.Columns.Count > 0)
                grillaContactos.Columns["Cliente"].Visible = false;
        }      

        private void cmbTipoContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActalizarControlTipoContactoSegunTipo();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtContactoDato.Text))
                    return;
                if (!txtContactoDato.EsValido())
                    throw new NegocioException(txtContactoDato.MensajeErrorValidacion);           
                _elemento.AgregarContacto((TipoContacto)cmbTipoContacto.SelectedItem, txtContactoDato.Text.Trim());
                ActualizarGrillaContactos();
                txtContactoDato.Text = "";

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnEliminarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                var contacto = UtilUI.ObtenerInstancia()
                    .ObtenerObjetoDesdeGrilla<Contacto>(grillaContactos);
                if(contacto != null)
                {
                    _elemento.EliminarContacto(contacto);
                    ActualizarGrillaContactos();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
    

        
    }
}
