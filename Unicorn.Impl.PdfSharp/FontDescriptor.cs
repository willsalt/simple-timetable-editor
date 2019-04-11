using PdfSharp.Drawing;
using System;
using Unicorn.Interfaces;

namespace Unicorn.Impl.PdfSharp
{
    /// <summary>
    /// Data describing a font.
    /// </summary>
    public class FontDescriptor : IFontDescriptor
    {
        XFont _font;
        double _ascent;
        double _descent;

        /// <summary>
        /// Construct a <see cref="FontDescriptor"/> for a given <see cref="XFont"/>.
        /// </summary>
        /// <param name="font">The font to create a descriptor for.</param>
        public FontDescriptor(XFont font)
        {
            if (font == null)
            {
                throw new ArgumentNullException("font");
            }
            _font = font;
            _ascent = (_font.Metrics.Ascent / (_font.Metrics.Ascent + (double)_font.Metrics.Descent)) * _font.Height;
            _descent = (_font.Metrics.Descent / (_font.Metrics.Ascent + (double)_font.Metrics.Descent)) * _font.Height;
        }

        /// <summary>
        /// The underlying font.
        /// </summary>
        public XFont Font
        {
            get
            {
                return _font;
            }
        }

        /// <summary>
        /// The ascent value of this font - the distance from the baseline to the top of character cells.
        /// </summary>
        public double Ascent
        {
            get
            {
                return _ascent;
            }
        }

        /// <summary>
        /// The descent value of this font - the distance from the baseline to the bottom of character cells.
        /// </summary>
        public double Descent
        {
            get
            {
                return _descent;
            }
        }

        /// <summary>
        /// Returns the width of a single space character in this font, with the given context.
        /// </summary>
        /// <param name="graphicsContext"></param>
        /// <returns></returns>
        public double GetNormalSpaceWidth(IGraphicsContext graphicsContext)
        {
            return graphicsContext.MeasureString(" ", this).Width;
        }
    }
}
