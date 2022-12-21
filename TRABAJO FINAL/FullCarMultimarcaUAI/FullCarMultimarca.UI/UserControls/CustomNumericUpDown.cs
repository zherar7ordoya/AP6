using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.UserControls
{
    public class CustomNumericUpDown : NumericUpDown
    {

        public CustomNumericUpDown()
        {
            //Minimum = 0;
            //Maximum = 20;
            //Increment = 0.5m;
            //DecimalPlaces = 2;
            KeyPress += CustomNumericUpDown_KeyPress;
            Enter += CustomNumericUpDown_Enter;
        }

        private void CustomNumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = ((System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }
        private void CustomNumericUpDown_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { SetMaskedTextBoxSelectAll((NumericUpDown)sender); });
        }

        private void SetMaskedTextBoxSelectAll(NumericUpDown txtbox)
        {
            txtbox.Select(0,txtbox.Text.Length);
        }
    }
}
