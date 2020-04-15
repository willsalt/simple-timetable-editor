using System.Globalization;

namespace Unicorn.FontTools.Afm2Code.Extensions
{
    internal static class DecimalExtensions
    {
        internal static string ToCode(this decimal d)
        {
            return " " + d.ToString(CultureInfo.InvariantCulture) + "m ";
        }
    }
}
