using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controlador_Vista;


namespace Vista
{
    public partial class frmLogin : Form
    {

        frmAutenticacion frmAutenticacion;

        public frmLogin()
        {
            InitializeComponent();
            frmAutenticacion = new frmAutenticacion();
            Controlador_Vista.VistaLogin _vc = new Controlador_Vista.VistaLogin(this, frmAutenticacion);
        }
    }
}
