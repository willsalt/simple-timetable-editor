using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Timetabler.XmlData
{
    /// <summary>
    /// Data to display in the "To Work" row of the timetable.
    /// </summary>
    public class ToWorkModel : IXmlSerializable
    {
        /// <summary>
        /// Time of day of the next service.
        /// </summary>
        public TimeOfDayModel AtTime { get; set; }

        /// <summary>
        /// Alternative plain-text content.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Required to implement <see cref="IXmlSerializable" />. 
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
            bool isEmpty = reader.IsEmptyElement;
            reader.ReadStartElement();
            if (!isEmpty)
            {
                reader.MoveToContent();
                if (reader.LocalName == "AtTime")
                {
                    AtTime = new TimeOfDayModel();
                    AtTime.ReadXml(reader);
                    reader.MoveToContent();
                }
                if (reader.LocalName == "Text")
                {
                    Text = reader.ReadElementContentAsString();
                    reader.MoveToContent();
                }
                reader.ReadEndElement();
            }
        }

        /// <summary>
        /// Serilize this object's properties to XML.
        /// </summary>
        /// <param name="writer">Destination to write XML to.</param>
        public void WriteXml(XmlWriter writer)
        {
            if (AtTime != null)
            {
                writer.WriteStartElement("AtTime");
                AtTime.WriteXml(writer);
                writer.WriteEndElement();
            }
            if (Text != null)
            {
                writer.WriteElementString("Text", Text);
            }
        }
    }
}
