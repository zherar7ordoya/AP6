
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
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
