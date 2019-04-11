using System.Xml.Serialization;

namespace Timetabler.XmlData
{
    /// <summary>
    /// The XML-serializable representation of a TrainClass object.
    /// </summary>
    public class TrainClassModel
    {
        /// <summary>
        /// The unique ID string of this class.
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// The code (A, B etc) to display in the header on timetables.
        /// </summary>
        [XmlElement]
        public string TableCode { get; set; }

        /// <summary>
        /// The description of this class (eg Ordinary Passenger).
        /// </summary>
        [XmlElement]
        public string Description { get; set; }
    }
}
