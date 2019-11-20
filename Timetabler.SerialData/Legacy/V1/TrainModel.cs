using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Timetabler.SerialData.Legacy.V1
{
    /// <summary>
    /// The XML-serializable representation of a train in the timetable.
    /// </summary>
    public class TrainModel : IXmlSerializable
    {
        /// <summary>
        /// The unique identifier of this train.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The headcode or diagram number of this train.
        /// </summary>
        public string Headcode { get; set; }

        /// <summary>
        /// The Id property of the TrainClass property, for normalised serialisation.
        /// </summary>
        public string TrainClassId { get; set; }

        /// <summary>
        /// The graph display properties of this train.
        /// </summary>
        public GraphTrainPropertiesModel GraphProperties { get; set; }

        /// <summary>
        /// The timing points of this train.
        /// </summary>
        public List<TrainLocationTimeModel> TrainTimes { get; set; }

        /// <summary>
        /// The IDs of the footnotes, for normalised serialisation
        /// </summary>
        public List<string> FootnoteIds { get; set; }

        /// <summary>
        /// Populate the properties of this object from XML.
        /// </summary>
        /// <param name="reader">Source of the XML to be read.</param>
        public void ReadXml(XmlReader reader)
        {
            GraphProperties = new GraphTrainPropertiesModel();
            TrainTimes = new List<TrainLocationTimeModel>();
            FootnoteIds = new List<string>();

            reader.MoveToContent();
            Id = reader.GetAttribute("Id");
            bool isEmptyElement = false;
            if (reader.IsEmptyElement)
            {
                isEmptyElement = true;
            }
            reader.ReadStartElement();
            if (isEmptyElement)
            {
                return;
            }

            reader.MoveToContent();
            Headcode = reader.ReadElementContentAsString();
            reader.MoveToContent();
            TrainClassId = reader.ReadElementContentAsString();
            reader.MoveToContent();
            if (reader.ReadState != ReadState.Interactive || reader.NodeType != XmlNodeType.Element)
            {
                return;
            }
            if (reader.LocalName == "GraphProperties")
            {
                GraphProperties.ReadXml(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "TrainTimes")
            {
                ReadTrainTimes(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "FootnoteIds")
            {
                ReadFootnotes(reader);
                reader.MoveToContent();
            }
            MoveToEndElement(reader);
            reader.ReadEndElement();
        }

        private void ReadFootnotes(XmlReader reader)
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
        }

        private void ReadTrainTimes(XmlReader reader)
        {
            reader.ReadStartElement();
            do
            {
                reader.MoveToContent();
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    break;
                }
                TrainLocationTimeModel ttm = new TrainLocationTimeModel();
                ttm.ReadXml(reader);
                TrainTimes.Add(ttm);
            } while (true);
            reader.ReadEndElement();
        }

        private void MoveToEndElement(XmlReader reader)
        {
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (!reader.Read())
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Serialize this object to XML.
        /// </summary>
        /// <param name="writer">The destination to write the serialized object data to.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id", Id);
            if (Headcode != null)
            {
                writer.WriteElementString("Headcode", Headcode);
            }
            if (TrainClassId != null)
            {
                writer.WriteElementString("TrainClassId", TrainClassId);
            }

            if (GraphProperties != null)
            {
                writer.WriteStartElement("GraphProperties");
                GraphProperties.WriteXml(writer);
                writer.WriteEndElement();
            }

            writer.WriteStartElement("TrainTimes");
            foreach (TrainLocationTimeModel time in TrainTimes)
            {
                writer.WriteStartElement("Time");
                time.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("FootnoteIds");
            foreach (string note in FootnoteIds)
            {
                writer.WriteElementString("Note", note);
            }
            writer.WriteEndElement();
        }

        /// <summary>
        /// Required by <see cref="IXmlSerializable"/> implementation.
        /// </summary>
        /// <returns>null</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
