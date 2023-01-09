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
    public partial class frmGerentes : Form
    {
        public frmGerentes()
        {
            InitializeComponent();
            Controlador_Vista.VistaGerente _vc = new Controlador_Vista.VistaGerente(this);
        }

        private void dgv_Gerentes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //Ordeno la columna de mail empresarial en la ubicacion 11.
                dgv_Gerentes.Columns["mailEmpresarial"].DisplayIndex = 11;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
