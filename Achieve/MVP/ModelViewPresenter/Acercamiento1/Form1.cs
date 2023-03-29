using Acercamiento1.Presenters;
using Acercamiento1.Views;
using System;
using System.Windows.Forms;

/// <summary>
/// https://youtu.be/UgnbIJYUTQY
/// </summary>

namespace Acercamiento1
{
    public partial class Form1 : Form, IRectangulo
    {
        public Form1() { InitializeComponent(); }

        public string TextoLargo
        {
            get { return TboxLargo.Text; }
            set { TboxLargo.Text = value; }
        }
        public string TextoAncho
        {
            get { return TboxAncho.Text; }
            set { TboxAncho.Text = value; }
        }
        public string TextoArea
        {
            get { return TboxArea.Text; }
            set { TboxArea.Text = value; }
        }

        private void CmdCalcula_Click(object sender, EventArgs e)
        {
            CRectanguloPresenter presentador = new CRectanguloPresenter(this);
            presentador.CalculaArea();
        }
    }
}