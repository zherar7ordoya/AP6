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
    public partial class frmProveedor : Form
    {
        frmReporteProveedores frmReporteProveedores;

        public frmProveedor()
        {
            frmReporteProveedores = new frmReporteProveedores();
            InitializeComponent();
            Controlador_Vista.VistaProveedor _vc = new Controlador_Vista.VistaProveedor(this, frmReporteProveedores);
        }
    }
}
