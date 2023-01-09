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
    public partial class frmBackUp : Form
    {
        frmHistorialBackUp frmHistorialBackUp;

        public frmBackUp()
        {
            frmHistorialBackUp = new frmHistorialBackUp();
            InitializeComponent();
            Controlador_Vista.VistaBackUp _vc = new Controlador_Vista.VistaBackUp(this, frmHistorialBackUp);
        }

    }
}
