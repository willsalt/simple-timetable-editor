namespace Timetabler.Data
{
    /// <summary>
    /// The font set to use on PDF export.
    /// </summary>
    public enum PdfFontChoice
    {
        /// <summary>
        /// The PDF Standard fonts that all PDF viewers are expected to implement.
        /// </summary>
        Standard,
        
        /// <summary>
        /// The OpenType fonts installed with the application.
        /// </summary>
        Provided,
    }
}
