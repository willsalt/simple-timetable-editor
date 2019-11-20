using System.Xml.Serialization;

namespace Timetabler.SerialData.Xml
{
    /// <summary>
    /// The XML-serializable representation of a Distance object.
    /// </summary>
    public class DistanceModel
    {
        /// <summary>
        /// The integer miles component of the mileage.
        /// </summary>
        [XmlElement]
        public int Mileage { get; set; }

        /// <summary>
        /// The sub-miles component of the mileage, in chains.  One chain is 1/80 of one mile.
        /// </summary>
        [XmlElement]
        public double Chainage { get; set; }
    }
}
