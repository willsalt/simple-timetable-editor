using PdfSharp.Drawing;
using System;
using System.Text;
using Unicorn.Impl.PdfSharp.Extensions;
using Unicorn.CoreTypes;
using System.Collections;
using System.Collections.Generic;

namespace Unicorn.Impl.PdfSharp
{
    /// <summary>
    /// Data describing a font.
    /// </summary>
    public class FontDescriptor : IFontDescriptor
    {
        /// <summary>
        /// The name of the font face.
        /// </summary>
        public string BaseFontName => Font?.Name;

        /// <summary>
        /// A unique identifier for the font face.
        /// </summary>
        public string UnderlyingKey => $"PdfSharp_{BaseFontName}";

        /// <summary>
        /// Preferred text encoding when using this font.  Not used with this implementation.
        /// </summary>
        public Encoding PreferredEncoding => Encoding.Unicode;

        /// <summary>
        /// Bounding box that encloses all glyphs in this font, in normalised "glyph units" such that 1,000 glyph units equals the point size of the font.
        /// </summary>
        public UniRectangle BoundingBox => new UniRectangle();

        /// <summary>
        /// Angle that uprights in this font are off the vertical.
        /// </summary>
        public decimal ItalicAngle => 0m;

        /// <summary>
        /// Height of capital characters above the baseline, in normalised "glyph units" such that 1,000 glyph units equals the point size of the font.
        /// </summary>
        public decimal CapHeight => 0m;

        /// <summary>
        /// Typical vertical stem thickness of characters in this font.
        /// </summary>
        public decimal VerticalStemThickness => 0m;

        /// <summary>
        /// Ascent of characters above the baseline, in normalised "glyph units" sich that 1,000 glyph units equals the point size of the font.
        /// </summary>
        public double AscentGlyphUnits => Font.Metrics.Ascent;

        /// <summary>
        /// Descent of characters below the baseline, in normalised "glyph units" sich that 1,000 glyph units equals the point size of the font.
        /// </summary>
        public double DescentGlyphUnits => Font.Metrics.Descent;

        /// <summary>
        /// Font style flags.
        /// </summary>
        public FontDescriptorFlags Flags => FontDescriptorFlags.Nonsymbolic;

        public bool RequiresFullDescription => false;

        public bool RequiresEmbedding => false;

        public string EmbeddingKey => "";

        public long EmbeddingLength => 0;

        public IEnumerable<byte> EmbeddingData => Array.Empty<byte>();

        /// <summary>
        /// Construct a <see cref="FontDescriptor" /> for a font with a given family name, style and point size.
        /// </summary>
        /// <param name="name">The font family name</param>
        /// <param name="style">The font style</param>
        /// <param name="size">The font size in em-units</param>
        public FontDescriptor(string name, UniFontStyles style, double size)
        {
            PointSize = size;
            Font = new XFont(name, size, style.ToXFontStyle());
            if (Font != null)
            {
                Ascent = (Font.Metrics.Ascent / (Font.Metrics.Ascent + (double)Font.Metrics.Descent)) * Font.Height;
                Descent = -(Font.Metrics.Descent / (Font.Metrics.Ascent + (double)Font.Metrics.Descent)) * Font.Height;
            }
        }

        /// <summary>
        /// Construct a <see cref="FontDescriptor" /> for a regular roman-face font with a given family name and point size.
        /// </summary>
        /// <param name="name">The font family name</param>
        /// <param name="size">The font size in em-units</param>
        public FontDescriptor(string name, double size) : this(name, UniFontStyles.Regular, size)
        {

        }

        /// <summary>
        /// The underlying font.
        /// </summary>
        public XFont Font { get; }

        /// <summary>
        /// The point size of this font.
        /// </summary>
        public double PointSize { get; }

        /// <summary>
        /// The ascent value of this font - the distance from the baseline to the top of character cells.
        /// </summary>
        public double Ascent { get; }

        /// <summary>
        /// The descent value of this font - the distance from the baseline to the bottom of character cells.
        /// </summary>
        public double Descent { get; }

        /// <summary>
        /// Standard interline white space in this font.
        /// </summary>
        public double InterlineSpacing => 0d; // FIXME

        /// <summary>
        /// The size of an empty string rendered in this font.  This is expected to be a zero-width <see cref="UniTextSize" /> value with its vertical metrics
        /// properties populated.
        /// </summary>
        public UniTextSize EmptyStringMetrics => new UniTextSize(0d, Ascent + InterlineSpacing - Descent, Ascent + InterlineSpacing / 2, Ascent, -Descent);

        /// <summary>
        /// Returns the width of a single space character in this font, with the given context.
        /// </summary>
        /// <param name="graphicsContext"></param>
        /// <returns></returns>
        public double GetNormalSpaceWidth(IGraphicsContext graphicsContext)
        {
            if (graphicsContext is null)
            {
                throw new ArgumentNullException(nameof(graphicsContext));
            }
            return graphicsContext.MeasureString(Resources.SpaceCharacter, this).Width;
        }

        /// <summary>
        /// Measure the size of a string.  This action is not supported in this implementation.
        /// </summary>
        /// <param name="str">The string to be measured.</param>
        /// <exception cref="NotImplementedException">Always thrown.</exception>
        public UniTextSize MeasureString(string str)
        {
            throw new NotImplementedException();
        }
    }
}
