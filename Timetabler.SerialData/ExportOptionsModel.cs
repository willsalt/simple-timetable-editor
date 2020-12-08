using Timetabler.CoreData;

namespace Timetabler.SerialData
{
    /// <summary>
    /// Class that describes the settings relating to document export.
    /// </summary>
    public class ExportOptionsModel
    {
        /// <summary>
        /// Display a column header row containing the loco diagram field for each train.
        /// </summary>
        public bool? DisplayLocoDiagramRow { get; set; }

        /// <summary>
        /// Which fonts to use in the output (not currently supported but retained for future use).
        /// </summary>
        public string FontSet { get; set; }

        /// <summary>
        /// Whether or not to include train graphs in the PDF file.
        /// </summary>
        public bool? GraphsInOutput { get; set; }

        /// <summary>
        /// Whether or not to include a "[set] to work" row in the column footers of each train.
        /// </summary>
        public bool? SetToWorkRowInOutput { get; set; }

        /// <summary>
        /// Whether or not to include a "loco to work" row in the column footers of each train.
        /// </summary>
        public bool? LocoToWorkRowInOutput { get; set; }

        /// <summary>
        /// Whether or not to include the signalbox opening hours table in the output for each timetable.
        /// </summary>
        public bool? BoxHoursInOutput { get; set; }

        /// <summary>
        /// Whether or not to include the credits/version table in the output for each timetable.
        /// </summary>
        public bool? CreditsInOutput { get; set; }

        /// <summary>
        /// Whether or not to include a footnote glossary in the PDF file.
        /// </summary>
        public bool? GlossaryInOutput { get; set; }

        /// <summary>
        /// The width of the lines used to draw tables. 
        /// </summary>
        public double? LineWidth { get; set; }

        /// <summary>
        /// The width of the axes and grid lines on the train graph.
        /// </summary>
        public double? GraphAxisLineWidth { get; set; }

        /// <summary>
        /// The width of the lines used to draw "filler dashes" - the lines drawn in cells where a train passes through a location without stopping.
        /// </summary>
        public double? FillerDashLineWidth { get; set; }

        /// <summary>
        /// The orientation of timetable section pages.
        /// </summary>
        public Orientation? TablePageOrientation { get; set; }

        /// <summary>
        /// The orientation of graph pages.
        /// </summary>
        public Orientation? GraphPageOrientation { get; set; }

        /// <summary>
        /// The label used at the top left of Up timetable sections.
        /// </summary>
        public string UpSectionLabel { get; set; }

        /// <summary>
        /// The label used at the top left of Down timetable sections.
        /// </summary>
        public string DownSectionLabel { get; set; }

        /// <summary>
        /// The label used at the top of segments that start in the morning.
        /// </summary>
        public string MorningLabel { get; set; }

        /// <summary>
        /// The label used at the top of segments that start at noon.
        /// </summary>
        public string MiddayLabel { get; set; }

        /// <summary>
        /// The label used at the top of segments that start in the afternoon/evening.
        /// </summary>
        public string AfternoonLabel { get; set; }

        /// <summary>
        /// Whether or not to show a table of distances in the output.
        /// </summary>
        public SectionSelection? DistancesInOutput { get; set; }

        /// <summary>
        /// The order in which to export timetables.  Trains in the direction given here will be exported first, then trains in the other direction.
        /// The default is Down first.
        /// </summary>
        public Direction? FirstDirectionExported { get; set; }
    }
}
