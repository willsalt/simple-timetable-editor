using System.Xml.Serialization;

namespace Timetabler.SerialData
{
    /// <summary>
    /// The XML-serializable representation of document-level options
    /// </summary>
    public class DocumentOptionsModel
    {
        /// <summary>
        /// Which type of clock to use when formatting times.
        /// </summary>
        [XmlElement]
        public string ClockTypeName { get; set; }

        /// <summary>
        /// Whether or not to display train labels on train graphs.
        /// </summary>
        [XmlElement]
        public bool? DisplayTrainLabelsOnGraphs { get; set; }

        /// <summary>
        /// How the train graph control should behave when the timetable is being edited.
        /// </summary>
        [XmlElement]
        public string GraphEditStyle { get; set; }
    }
}
