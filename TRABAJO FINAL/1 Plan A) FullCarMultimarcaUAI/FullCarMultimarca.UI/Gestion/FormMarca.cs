
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.UI.Base;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.UI.Gestion
{
    public partial class FormMarca : FormEditorBase<Marca>
    {
        public FormMarca()
        {
            InitializeComponent();
        }
        public FormMarca(Marca marca) : base(marca)
        {
            InitializeComponent();
        }

        private string _descripcionAnterior = null;
        private IAbmc<Marca> _abmc = BLLMarca.ObtenerInstancia();

        protected override void IniciarFormulario()
        {
            if (!_esAlta && _elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");

            if (!_esAlta)
            {                
                txtDescripcion.Text = _elemento.Descripcion;             
                ckActiva.Checked = _elemento.Activa;
                _descripcionAnterior = _elemento.Descripcion;             
            }
        }
        protected override void GuardarCambios()
        {
            //Actualizamos el objeto

            if (_esAlta)
            {
                _elemento = new Marca();
            }

            _elemento.Descripcion = txtDescripcion.Text.Trim();            
            _elemento.Activa = ckActiva.Checked;

            if (_esAlta)
            {
                _abmc.Agregar(_elemento);
                MostrarMensaje.Informacion("Marca agregada exitosamente.");
            }
            else
            {
                _abmc.Modificar(_elemento, _descripcionAnterior);
                MostrarMensaje.Informacion("Marca modificada exitosamente");
            }
        }

    }
}
