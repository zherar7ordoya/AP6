
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Gestion;
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
using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.UI.Gestion
{
    public partial class FormColor : FormEditorBase<ColorUnidad>
    {
        public FormColor()
        {
            InitializeComponent();
        }
        public FormColor(ColorUnidad color) : base(color)
        {
            InitializeComponent();
        }

        private string _descripcionAnterior = null;
        private IAbmc<ColorUnidad> _abmc = BLLColorUnidad.ObtenerInstancia();

        protected override void IniciarFormulario()
        {
            if (!_esAlta && _elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");

            if (!_esAlta)
            {               
                txtDescripcion.Text = _elemento.Descripcion;
                ckActiva.Checked = _elemento.Activo;
                _descripcionAnterior = _elemento.Descripcion;
            }
        }
        protected override void GuardarCambios()
        {
            //Actualizamos el objeto

            if (_esAlta)
            {
                _elemento = new ColorUnidad();
            }

            _elemento.Descripcion = txtDescripcion.Text.Trim();
            _elemento.Activo = ckActiva.Checked;

            if (_esAlta)
            {
                _abmc.Agregar(_elemento);
                MostrarMensaje.Informacion("Color agregado exitosamente.");
            }
            else
            {
                _abmc.Modificar(_elemento, _descripcionAnterior);
                MostrarMensaje.Informacion("Color modificado exitosamente");
            }
        }
    }
}
