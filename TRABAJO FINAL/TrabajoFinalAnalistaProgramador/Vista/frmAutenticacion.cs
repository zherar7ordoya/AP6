using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using Entidad;

namespace Vista
{
    public partial class frmAutenticacion : Form
    {
        frmPrincipal frmPrincipal;
        public frmAutenticacion()
        {
            frmPrincipal = new frmPrincipal();
            InitializeComponent();
            Controlador_Vista.VistaAutenticacion _vc = new Controlador_Vista.VistaAutenticacion(this, frmPrincipal);
        }

        private void frmAutenticacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmSplashCreen1 frmSplashCreen = new frmSplashCreen1();
                frmSplashCreen.Visible = true;
                frmSplashCreen.Show();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
