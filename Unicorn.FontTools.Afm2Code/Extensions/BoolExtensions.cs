namespace Unicorn.FontTools.Afm2Code.Extensions
{
    internal static class BoolExtensions
    {
        internal static string ToCode(this bool b)
        {
            return b ? " true " : " false ";
        }
    }
}
