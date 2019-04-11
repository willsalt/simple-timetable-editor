using NLog;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Timetabler.XmlData
{
    /// <summary>
    /// The XML-serializable representation of a train in the timetable.
    /// </summary>
    public class TrainModel : IXmlSerializable
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The unique identifier of this train.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The headcode or diagram number of this train.
        /// </summary>
        public string Headcode { get; set; }

        /// <summary>
        /// The diagram number of the locomotive, if different.
        /// </summary>
        public string LocoDiagram { get; set; }

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
        /// If this train does not start at the first location in the timetable, draw a separator line above its first timing point.
        /// </summary>
        public bool IncludeSeparatorAbove { get; set; }

        /// <summary>
        /// If this train does not end at the last location in the timetable, draw a separator line below its last timing point.
        /// </summary>
        public bool IncludeSeparatorBelow { get; set; }

        /// <summary>
        /// Text to be displayed in the train's timetable columns.
        /// </summary>
        public string InlineNote { get; set; }

        /// <summary>
        /// Details of what this train does next.
        /// </summary>
        public ToWorkModel ToWork { get; set; }

        /// <summary>
        /// Details of what the loco from this train does next.
        /// </summary>
        public ToWorkModel LocoToWork { get; set; }

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
            Log.Trace("Reading train.");
            GraphProperties = new GraphTrainPropertiesModel();
            TrainTimes = new List<TrainLocationTimeModel>();
            FootnoteIds = new List<string>();
            ToWork = new ToWorkModel();
            LocoToWork = new ToWorkModel();

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
            if (reader.LocalName == "Headcode")
            {
                Log.Trace("Reading <Headcode>");
                Headcode = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            if (reader.LocalName == "LocoDiagram")
            {
                Log.Trace("Reading <LocoDiagram>");
                LocoDiagram = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            if (reader.LocalName == "TrainClassId")
            {
                Log.Trace("Reading <TrainClassId>");
                TrainClassId = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            if (reader.LocalName == "GraphProperties")
            {
                Log.Trace("Reading <GraphProperties>");
                GraphProperties.ReadXml(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "TrainTimes")
            {
                Log.Trace("Reading <TrainTimes>");
                ReadTrainTimes(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "FootnoteIds")
            {
                Log.Trace("Reading <FootnoteIds>");
                ReadFootnotes(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "IncludeSeparatorAbove")
            {
                Log.Trace("Reading <IncludeSeparatorAbove>");
                IncludeSeparatorAbove = reader.ReadElementContentAsBoolean();
                reader.MoveToContent();
            }
            if (reader.LocalName == "IncludeSeparatorBelow")
            {
                Log.Trace("Reading <IncludeSeparatorBelow>");
                IncludeSeparatorBelow = reader.ReadElementContentAsBoolean();
                reader.MoveToContent();
            }
            if (reader.LocalName == "InlineNote")
            {
                Log.Trace("Reading <InlineNote>");
                InlineNote = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            if (reader.LocalName == "ToWork")
            {
                Log.Trace("Reading <ToWork>");
                ToWork.ReadXml(reader);
                reader.MoveToContent();
            }
            if (reader.LocalName == "LocoToWork")
            {
                Log.Trace("Reading <LocoToWork>");
                LocoToWork.ReadXml(reader);
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
        /// Serialize this object's properties to XML.
        /// </summary>
        /// <param name="writer">Destination to write XML to.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id", Id);
            if (Headcode != null)
            {
                writer.WriteElementString("Headcode", Headcode);
            }
            if (LocoDiagram != null)
            {
                writer.WriteElementString("LocoDiagram", LocoDiagram);
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

            writer.WriteElementString("IncludeSeparatorAbove", IncludeSeparatorAbove ? "true" : "false");
            writer.WriteElementString("IncludeSeparatorBelow", IncludeSeparatorBelow ? "true" : "false");
            writer.WriteElementString("InlineNote", InlineNote);

            if (ToWork != null)
            {
                writer.WriteStartElement("ToWork");
                ToWork.WriteXml(writer);
                writer.WriteEndElement();
            }
            if (LocoToWork != null)
            {
                writer.WriteStartElement("LocoToWork");
                LocoToWork.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
}
