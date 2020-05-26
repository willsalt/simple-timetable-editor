using System.Collections;
using System.Collections.Generic;

namespace Unicorn.FontTools.OpenType.Interfaces
{
    /// <summary>
    /// Interface representing an OpenType font file and its content.
    /// </summary>
    public interface IOpenTypeFont : IEnumerable<byte>
    {
        /// <summary>
        /// The full path of the file that contains this font.
        /// </summary>
        string Filename { get; }

        long Length { get; }

        /// <summary>
        /// The ratio between font design units and em units (in other words, when the font is rendered at x pointC:\Users\Will\Source\Repos\simple-timetable-editor\Unicorn.FontTools\OpenType\Interfaces\IOpenTypeFont.css, this number of design units will measure x points.
        /// Generally a medium-sized power of 2 such as 2048, but can be any value up to 16,384.
        /// </summary>
        int DesignUnitsPerEm { get; }

        /// <summary>
        /// The content of the font's "head" data table.
        /// </summary>
        HeaderTable Header { get; }

        /// <summary>
        /// The "hhea" table of the font, which must be present for the font to be a valid OpenType file.
        /// </summary>
        HorizontalHeaderTable HorizontalHeader { get; }

        /// <summary>
        /// The content of the font's "name" data table.
        /// </summary>
        NamingTable Naming { get; }

        /// <summary>
        /// The content of the font's "OS/2" data table.
        /// </summary>
        OS2MetricsTable OS2Metrics { get; }

        /// <summary>
        /// The content of the font's "cmap" data table.
        /// </summary>
        CharacterMappingTable CharacterMapping { get; }

        /// <summary>
        /// The content of the font's "post" data table.
        /// </summary>
        PostScriptTable PostScriptData { get; }

        /// <summary>
        /// Return the advance width (in font design units) of the given codepoint on the given platform, using the best encoding for that platform.
        /// </summary>
        /// <param name="platform">The platform to measure for.</param>
        /// <param name="codePoint">The code point to be measured.</param>
        /// <returns>The advance width value for the bset glyph found to represent the given code point on the specified platform.</returns>
        int AdvanceWidth(PlatformId platform, uint codePoint);

        bool HasGlyphDefined(PlatformId platform, uint codePoint);
    }
}
