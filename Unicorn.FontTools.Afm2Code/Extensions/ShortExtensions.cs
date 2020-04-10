using System.Globalization;

namespace Unicorn.FontTools.Afm2Code.Extensions
{
    internal static class ShortExtensions
    {
        internal static string ToCode(this short s)
        {
            return $"(short){s.ToString(CultureInfo.InvariantCulture)} ";
        }
    }
}
