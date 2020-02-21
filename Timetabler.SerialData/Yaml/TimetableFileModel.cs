using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// Class representing a document in serialisable form.
    /// </summary>
    public class TimetableFileModel
    {
        /// <summary>
        /// File format version number.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Document options.
        /// </summary>
        public DocumentOptionsModel FileOptions { get; set; }

        /// <summary>
        /// Document export options.
        /// </summary>
        public ExportOptionsModel ExportOptions { get; set; }

        /// <summary>
        /// Document title field.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Document subtitle field.
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// Document "descriptive date" field.
        /// </summary>
        public string DateDescription { get; set; }

        /// <summary>
        /// Document "written by" credit.
        /// </summary>
        public string WrittenBy { get; set; }

        /// <summary>
        /// Document "checked by" credit.
        /// </summary>
        public string CheckedBy { get; set; }

        /// <summary>
        /// Version number field of the document (not the file format).
        /// </summary>
        public string TimetableVersion { get; set; }

        /// <summary>
        /// Date this version of this document was published.
        /// </summary>
        public string PublishedDate { get; set; }

        /// <summary>
        /// Network maps contained in this document.
        /// </summary>
        public List<NetworkMapModel> Maps { get; } = new List<NetworkMapModel>();

        /// <summary>
        /// Footnotes used by tables in this document.
        /// </summary>
        public List<NoteModel> NoteDefinitions { get; } = new List<NoteModel>();

        /// <summary>
        /// Train classes used in this document.
        /// </summary>
        public List<TrainClassModel> TrainClassList { get; } = new List<TrainClassModel>();

        /// <summary>
        /// Trains in this document.
        /// </summary>
        public List<TrainModel> TrainList { get; } = new List<TrainModel>();

        /// <summary>
        /// Signalbox hours in this document.
        /// </summary>
        public List<SignalboxHoursSetModel> SignalboxHoursSets { get; } = new List<SignalboxHoursSetModel>();
    }
}
