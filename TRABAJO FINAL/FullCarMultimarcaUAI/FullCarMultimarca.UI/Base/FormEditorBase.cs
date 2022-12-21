using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.Base
{
    public partial class FormEditorBase<T> : Form
    {
        public FormEditorBase()
        {            
            InitializeComponent();
        }
        public FormEditorBase(T aModificar) : this() 
        {
            _esAlta = false;
            _elemento = aModificar;
        }

        protected T _elemento = default;
        protected bool _esAlta = true;
        protected bool _soloLectura = false;
        protected ArrayList _controlesAExcluirProcesamientoSoloLectura = new ArrayList();

        protected virtual bool SoloLectura
        {
            get { return this._soloLectura; }
            set
            {
                this._soloLectura = value;
                this.btnGuardar.Enabled = !value;             
                UtilUI.ObtenerInstancia()
                    .EstablecerControlesSoloLectura(this, value, _controlesAExcluirProcesamientoSoloLectura);
            }
        }      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                GuardarCambios();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void FormABMBase_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;              
                IniciarFormulario();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        protected virtual void GuardarCambios()
        {

        }
        protected virtual void IniciarFormulario()
        {
            
        }
      

      

    }
}
