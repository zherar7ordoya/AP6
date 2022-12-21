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
using FullCarMultimarca.Servicios.Extensiones;
using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.UI.Gestion
{
    public partial class FormModelo : FormEditorBase<Modelo>
    {
        public FormModelo()
        {
            InitializeComponent();
        }
        public FormModelo(Modelo modelo) : base(modelo)
        {
            InitializeComponent();
        }

        private IAbmc<Modelo> _abmc = BLLModelo.ObtenerInstancia<ModeloResto>();
        private IAbmc<Marca> _abmcMarca = BLLMarca.ObtenerInstancia();

        protected override void IniciarFormulario()
        {
            if (!_esAlta && _elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");

            CargarCombos();            

            if (!_esAlta)
            {
                txtCodigo.Text = _elemento.Codigo;
                txtDescripcion.Text = _elemento.Descripcion;
                ckActivo.Checked = _elemento.Activo;
                cmbMarca.SelectedItem = _elemento.Marca;
                cmbTipoModelo.SelectedItem = _elemento.GetType().Name;
                txtPrecioLista.Value = _elemento.PrecioPublico;               

                txtCodigo.ReadOnly = true;
                txtCodigo.TabStop = false;
                cmbTipoModelo.Enabled = false;
                cmbTipoModelo.TabStop = false;
                
            }
        }
        protected override void GuardarCambios()
        {
            //Actualizamos el objeto
            string strPUni = txtPrecioLista.Text.Replace('.', ',');
            if (!txtPrecioLista.TryGetValue(out decimal pPublico))
                throw new NegocioException("No se pudo interpretar el valor del precio de lista.");         

            string codigo = txtCodigo.Text.Trim();            

            if ((string)cmbTipoModelo.SelectedItem == typeof(ModeloPickUp).Name)
            {
                _elemento = new ModeloPickUp(codigo);
                
            }
            else
            {
                _elemento = new ModeloResto(codigo);
            }
            _elemento.Descripcion = txtDescripcion.Text;
            _elemento.Activo = ckActivo.Checked;
            _elemento.Marca = cmbMarca.SelectedItem as Marca;
            _elemento.PrecioPublico = pPublico;            

            if (_esAlta)
            {
                _abmc.Agregar(_elemento);
                MostrarMensaje.Informacion("Modelo agregado exitosamente.");
            }
            else
            {
                _abmc.Modificar(_elemento);
                MostrarMensaje.Informacion("Modelo modificado exitosamente");
            }
        }

        private void CargarCombos()
        {
            List<string> tipos = new List<string> { typeof(ModeloResto).Name, typeof(ModeloPickUp).Name };
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbTipoModelo, tipos);
            cmbTipoModelo.SelectedIndex = 0;            
            var query = from m in _abmcMarca.ObtenerTodos()
                        where m.Activa == true || (_elemento != null && m.Descripcion.EqualsAICI(_elemento.Marca?.Descripcion))
                        orderby m
                        select m;
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbMarca, query.ToList(), true, "<Seleccione...>");
            cmbMarca.SelectedIndex = 0;
        }
     
    }
}
