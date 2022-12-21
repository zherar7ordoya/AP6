using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FullCarMultimarca.UI.UserControls
{
    public partial class InputBoxConRegExp : UserControl
    {
        public InputBoxConRegExp()
        {
            InitializeComponent();
            txtNumerico.Dock = DockStyle.Fill;
        }

        private string _snapshot = "";

        public EventHandler OnTextoModificado;

        public override string Text {
            get {               
                return txtNumerico.Text;
            }
            set {
                txtNumerico.Text = value;
                _snapshot = value;                
            }
        }
        public bool MostrarBotonDeshacer
        {
            set
            {
                if (value)
                {
                    txtNumerico.Dock = DockStyle.Left;
                    btnUndo.Dock = DockStyle.Fill;
                    btnUndo.Visible = true;
                }

            }
        }
        public bool Autovalidar { get; set; } = false;
        public bool RestringirInputANumeros { get; set; } = true;        
        public char[] CaracteresAceptados { get; set; }
        public string RegularValidacion { get; set; } = "";
        public string MensajeErrorValidacion { get; set; } = "El valor ingresado es inválido.";        
        
        public bool CapturarCaracteresEnMayuscula { 
            get { return this.txtNumerico.CharacterCasing == CharacterCasing.Upper; }
            set { if (value) this.txtNumerico.CharacterCasing = CharacterCasing.Upper; }
        }
       

        private void txtNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tecla = (Keys)e.KeyChar;
            if (tecla != Keys.Delete && tecla != Keys.Back)
            {
                if(RestringirInputANumeros)
                {
                    if (!Char.IsNumber(e.KeyChar) && !EsCaracterAceptado(e.KeyChar))
                        e.Handled = true;
                }              
            }            
        }        
        private void btnUndo_Click(object sender, EventArgs e)
        {
            txtNumerico.Text = _snapshot;
        }
        private void InputBoxConRegExp_Validating(object sender, CancelEventArgs e)
        {
            if (Autovalidar && !EsValido())
            {
                MostrarMensaje.Advertencia(MensajeErrorValidacion);
                e.Cancel = true;
            }
        }

        public bool EsValido()
        {
            if (!String.IsNullOrWhiteSpace(txtNumerico.Text))
            {
                if (!String.IsNullOrWhiteSpace(RegularValidacion))
                {
                    if (!Regex.IsMatch(txtNumerico.Text, RegularValidacion))
                    {                        
                        return false;
                    }
                }
            }
            return true;
        }
        private bool EsCaracterAceptado(char c)
        {
            return  CaracteresAceptados != null && CaracteresAceptados.Contains(c);
        }

        private void txtNumerico_TextChanged(object sender, EventArgs e)
        {
            //Notificamos a los suscriptores que requieren notificarse cuando se modifica el texto del user control
            OnTextoModificado?.Invoke(this, new EventArgs());
        }
    }
}
