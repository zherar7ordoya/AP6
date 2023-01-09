using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using BLL;

namespace Vista
{
    public partial class frmIngresoEgreso : Form
    {
        public frmIngresoEgreso()
        {
            InitializeComponent();
            Controlador_Vista.VistaIngresoEgreso _vc = new Controlador_Vista.VistaIngresoEgreso(this);
        }

        //Evento Closed del form.
        private void frmIngresoEgreso_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmAdmInventario frmAdmInventario = new frmAdmInventario();
                frmAdmInventario.Show();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
