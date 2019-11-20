using System.Xml.Serialization;

namespace Timetabler.SerialData.Xml
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

        /// <summary>
        /// The name of the font set to use for this document.
        /// </summary>
        [XmlElement]
        public string FontSet { get; set; }

        /// <summary>
        /// Whether or not to include train graphs in the exported output.
        /// </summary>
        [XmlElement]
        public bool GraphsInOutput { get; set; }

        /// <summary>
        /// Whether or not to include a "To Work" row in the exported output
        /// </summary>
        [XmlElement]
        public bool? ToWorkRowInOutput { get; set; }

        /// <summary>
        /// Whether or not to include a "Loco To Work" row in the exported output, assuming there is data available to populate it.
        /// </summary>
        [XmlElement]
        public bool? LocoToWorkRowInOutput { get; set; }

        /// <summary>
        /// Whether or not to include the signalbox hours block in the exported output, if it is populated.
        /// </summary>
        [XmlElement]
        public bool? BoxHoursInOutput { get; set; }

        /// <summary>
        /// Whether or not to include the credits block in the exported output.
        /// </summary>
        [XmlElement]
        public bool? CreditsInOutput { get; set; }

        /// <summary>
        /// Whether or not to include a footnote glossary in the exported output.
        /// </summary>
        [XmlElement]
        public bool? GlossaryInOutput { get; set; }

        /// <summary>
        /// Width of the lines used to draw the majority of gridlines in the output.
        /// </summary>
        [XmlElement]
        public double? LineWidth { get; set; }

        /// <summary>
        /// Width of the lines used to draw the dashes that indicate a train passes through a location that is not a timing point.
        /// </summary>
        [XmlElement]
        public double? FillerDashLineWidth { get; set; }
    }
}
