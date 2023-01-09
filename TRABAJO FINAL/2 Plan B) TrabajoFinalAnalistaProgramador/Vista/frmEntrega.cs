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
    public partial class frmEntrega : Form
    {
        frmReporteEntregas frmReporteEntregas;

        public frmEntrega()
        {
            frmReporteEntregas = new frmReporteEntregas();
            InitializeComponent();
            Controlador_Vista.VistaEntrega _vc = new Controlador_Vista.VistaEntrega(this, frmReporteEntregas);
        }
    }
}
