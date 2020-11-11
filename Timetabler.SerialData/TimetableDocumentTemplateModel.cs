using System.Collections.Generic;

namespace Timetabler.SerialData
{
    /// <summary>
    /// Class representing a document template in serialisable form.
    /// </summary>
    public class TimetableDocumentTemplateModel
    {
        /// <summary>
        /// The file version number of this document.
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// The maps that can be used in timetables.
        /// </summary>
        public List<NetworkMapModel> Maps { get; } = new List<NetworkMapModel>();

        /// <summary>
        /// Default set of document options to apply to documents created from this template.
        /// </summary>
        public DocumentOptionsModel DefaultOptions { get; set; }

        /// <summary>
        /// Default set of export options to apply to documents created from this template.
        /// </summary>
        public ExportOptionsModel DefaultExportOptions { get; set; }

        /// <summary>
        /// Footnote definitions that can be used in documents created from this template.
        /// </summary>
        public List<NoteModel> NoteDefinitions { get; } = new List<NoteModel>();

        /// <summary>
        /// Train classes that can be used in documents created from this template.
        /// </summary>
        public List<TrainClassModel> TrainClasses { get; } = new List<TrainClassModel>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public TimetableDocumentTemplateModel()
        {
            Version = 3;
        }
    }
}
