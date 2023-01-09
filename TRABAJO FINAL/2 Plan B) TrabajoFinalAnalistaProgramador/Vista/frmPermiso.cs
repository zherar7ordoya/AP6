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
    public partial class frmPermisos : Form
    {
        public frmPermisos()
        {
            InitializeComponent();
            Controlador_Vista.VistaPermiso _vc = new Controlador_Vista.VistaPermiso(this);
        }
    }
}
