using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmReporteProveedores : Form
    {
        public frmReporteProveedores()
        {
            InitializeComponent();
            Controlador_Vista.VistaReporteProveedores _vc = new Controlador_Vista.VistaReporteProveedores(this);
        }
    }
}
