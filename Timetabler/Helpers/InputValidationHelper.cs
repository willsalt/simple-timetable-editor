using System.Windows.Forms;

namespace Timetabler.Helpers
{
    internal static class InputValidationHelper
    {
        internal static void ValidateTextInputAsNonNegativeInt(TextBox tb, ErrorProvider errorProvider, string errorMessage)
        {
            if (!int.TryParse(tb.Text, out int dummy) || dummy < 0)
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
