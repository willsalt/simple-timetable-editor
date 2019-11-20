using System.Collections.Generic;
using System.Xml.Serialization;

namespace Timetabler.SerialData
{
    /// <summary>
    /// The model class for a location map, for serialisation to a file.
    /// </summary>
    [XmlRoot(ElementName = "LocationTemplateModel", Namespace = Namespaces.V3)]
    public class LocationTemplateModel
    {
        /// <summary>
        /// The file version number.
        /// </summary>
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// The array of location maps held in this file.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "Map")]
        public List<NetworkMapModel> Maps { get; set; }

        /// <summary>
        /// Default constructor; initialises file version number.
        /// </summary>
        public LocationTemplateModel()
        {
            Version = 3;
        }
    }
}
