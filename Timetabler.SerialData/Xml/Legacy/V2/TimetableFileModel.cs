using System.Collections.Generic;
using System.Xml.Serialization;

namespace Timetabler.SerialData.Xml.Legacy.V2
{
    /// <summary>
    /// The top-level type for XML-serializing a document to and from storage.
    /// </summary>
    [XmlRoot(ElementName = "DocumentModel", Namespace = Namespaces.V2)]
    public class TimetableFileModel
    {
        /// <summary>
        /// Document file format version number.
        /// </summary>
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// Document-level settings.
        /// </summary>
        [XmlElement]
        public DocumentOptionsModel Options { get; set; }

        /// <summary>
        /// Export-specific settings.
        /// </summary>
        [XmlElement]
        public ExportOptionsModel ExportOptions { get; set; }

        /// <summary>
        /// Timetable title.
        /// </summary>
        [XmlElement]
        public string Title { get; set; }

        /// <summary>
        /// Timetable subtitle.
        /// </summary>
        [XmlElement]
        public string Subtitle { get; set; }
        
        /// <summary>
        /// Days to which this timetable applies, such as "Sunday" or "Table C".
        /// </summary>
        [XmlElement]
        public string DateDescription { get; set; }

        /// <summary>
        /// Name of the writer of this timetable.
        /// </summary>
        [XmlElement]
        public string WrittenBy { get; set; }

        /// <summary>
        /// Name of the proofer of this timetable.
        /// </summary>
        [XmlElement]
        public string CheckedBy { get; set; }

        /// <summary>
        /// Version of this timetable content.
        /// </summary>
        [XmlElement]
        public string TimetableVersion { get; set; }

        /// <summary>
        /// Date this timetable was (or will be) published.
        /// </summary>
        [XmlElement]
        public string PublishedDate { get; set; }

        /// <summary>
        /// List of locations used in these timetables.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "Location")]
        public List<LocationModel> LocationList { get; set; }

        /// <summary>
        /// Footnotes used in these timetables.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "Note")]
        public List<NoteModel> NoteDefinitions { get; set; }

        /// <summary>
        /// The train classes used in these timetables.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "TrainClass")]
        public List<TrainClassModel> TrainClassList { get; set; }

        /// <summary>
        /// The trains in this timetable.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "Train", Namespace = Namespaces.V2)]
        public List<TrainModel> TrainList { get; set; }
    }
}
