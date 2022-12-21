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
    public partial class frmSplashCreen2 : Form
    {
        public frmSplashCreen2()
        {
            InitializeComponent();
            this.Visible = false;
            timer1.Enabled = true;
        }

        private void frmSplashCreen2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Aumentamos la barra.
                progressBar1.Increment(2);
                //Si llega a 100, paro el timer.
                if (progressBar1.Value == 100)
                {
                    timer1.Stop();
                    this.Hide();
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
           
        }
    }
}
