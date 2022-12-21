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
    public partial class frmDatosImportates : Form
    {
        public frmDatosImportates()
        {
            InitializeComponent();
            Controlador_Vista.VistaDatosImportantes _vc = new Controlador_Vista.VistaDatosImportantes(this);
        }
    }
}
