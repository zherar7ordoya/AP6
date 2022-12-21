using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
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
    public partial class FormTipoContacto : FormEditorBase<TipoContacto>
    {
        public FormTipoContacto()
        {
            InitializeComponent();
        }
        public FormTipoContacto(TipoContacto tipoContacto) : base(tipoContacto)
        {
            InitializeComponent();
        }

        private string _descripcionActual = null;
        private IAbmc<TipoContacto> _abmc = BLLTipoContacto.ObtenerInstancia();

        protected override void IniciarFormulario()
        {
            if (!_esAlta && _elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");

            if (!_esAlta)
            {
                txtDescripcion.Text = _elemento.Descripcion;
                ckActivo.Checked = _elemento.Activo;
                txtExpresionRegular.Text = _elemento.ExpresionValidacion;
                txtTextoAyuda.Text = _elemento.TextoAyuda;
                ckPermiteNotificaciones.Checked = _elemento.PermiteNotificaciones;
                _descripcionActual = _elemento.Descripcion;
            }
        }
        protected override void GuardarCambios()
        {
            //Actualizamos el objeto

            if (_esAlta)
            {
                _elemento = new TipoContacto();
            }

            _elemento.Descripcion = txtDescripcion.Text.Trim();
            _elemento.Activo = ckActivo.Checked;
            _elemento.TextoAyuda = txtTextoAyuda.Text;
            _elemento.ExpresionValidacion = txtExpresionRegular.Text.Trim();
            _elemento.PermiteNotificaciones = ckPermiteNotificaciones.Checked;

            if (_esAlta)
            {
                _abmc.Agregar(_elemento);
                MostrarMensaje.Informacion("Tipo Contacto agregado exitosamente.");
            }
            else
            {
                _abmc.Modificar(_elemento, _descripcionActual);
                MostrarMensaje.Informacion("Tipo Contacto modificado exitosamente");
            }
        }
    }
}
