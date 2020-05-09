using System.Text;

namespace Unicorn.Interfaces
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

        /// <summary>
        /// The descent of the font below the baseline.
        /// </summary>
        double Descent { get; }

        /// <summary>
        /// The amount of white space between the bottom of th descenders of one line and the top of the ascenders of the next, where the leading is zero.  Should
        /// normally be equal to <see cref="PointSize" /><c> - (</c><see cref="Ascent" /><c> - </c><see cref="Descent" /><c>)</c>.  
        /// </summary>
        double InterlineSpacing { get; }

        /// <summary>
        /// Measure the size of a string when rendered in this font.
        /// </summary>
        /// <param name="str">The string to be measured.</param>
        /// <returns>A <see cref="UniSize" /> instance containing the size of the string.</returns>
        UniSize MeasureString(string str);

        /// <summary>
        /// Return the width of a "normal space" - ASCII 0x20 - in this font, using the given graphics context to render it.
        /// </summary>
        /// <param name="context">The context used to render the font.</param>
        /// <returns>The width of the ASCII space character.</returns>
        double GetNormalSpaceWidth(IGraphicsContext context);
    }
}
