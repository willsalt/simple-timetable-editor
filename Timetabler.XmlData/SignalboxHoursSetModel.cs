using System.Collections.Generic;
using System.Xml.Serialization;

namespace Timetabler.XmlData
{
    /// <summary>
    /// An XML-serializable class to describe a service pattern and the times at which each signalbox on the map must be open.
    /// </summary>
    public class SignalboxHoursSetModel
    {
        /// <summary>
        /// The name of the service pattern.
        /// </summary>
        [XmlElement]
        public string Category { get; set; }

        /// <summary>
        /// The list of signalbox opening times for this service pattern.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "Signalbox")]
        public List<SignalboxHoursModel> Signalboxes { get; set; }
    }
}
