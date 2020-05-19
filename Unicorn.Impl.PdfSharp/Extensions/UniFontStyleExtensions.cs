using PdfSharp.Drawing;
using Unicorn.CoreTypes;

namespace Unicorn.Impl.PdfSharp.Extensions
{
    /// <summary>
    /// Extension class for converting between <see cref="UniFontStyles" /> and <see cref="XFontStyle" />.
    /// </summary>
    public static class UniFontStyleExtensions
    {
        /// <summary>
        /// Convert a <see cref="UniFontStyles" /> value to an <see cref="XFontStyle" /> value.
        /// </summary>
        /// <param name="style">The value to be converted.</param>
        /// <returns>The result.</returns>
        public static XFontStyle ToXFontStyle(this UniFontStyles style)
        {
            return (XFontStyle)style;
        }
    }
}
