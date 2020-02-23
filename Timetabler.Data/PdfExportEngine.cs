namespace Timetabler.Data
{
    /// <summary>
    /// An enum to specify a PDF export technology to use.
    /// </summary>
    public enum PdfExportEngine
    {
        /// <summary>
        /// The "pure Unicorn" export library, Unicorn.Writer
        /// </summary>
        Unicorn,

        /// <summary>
        /// The original PDFSharp-based Unicorn output library
        /// </summary>
        External
    }
}
