using Unicorn.CoreTypes;

namespace Unicorn.FontTools.OpenType.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="OS2StyleFlags" /> type.
    /// </summary>
    public static class OS2StyleFlagsExtensions
    {
        /// <summary>
        /// Convert a <see cref="OS2StyleFlags" /> value to a <see cref="FontDescriptorFlags" /> value.
        /// </summary>
        /// <param name="flags">The flags value to convert.</param>
        /// <param name="isSymbolic">Whether or not this font is a symbolic font.  This is not specified by the <see cref="OS2StyleFlags" /> type but must be 
        /// specified in order for a <see cref="FontDescriptorFlags" /> value to be valid.</param>
        /// <param name="isMonospaced">Whether or not this font is monospaced.  THis is not specified by the <see cref="OS2StyleFlags" /> type.</param>
        /// <returns>A <see cref="FontDescriptorFlags" /> value constructed from the parameters.</returns>
        public static FontDescriptorFlags ToFontDescriptorFlags(this OS2StyleFlags flags, bool isSymbolic, bool isMonospaced)
        {
            FontDescriptorFlags output = isSymbolic ? FontDescriptorFlags.Symbolic : FontDescriptorFlags.Nonsymbolic;
            if (isMonospaced)
            {
                output |= FontDescriptorFlags.FixedPitch;
            }
            if (flags.HasFlag(OS2StyleFlags.Italic) || flags.HasFlag(OS2StyleFlags.Oblique))
            {
                output |= FontDescriptorFlags.Italic;
            }
            return output;
        }
    }
}
