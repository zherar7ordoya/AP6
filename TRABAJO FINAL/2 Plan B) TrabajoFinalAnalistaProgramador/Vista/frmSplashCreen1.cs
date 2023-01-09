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
    public partial class frmSplashCreen1 : Form
    {
        public frmSplashCreen1()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Aumentamos la barra.
                progressBar1.Increment(2);
                lbl_Porcentaje.Text = progressBar1.Value.ToString() + " %";
                //Si llega a 100, paro el timer.
                if (progressBar1.Value == 100)
                {
                    timer1.Stop();
                    this.Hide();
                    frmPrincipal frmPrincipal = new frmPrincipal();
                    frmPrincipal.Show();
                }
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
