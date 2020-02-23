using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Timetabler.SerialData.Xml
{
    /// <summary>
    /// The XML-serializable representation of a train timing point.
    /// </summary>
    public class TrainLocationTimeModel : IXmlSerializable
    {
        /// <summary>
        /// The arrival time of the train at the location.
        /// </summary>
        public TrainTimeModel ArrivalTime { get; set; }

        /// <summary>
        /// The departure or passing time of the train at the location.
        /// </summary>
        public TrainTimeModel DepartureTime { get; set; }

        /// <summary>
        /// Whether the departure time should be displayed as a passing time, or as a stopping time.
        /// </summary>
        public bool Pass { get; set; }

        /// <summary>
        /// The unique ID of the location this timing point is applicable to.  Used for normalised serialisation.
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// The path code for this timing point - to be displayed before arrival.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The platform code for this timing point - to be displayed between arrival and departure.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// The line code for this timing point - to be displayed after departure.
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// Required to implement <see cref="IXmlSerializable"/>.
        /// </summary>
        /// <returns>null</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Populate this object's properties from XML.
        /// </summary>
        /// <param name="reader">Source of XML data.</param>
        public void ReadXml(XmlReader reader)
        {
            if (reader is null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            reader.ReadStartElement();
            reader.MoveToContent();
            if (reader.LocalName == "ArrivalTime")
            {
                ArrivalTime = new TrainTimeModel();
                ArrivalTime.ReadXml(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "DepartureTime")
            {
                DepartureTime = new TrainTimeModel();
                DepartureTime.ReadXml(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "Pass")
            {
                Pass = reader.ReadElementContentAsBoolean();
                reader.MoveToContent();
            }
            if (reader.LocalName == "LocationId")
            {
                LocationId = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            if (reader.LocalName == "Path")
            {
                Path = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            if (reader.LocalName == "Platform")
            {
                Platform = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            if (reader.LocalName == "Line")
            {
                Line = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// Serialize this object's properties to XML.
        /// </summary>
        /// <param name="writer">Destination to write XML to.</param>
        public void WriteXml(XmlWriter writer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            if (ArrivalTime != null)
            {
                writer.WriteStartElement("ArrivalTime");
                ArrivalTime.WriteXml(writer);
                writer.WriteEndElement();
            }
            if (DepartureTime != null)
            {
                writer.WriteStartElement("DepartureTime");
                DepartureTime.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteElementString("Pass", Pass ? "true" : "false");
            if (LocationId != null)
            {
                writer.WriteElementString("LocationId", LocationId);
            }
            if (Path != null)
            {
                writer.WriteElementString("Path", Path);
            }
            if (Platform != null)
            {
                writer.WriteElementString("Platform", Platform);
            }
            if (Line != null)
            {
                writer.WriteElementString("Line", Line);
            }
        }
    }
}
