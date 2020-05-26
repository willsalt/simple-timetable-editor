using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Wrapper object for a font, exposing its metadata.
    /// </summary>
    public interface IFontDescriptor
    {
        /// <summary>
        /// The PostScript name of the underlying font.
        /// </summary>
        string BaseFontName { get; }

        /// <summary>
        /// A string that can be used to uniquely determine the underlying font.  Two <see cref="IFontDescriptor" /> instances that refer to the same font at different
        /// point sizes should have the same <see cref="UnderlyingKey" /> value.  Two <see cref="IFontDescriptor" /> instances that refer to different styles of the
        /// same face, even when the style is expected to be created dynamically by the OS, should have different <see cref="UnderlyingKey" /> values.
        /// </summary>
        string UnderlyingKey { get; }

        /// <summary>
        /// Preferred text encoding when using this font.
        /// </summary>
        Encoding PreferredEncoding { get; }

        /// <summary>
        /// The point size of this font.
        /// </summary>
        double PointSize { get; }

        /// <summary>
        /// The ascent of the font above the baseline.
        /// </summary>
        double Ascent { get; }

        double AscentGlyphUnits { get; }

        /// <summary>
        /// The descent of the font below the baseline.
        /// </summary>
        double Descent { get; }

        double DescentGlyphUnits { get; }

        /// <summary>
        /// The amount of white space between the bottom of th descenders of one line and the top of the ascenders of the next, where the leading is zero.  Should
        /// normally be equal to <see cref="PointSize" /><c> - (</c><see cref="Ascent" /><c> - </c><see cref="Descent" /><c>)</c>.  
        /// </summary>
        double InterlineSpacing { get; }

        /// <summary>
        /// The size of an empty string rendered in this font.  This is expected to be a zero-width <see cref="UniTextSize" /> value with its vertical metrics
        /// properties populated.
        /// </summary>
        UniTextSize EmptyStringMetrics { get; }

        UniRectangle BoundingBox { get; }

        decimal ItalicAngle { get; }

        decimal CapHeight { get; }

        decimal VerticalStemThickness { get; }

        FontDescriptorFlags Flags { get; }

        bool RequiresFullDescription { get; }

        bool RequiresEmbedding { get; }

        long EmbeddingLength { get; }

        string EmbeddingKey { get; }

        IEnumerable<byte> EmbeddingData { get; }

        /// <summary>
        /// Measure the size of a string when rendered in this font.
        /// </summary>
        /// <param name="str">The string to be measured.</param>
        /// <returns>A <see cref="UniSize" /> instance containing the size of the string.</returns>
        UniTextSize MeasureString(string str);

        /// <summary>
        /// Return the width of a "normal space" - ASCII 0x20 - in this font, using the given graphics context to render it.
        /// </summary>
        /// <param name="context">The context used to render the font.</param>
        /// <returns>The width of the ASCII space character.</returns>
        double GetNormalSpaceWidth(IGraphicsContext context);
    }
}
