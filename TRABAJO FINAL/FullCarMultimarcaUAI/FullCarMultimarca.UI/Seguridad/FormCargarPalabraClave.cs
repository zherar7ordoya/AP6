using FullCarMultimarca.BLL.Seguridad;
using FullCarMultimarca.UI.Base;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormCargarPalabraClave : FormEditorBase<string>
    {
        public FormCargarPalabraClave(string logon) : base(logon)
        {
            
            InitializeComponent();
        }
        public FormCargarPalabraClave(string logon, string textoBotonCancelar) : base(logon)
        {
            _textoBotonCancelar = textoBotonCancelar;
            InitializeComponent();
        }

        private string _textoBotonCancelar;

        protected override void IniciarFormulario()
        {
            txtUsuario.Text = _elemento;
            if (!string.IsNullOrWhiteSpace(_textoBotonCancelar))
                btnCancelar.Text = _textoBotonCancelar;

        }
        protected override void GuardarCambios()
        {            
            string clave = txtClaveActual.Text;
            string palabraClave = txtPalabraClave.Text;
            string respuestaClave = txtRespuestaClave.Text;

            BLLUsuario.ObtenerInstancia().ModificarPalabraClave(_elemento, clave, palabraClave, respuestaClave);
            base.GuardarCambios();
        }
    }
}
