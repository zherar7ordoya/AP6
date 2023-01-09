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
    public partial class frmHistorialBackUp : Form
    {

        public frmHistorialBackUp()
        {
            InitializeComponent();
            Controlador_Vista.VistaHistorialBackUp _vc = new Controlador_Vista.VistaHistorialBackUp(this);
        }
    }
}
