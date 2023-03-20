using Controller;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        readonly ClienteVista ControladorCliente;

        public Form1()
        {
            InitializeComponent();
            ControladorCliente = new ClienteVista(this);
        }


        // TODO => ¿Por qué aquí me pide que agregue referencia a Structure?
        private void Button2_Click(object sender, EventArgs e)
        {
            ControladorCliente.Alta();
        }
    }
}
