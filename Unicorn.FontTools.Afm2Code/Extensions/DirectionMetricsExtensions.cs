using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Code.Extensions
{
    internal static class DirectionMetricsExtensions
    {
        internal static string ToCode(this DirectionMetrics dm)
        {
            return $" new Unicorn.FontTools.Afm.DirectionMetrics({dm.UnderlinePosition.ToCode()}, {dm.UnderlineThickness.ToCode()}, {dm.ItalicAngle.ToCode()}," + 
                $" {dm.CharWidth.ToCode()}, {dm.IsFixedPitch.ToCode()})";
        }
    }
}
