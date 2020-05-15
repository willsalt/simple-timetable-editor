using PdfSharp.Drawing;
using Unicorn.CoreTypes;

namespace Unicorn.Impl.PdfSharp.Extensions
{
    /// <summary>
    /// Extensions class for the <see cref="UniDashStyle" /> enumeration.
    /// </summary>
    public static class UniDashStyleExtensions
    {
        /// <summary>
        /// Convert a <see cref="UniDashStyle" /> value to a <see cref="XDashStyle" /> value.
        /// </summary>
        /// <param name="style">The value to convert.</param>
        /// <returns>The equivalent <see cref="XDashStyle" /> value.</returns>
        public static XDashStyle ToXDashStyle(this UniDashStyle style)
        {
            // At present System.Drawing.Drawing2D.DashStyle, PdfSharp.Drawing.XDashStyle and Unicorn.Interfaces.UniDashStyle all use compatible numerical values.
            return (XDashStyle)style;
        }
    }
}
