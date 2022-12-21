using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
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
using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BLL.Parametros;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormParametros : FormEditorBase<FlagsSeguridad>
    {
        public FormParametros(FlagsSeguridad parametros) : base(parametros)
        {
            InitializeComponent();
        }

        protected override void IniciarFormulario()
        {
            txtMinCaracteresClave.Text = _elemento.MinimoCaracteresPassword.ToString();
            txtIntentosBloqueoClave.Text = _elemento.IntentosBloqueoPassword.ToString();
            txtDiasVigenciaClave.Text = _elemento.DiasVigenciaPassword.ToString();
            ckDebeContenerNumero.Checked = _elemento.DebeContenerNumero;
            ckDebeContenerMayuscula.Checked = _elemento.DebeContenerMayuscula;
            ckDebeContenerMinuscula.Checked = _elemento.DebeContenerMinuscula;
            ckDebeContenerCaracterEspecial.Checked = _elemento.DebeContenerCaracterEspecial;                    
        }
        protected override void GuardarCambios()
        {
            int valor;
            Int32.TryParse(txtMinCaracteresClave.Text, out valor);
            _elemento.MinimoCaracteresPassword = valor;
            Int32.TryParse(txtIntentosBloqueoClave.Text, out valor);
            _elemento.IntentosBloqueoPassword = valor;
            Int32.TryParse(txtDiasVigenciaClave.Text, out valor);
            _elemento.DiasVigenciaPassword = valor;
            _elemento.DebeContenerNumero = ckDebeContenerNumero.Checked;
            _elemento.DebeContenerMayuscula = ckDebeContenerMayuscula.Checked;
            _elemento.DebeContenerMinuscula = ckDebeContenerMinuscula.Checked;
            _elemento.DebeContenerCaracterEspecial = ckDebeContenerCaracterEspecial.Checked;

            BLLFlagsSeguridad.ObtenerInstancia().Guardar(_elemento);

            MostrarMensaje.Informacion("Parámetros actualizados.");
        }

     
    }
}
