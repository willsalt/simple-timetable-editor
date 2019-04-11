using System.Drawing.Drawing2D;
using Unicorn.Interfaces;

namespace Timetabler.PdfExport.Extensions
{
    public static class DashStyleExtensions
    {
        public static UniDashStyle ToUniDashStyle(this DashStyle style)
        {
            // At present System.Drawing.Drawing2D.DashStyle, PdfSharp.Drawing.XDashStyle and Unicorn.Interfaces.UniDashStyle all use compatible numerical values.
            return (UniDashStyle)style;
        }
    }
}
