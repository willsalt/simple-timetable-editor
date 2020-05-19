using System.Drawing.Drawing2D;
using Unicorn.CoreTypes;

namespace Timetabler.PdfExport.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="System.Drawing.Drawing2D.DashStyle" /> enumeration.
    /// </summary>
    public static class DashStyleExtensions
    {
        /// <summary>
        /// Convert a <see cref="DashStyle" /> value to a <see cref="UniDashStyle" /> value.
        /// </summary>
        /// <param name="style">A <see cref="DashStyle" /> value.</param>
        /// <returns>The equivalent <see cref="UniDashStyle" /> value.</returns>
        public static UniDashStyle ToUniDashStyle(this DashStyle style)
        {
            // At present System.Drawing.Drawing2D.DashStyle, PdfSharp.Drawing.XDashStyle and Unicorn.Interfaces.UniDashStyle all use compatible numerical values.
            return (UniDashStyle)style;
        }
    }
}
