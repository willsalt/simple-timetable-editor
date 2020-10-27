using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Timetabler.Helpers
{
    internal class UIHelpers
    {
        internal static Color ComputeButtonForeColour(Color backColour)
        {
            int sumVals = backColour.R + backColour.G + backColour.B;
            if (sumVals > 128 * 3)
            {
                return Color.Black;
            }
            return Color.White;
        }

        /// <summary>
        /// Validate whether or not a value in a text box can be parsed as an integer number.
        /// </summary>
        /// <param name="tb">The <see cref="TextBox" /> to check.</param>
        /// <param name="ep">The <see cref="ErrorProvider" /> to use to display error messages, if validation fails.</param>
        /// <param name="errorMsg">The error message to display if validation fails.</param>
        /// <param name="e">The event to cancel if validation fails.</param>
        internal static void ValidateIntegerTextBox(TextBox tb, ErrorProvider ep, string errorMsg, CancelEventArgs e)
        {
            if (tb is null || e is null)
            {
                return;
            }
            if (ep is null)
            {
                throw new ArgumentNullException(nameof(ep));
            }

            if (tb.Text.Length != 0 && !int.TryParse(tb.Text, out _))
            {
                ep.SetError(tb, errorMsg);
                e.Cancel = true;
            }
            else
            {
                ep.SetError(tb, string.Empty);
            }
        }

        internal static  void ColourDialogueHelper(Color existingColour, Action<Color> action, Button btn)
        {
            using (ColorDialog cd = new ColorDialog { AllowFullOpen = true, AnyColor = true, Color = existingColour, FullOpen = true, })
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    action(cd.Color);
                    if (btn != null)
                    {
                        btn.BackColor = cd.Color;
                        btn.ForeColor = ComputeButtonForeColour(cd.Color);
                    }
                }
            }
        }
    }
}
