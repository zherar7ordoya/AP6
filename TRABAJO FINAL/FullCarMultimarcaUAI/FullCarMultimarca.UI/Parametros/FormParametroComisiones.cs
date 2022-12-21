using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BLL.Parametros;
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

namespace FullCarMultimarca.UI.Parametros
{
    public partial class FormParametroComisiones : FormEditorBase<FlagsComisiones>
    {
        public FormParametroComisiones(FlagsComisiones parametros) : base(parametros)
        {
            InitializeComponent();
        }

        protected override void IniciarFormulario()
        {

            txtPorComisN1.Value = _elemento.PorcentajeComisionN1;
            txtPorComisN2.Value = _elemento.PorcentajeComisionN2;
            txtPorComisN3.Value = _elemento.PorcentajeComisionN3;
            txtCantMinN2.Value = _elemento.CantidadMinimaN2;
            txtCantMinN3.Value = _elemento.CantidadMinimaN3;
            txtImpPremioVolumen.Value = _elemento.ImportePremioVolumen;


        }
        protected override void GuardarCambios()
        {

            _elemento.PorcentajeComisionN1 = txtPorComisN1.Value;
            _elemento.PorcentajeComisionN2 = txtPorComisN2.Value;
            _elemento.PorcentajeComisionN3 = txtPorComisN3.Value;
            _elemento.CantidadMinimaN2 = (int)txtCantMinN2.Value;
            _elemento.CantidadMinimaN3 = (int)txtCantMinN3.Value;
            _elemento.ImportePremioVolumen = txtImpPremioVolumen.Value;
         

            BLLFlagsComisiones.ObtenerInstancia().Guardar(_elemento);

            MostrarMensaje.Informacion("Parámetros de comisiones actualizados.");
        }     
    }
}
