using System.Collections.Generic;
using System.Xml.Serialization;

namespace Timetabler.XmlData.Legacy.V1
{
    /// <summary>
    /// The model class for a location map, for serialisation to a file.
    /// </summary>
    [XmlRoot(ElementName = "LocationTemplateModel", Namespace = Namespaces.V1)]
    public class LocationTemplateModel
    {
        /// <summary>
        /// The file version number.
        /// </summary>
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// The list of locations in this location map.
        /// </summary>
        [XmlArray]
        [XmlArrayItem(ElementName = "Location")]
        public List<LocationModel> LocationList { get; set; }

        /// <summary>
        /// Default constructor; initialises file version number.
        /// </summary>
        public LocationTemplateModel()
        {
            Version = 1;
        }
    }
}
