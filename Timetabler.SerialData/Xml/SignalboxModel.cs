using System.Xml.Serialization;

namespace Timetabler.SerialData.Xml
{
    /// <summary>
    /// A class to describe a signalbox on a network map.
    /// </summary>
    public class SignalboxModel
    {
        /// <summary>
        /// The ID of this box.
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// The code name of this signalbox.
        /// </summary>
        [XmlElement]
        public string Code { get; set; }

        /// <summary>
        /// The name of this signalbox, as used in the program UI.
        /// </summary>
        [XmlElement]
        public string EditorDisplayName { get; set; }

        /// <summary>
        /// The name of this signalbox, as displayed on exported timetables when the full name is used.
        /// </summary>
        [XmlElement]
        public string TimetableDisplayName { get; set; }
    }
}
