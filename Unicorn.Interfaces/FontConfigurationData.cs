namespace Unicorn.Interfaces
{
    /// <summary>
    /// A class which maps a font name and font style to a filename.
    /// </summary>
    public class FontConfigurationData
    {
        /// <summary>
        /// The name of the font family.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The style of the font.
        /// </summary>
        public UniFontStyle Style { get; set; }

        /// <summary>
        /// The filename of the font file.
        /// </summary>
        public string Filename { get; set; }
    }
}
