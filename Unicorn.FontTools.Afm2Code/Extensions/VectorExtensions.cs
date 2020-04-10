using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Code.Extensions
{
    internal static class VectorExtensions
    {
        internal static string ToCode(this Vector v)
        {
            return $" new Unicorn.FontTools.Afm.Vector({v.X.ToCode()}, {v.Y.ToCode()})";
        }
    }
}
