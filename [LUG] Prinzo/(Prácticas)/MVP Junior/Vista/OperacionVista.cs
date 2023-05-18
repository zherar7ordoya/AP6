/*
==========================================================================
Autor:          Gerardo Tordoya
Creación:       2023-05-18
Actualización:  XXXX-XX-XX
Descripción:    [C#] Implementando el patron MVP en .NET
URL:            https://nicolocodev.wordpress.com/2011/08/31/patronmvpnet/
==========================================================================
*/

using Presentador;
using System;
using System.Windows.Forms;

namespace Vista
{

    public partial class OperacionVista : Form, IOperacionVista
    {
        private readonly OperacionPresentador _presentador;

        public OperacionVista()
        {
            InitializeComponent();
            _presentador = new OperacionPresentador(this);
        }

        private void OperacionVista_Load(object sender, EventArgs e)
        {
            _presentador.IniciaVista();
        }

        private void Resultado_Click(object sender, EventArgs e)
        {
            _presentador.ActualizaVista();
        }

        public double Num1
        {
            get { return !string.IsNullOrEmpty(Num1TextBox.Text) ? Convert.ToDouble(Num1TextBox.Text) : 0; }
            set { Num1TextBox.Text = value.ToString(); }
        }

        public double Num2
        {
            get { return !string.IsNullOrEmpty(Num2TextBox.Text) ? Convert.ToDouble(Num2TextBox.Text) : 0; }
            set { Num2TextBox.Text = value.ToString(); }
        }

        public double Resultado
        {
            set { ResultadoLabel.Text = value.ToString(); }
        }
    }

}
