using System.Globalization;

namespace Unicorn.FontTools.Afm2Code.Extensions
{
    internal static class IntExtensions
    {
        internal static string ToCode(this int i)
        {
            return " " + i.ToString(CultureInfo.InvariantCulture) + " ";
        }
    }
}
