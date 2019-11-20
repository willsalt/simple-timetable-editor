using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Timetabler.SerialData
{
    /// <summary>
    /// The XML-serializable representation of the properties that relate to how a train is displayed on a train graph.
    /// </summary>
    public class GraphTrainPropertiesModel : IXmlSerializable
    {
        /// <summary>
        /// The colour of the train's line on the graph, represented as an 8-character hex string with no prefix, to be interpreted as a 32-bit ARGB value.
        /// </summary>
        public string ColourCode { get; set; }

        /// <summary>
        /// The width of the train's line on the graph.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// The string name of the value of the DashStyle property, for serialisation purposes.
        /// </summary>
        public string DashStyleName { get; set; }

        /// <summary>
        /// Required by <see cref="IXmlSerializable"/> implementation.
        /// </summary>
        /// <returns>null</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Populates the properties of this object from XML.
        /// </summary>
        /// <param name="reader">The source of the XML data.</param>
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            reader.MoveToContent();
            if (reader.LocalName == "ColourCode")
            {
                ColourCode = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            if (reader.LocalName == "Width")
            {
                Width = reader.ReadElementContentAsFloat();
                reader.MoveToContent();
            }
            if (reader.LocalName == "DashStyleName")
            {
                DashStyleName = reader.ReadElementContentAsString();
                reader.MoveToContent();
            }
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (!reader.Read())
                {
                    break;
                }
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// Serializes the properties of this object to XML.
        /// </summary>
        /// <param name="writer">The destination to write XML to.</param>
        public void WriteXml(XmlWriter writer)
        {
            if (ColourCode != null)
            {
                writer.WriteElementString("ColourCode", ColourCode);
            }
            writer.WriteElementString("Width", Width.ToString("R", CultureInfo.InvariantCulture));
            if (DashStyleName != null)
            {
                writer.WriteElementString("DashStyleName", DashStyleName);
            }
        }
    }
}
