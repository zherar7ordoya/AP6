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
    public partial class frmTipoArticulo_Ubicacion : Form
    {
        public frmTipoArticulo_Ubicacion()
        {
            InitializeComponent();
            Controlador_Vista.VistaTipoArticulo_Ubicacion _vc = new Controlador_Vista.VistaTipoArticulo_Ubicacion(this);
        }

       
    }
}
