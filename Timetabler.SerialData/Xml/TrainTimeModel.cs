using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Timetabler.SerialData.Xml
{
    /// <summary>
    /// Represents a train time entry with footnotes.
    /// </summary>
    public class TrainTimeModel : IXmlSerializable
    {
        /// <summary>
        /// The time.
        /// </summary>
        public TimeOfDayModel Time { get; set; }

        /// <summary>
        /// The IDs of the footnotes to apply to this time entry.
        /// </summary>
        public List<string> FootnoteIds { get; } = new List<string>();

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
            if (reader.LocalName == "Time")
            {
                Time = new TimeOfDayModel();
                Time.ReadXml(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "FootnoteIds")
            {
                bool isEmpty = reader.IsEmptyElement;
                reader.ReadStartElement();
                if (!isEmpty)
                {
                    reader.MoveToContent();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        FootnoteIds.Add(reader.ReadElementContentAsString());
                        reader.MoveToContent();
                    }
                    reader.ReadEndElement();
                }
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// Serialize this object to XML.
        /// </summary>
        /// <param name="writer">Destination to write XML to.</param>
        public void WriteXml(XmlWriter writer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            if (Time != null)
            {
                writer.WriteStartElement("Time");
                Time.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("FootnoteIds");
            if (FootnoteIds != null)
            {
                foreach (string id in FootnoteIds)
                {
                    writer.WriteElementString("Note", id);
                }
            }
            writer.WriteEndElement();
        }
    }
}
