using System.IO;

namespace Timetabler.Helpers
{
    /// <summary>
    /// Various file-related constants and other helpers.
    /// </summary>
    public static class FileHelpers
    {
        /// <summary>
        /// The filename extension for timetable files.
        /// </summary>
        public const string TimetableFileExtension = "wtt";

        /// <summary>
        /// The filename extension for location template files (may be removed in a future version).
        /// </summary>
        public const string LocationTemplateFileExtension = "wtl";

        /// <summary>
        /// The filename extension for document template files.
        /// </summary>
        public const string DocumentTemplateFileExtension = "wtm";

        /// <summary>
        /// The filename extension for PDF files - well-known but included for consistency!
        /// </summary>
        public const string PdfFileExtension = "pdf";
    }
}
