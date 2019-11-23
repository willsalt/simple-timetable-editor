using System.Collections.Generic;
using System.Xml.Serialization;

namespace Timetabler.SerialData.Xml
{
    /// <summary>
    /// The model class for a document template, for serialization into a file.
    /// </summary>
    [XmlRoot(ElementName = "TimetableDocumentTemplate", Namespace = Namespaces.V3)]
    public class TimetableDocumentTemplateModel
    {
        /// <summary>
        /// File format version number.
        /// </summary>
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// The network maps contained in this template.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "Map")]
        public List<NetworkMapModel> Maps { get; set; }

        /// <summary>
        /// The default document options.
        /// </summary>
        [XmlElement]
        public DocumentOptionsModel DefaultOptions { get; set; }

        /// <summary>
        /// The default document options relating to exports.
        /// </summary>
        [XmlElement]
        public ExportOptionsModel DefaultExportOptions { get; set; }

        /// <summary>
        /// Footnotes that can be used in timetables.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "Note")]
        public List<NoteModel> NoteDefinitions { get; set; }

        /// <summary>
        /// Train classes for trains that can be used in timetables.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "TrainClass")]
        public List<TrainClassModel> TrainClasses { get; set; }

        /// <summary>
        /// Signalboxes.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName ="Signalbox")]
        public List<SignalboxModel> Signalboxes { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TimetableDocumentTemplateModel()
        {
            Version = 3;
        }
    }
}
