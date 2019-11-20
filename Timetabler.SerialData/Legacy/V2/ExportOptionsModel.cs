using System.Xml.Serialization;

namespace Timetabler.SerialData.Legacy.V2
{
    /// <summary>
    /// Options relating to file export.
    /// </summary>
    public class ExportOptionsModel
    {
        /// <summary>
        /// Whether the "Loco Diagram" field should be displayed in the header of each timetable column.
        /// </summary>
        [XmlElement]
        public bool DisplayLocoDiagramRow { get; set; }
    }
}
