using System.Xml.Serialization;

namespace Timetabler.XmlData
{
    /// <summary>
    /// A class that describes the structure of a block section in serialisable form.
    /// </summary>
    public class BlockSectionModel
    {
        /// <summary>
        /// The ID of this block section.
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the location at one end of this block section.
        /// </summary>
        [XmlElement]
        public string StartLocationId { get; set; }

        /// <summary>
        /// The ID of the location at the other end of this block section.
        /// </summary>
        [XmlElement]
        public string EndLocationId { get; set; }

        /// <summary>
        /// The number of trains which can be in this block section simultaneously.
        /// </summary>
        [XmlElement]
        public int Capacity { get; set; }
    }
}

