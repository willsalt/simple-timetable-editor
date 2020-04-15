namespace Unicorn.Interfaces
{
    /// <summary>
    /// Wrapper object for a font, exposing its metadata.
    /// </summary>
    public interface IFontDescriptor
    {
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
