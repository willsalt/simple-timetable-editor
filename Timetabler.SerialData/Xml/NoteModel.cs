using System.Xml.Serialization;

namespace Timetabler.SerialData.Xml
{
    /// <summary>
    /// The XML-serializable representation of a footnote definition.
    /// </summary>
    public class NoteModel
    {
        /// <summary>
        /// The unique ID of this note item.
        /// </summary>
        [XmlElement]
        public string Id { get; set; }

        /// <summary>
        /// The symbol used to represent this note where it is referred to (eg. a single letter).
        /// </summary>
        [XmlElement]
        public string Symbol { get; set; }

        /// <summary>
        /// The explanation of this note elsewhere.
        /// </summary>
        [XmlElement]
        public string Definition { get; set; }

        /// <summary>
        /// This note can appear in the header of a train.
        /// </summary>
        [XmlElement]
        public bool AppliesToTrains { get; set; }

        /// <summary>
        /// This note can appear attached to an individual timing.
        /// </summary>
        [XmlElement]
        public bool AppliesToTimings { get; set; }

        /// <summary>
        /// The definition of this note appears on the bottom of pages where it is used.
        /// </summary>
        [XmlElement]
        public bool DefinedOnPages { get; set; }

        /// <summary>
        /// The definition of this note appears on a separate glossary page.
        /// </summary>
        [XmlElement]
        public bool DefinedInGlossary { get; set; }
    }
}
