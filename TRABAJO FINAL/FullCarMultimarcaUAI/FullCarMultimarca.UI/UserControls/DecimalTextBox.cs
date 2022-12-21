using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.UserControls
{
    public class DecimalTextBox : MaskedTextBox
    {
        public DecimalTextBox()

        {
            SelectionStart = 0;
            base.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            base.Enter += currencyMaskedTextBox_Enter;

        }

        public bool TryGetValue(out decimal data)

        {

            return decimal.TryParse(RemovePromptAndLiterals(this.Text), out data);

        }

        public decimal Value

        {

            get

            {

                decimal result = 0;

                TryGetValue(out result);

                return result;

            }

            set

            {

                base.Text = ReplaceLeadingZeros(value.ToString(this.Mask));

            }

        }

        private string RemovePromptAndLiterals(string data)

        {

            return data != null ? data.Replace(" ", "").Replace(this.PromptChar.ToString(), "").Replace("$", "") : "";

        }

        protected override void OnValidated(EventArgs e)

        {

            decimal data = 0;

            if (TryGetValue(out data) == true)

            {

                base.Text = ReplaceLeadingZeros(data.ToString(this.Mask));

            }



            base.OnValidated(e);

        }

        protected override void OnTextChanged(EventArgs e)

        {

            base.OnTextChanged(e);

        }

        public override string Text

        {

            get

            {

                return base.Text;

            }

            set

            {

                decimal data = 0;

                if (decimal.TryParse(RemovePromptAndLiterals(value), out data) == true)

                {

                    base.Text = ReplaceLeadingZeros(data.ToString(this.Mask));

                }

                else

                {

                    base.Text = value;

                }

            }

        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)

        {

            if (e.KeyChar == '.')

            {

                decimal data = 0;

                if (TryGetValue(out data) == true)

                {

                    string mask = this.Mask.Replace(".00", ".##").Replace(".99", ".##");

                    base.Text = ReplaceLeadingZeros(data.ToString(mask));

                }

            }

            base.OnKeyPress(e);

        }

        protected string ReplaceLeadingZeros(string data)

        {

            char[] chars = data.ToCharArray();

            for (int i = 0; i < chars.Length; i++)

            {

                if (chars[i] != '$' && chars[i] != ' ')

                {

                    if (chars[i] == '0')

                        chars[i] = this.PromptChar;

                    else

                        break;

                }

            }

            return new string(chars);

        }

        private void currencyMaskedTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { SetMaskedTextBoxSelectAll((MaskedTextBox)sender); });
        }

        private void SetMaskedTextBoxSelectAll(MaskedTextBox txtbox)
        {
            txtbox.SelectAll();
        }

    }
}
