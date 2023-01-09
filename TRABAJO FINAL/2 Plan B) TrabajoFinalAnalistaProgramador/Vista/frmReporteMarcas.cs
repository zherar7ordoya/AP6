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
    public partial class frmReporteMarcas : Form
    {
        public frmReporteMarcas()
        {
            InitializeComponent();
            Controlador_Vista.VistaReporteMarcas _vc = new Controlador_Vista.VistaReporteMarcas(this);
        }
    }
}
