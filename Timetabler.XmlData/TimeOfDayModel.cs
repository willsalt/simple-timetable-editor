using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Timetabler.XmlData
{
    /// <summary>
    /// The XML-serializable representation of a time of day.
    /// </summary>
    public class TimeOfDayModel : IXmlSerializable
    {
        /// <summary>
        /// The number of hours in the time, using the 24-hour clock.
        /// </summary>
        public int Hours24 { get; set; }

        /// <summary>
        /// The number of minutes in the time.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// The number of seconds in the time.
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// Required for <see cref="IXmlSerializable"/> implementation.
        /// </summary>
        /// <returns>null</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Populates the properties of this object from XML.
        /// </summary>
        /// <param name="reader">Source of XML data.</param>
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            reader.MoveToContent();
            if (reader.LocalName == "Hours24")
            {
                Hours24 = reader.ReadElementContentAsInt();
                reader.MoveToContent();
            }
            if (reader.LocalName == "Minutes")
            {
                Minutes = reader.ReadElementContentAsInt();
                reader.MoveToContent();
            }
            if (reader.LocalName == "Seconds")
            {
                Seconds = reader.ReadElementContentAsInt();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// Serializes this object's properties to XML.
        /// </summary>
        /// <param name="writer">Destination to write XML to.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Hours24", Hours24.ToString("D", CultureInfo.InvariantCulture));
            writer.WriteElementString("Minutes", Minutes.ToString("D", CultureInfo.InvariantCulture));
            writer.WriteElementString("Seconds", Seconds.ToString("D", CultureInfo.InvariantCulture));
        }
    }
}