using System;
using System.Windows.Forms;
using App.Core;

namespace Calculadora
{
    public partial class CFormulario : Form, IVista
    {
        private readonly CPresentador _Presentador;
        public CFormulario()
        {
            InitializeComponent();
            _Presentador = new CPresentador(this);
        }
        public string TextoPantalla
        {
            get => Pantalla.Text;
            set => Pantalla.Text = value;
        }
        private void BotonNumero_Click(object sender, EventArgs e)
        { _Presentador.PresionaBotonNumero((sender as Button).Text); }
        private void BotonOperacion_Click(object sender, EventArgs e)
        { _Presentador.PresionaBotonOperacion((sender as Button).Text); }
        private void BotonClear_Click(object sender, EventArgs e)
        { _Presentador.PresionaBotonClear(); }
    }
}
