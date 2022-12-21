using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace Vista
{
    public partial class frmReporteArticulos : Form
    {
        public frmReporteArticulos()
        {
            InitializeComponent();
            Controlador_Vista.VistaReporteArticulos _vc = new Controlador_Vista.VistaReporteArticulos(this);
        }
    }
}
