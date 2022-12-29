using FullCarMultimarca.BLL.Seguridad;
using FullCarMultimarca.UI.Base;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormModificarClave : FormEditorBase<string>
    {
          
        public FormModificarClave(string usrLogon) : base(usrLogon)
        {
            InitializeComponent();
        }
        

        protected override void IniciarFormulario()
        {        
            txtUsuario.Text = _elemento;
        }

        protected override void GuardarCambios()
        {

            string claveActual = txtClaveActual.Text;
            string claveNueva = txtNuevaClave.Text;
            string repClave = txtClaveRep.Text;

            BLLUsuario.ObtenerInstancia().ModificarClave(_elemento, claveActual, claveNueva, repClave);

            MostrarMensaje.Informacion("Clave modificada exitosamente");

            base.GuardarCambios();            


        }

     
    }
}
