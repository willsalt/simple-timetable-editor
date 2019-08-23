using System.Windows.Forms;

namespace Timetabler.Helpers
{
    internal static class InputValidationHelper
    {
        internal static void ValidateTextInputAsNonNegativeInt(TextBox tb, ErrorProvider errorProvider, string errorMessage)
        {
            int dummy;
            if (!int.TryParse(tb.Text, out dummy) || dummy < 0)
            {
                errorProvider.SetError(tb, errorMessage);
            }
            else
            {
                errorProvider.SetError(tb, "");
            }
        }
    }
}
