using Timetabler.CoreData;

namespace Timetabler.Data
{
    /// <summary>
    /// Export-specific document settings.
    /// </summary>
    public class DocumentExportOptions
    {
        /// <summary>
        /// Whether or not to display the "Loco Diagram" field in the timetable column header (assuming it is populated).
        /// </summary>
        public bool DisplayLocoDiagramRow { get; set; }

        /// <summary>
        /// Whether or not to display the "To Work" row at the foot of each timetable column.
        /// </summary>
        public bool DisplayToWorkRow { get; set; }

        /// <summary>
        /// Whether or not to display the "Loco To Work" row at the foot of each timetable column, if it is populated.
        /// </summary>
        public bool DisplayLocoToWorkRow { get; set; }

        /// <summary>
        /// Whether or not to display the Signalbox Hours block under each timetable, if it is populated.
        /// </summary>
        public bool DisplayBoxHours { get; set; }

        /// <summary>
        /// Whether or not to display the credits block under each timetable, if it is populated.
        /// </summary>
        public bool DisplayCredits { get; set; }

        /// <summary>
        /// Whether or not to export the train graph.
        /// </summary>
        public bool DisplayGraph { get; set; }

        /// <summary>
        /// Whether or not to export a footnote glossary.
        /// </summary>
        public bool DisplayGlossary { get; set; }

        /// <summary>
        /// Width of grid lines in the timetable output.
        /// </summary>
        public double LineWidth { get; set; }

        /// <summary>
        /// Width of the lines used to indicate that a train passes through a location that is not a timing point.
        /// </summary>
        public double FillerDashLineWidth { get; set; }

        /// <summary>
        /// The PDF export engine to use.
        /// </summary>
        public PdfExportEngine ExportEngine { get; set; }

        /// <summary>
        /// Whether to use standard or embedded fonts.
        /// </summary>
        public PdfFontChoice FontChoice { get; set; }

        /// <summary>
        /// The output orientation of table pages.
        /// </summary>
        public Orientation TablePageOrientation { get; set; }

        /// <summary>
        /// The output orientation of graph pages.
        /// </summary>
        public Orientation GraphPageOrientation { get; set; }

        /// <summary>
        /// Default constructor - sets the default values of the <see cref="LineWidth" /> and <see cref="FillerDashLineWidth" /> properties.
        /// </summary>
        public DocumentExportOptions()
        {
            LineWidth = 1.0;
            FillerDashLineWidth = 0.5;
            ExportEngine = PdfExportEngine.External;
            TablePageOrientation = Orientation.Landscape;
            GraphPageOrientation = Orientation.Landscape;
        }

        /// <summary>
        /// Return a copy of this object.
        /// </summary>
        /// <returns>A <see cref="DocumentExportOptions"/> object with equal properties to this object.</returns>
        public DocumentExportOptions Copy()
        {
            return new DocumentExportOptions
            {
                DisplayLocoDiagramRow = DisplayLocoDiagramRow,
                DisplayToWorkRow = DisplayToWorkRow,
                DisplayLocoToWorkRow = DisplayLocoToWorkRow,
                DisplayBoxHours = DisplayBoxHours,
                DisplayCredits = DisplayCredits,
                LineWidth = LineWidth,
                FillerDashLineWidth = FillerDashLineWidth,
                DisplayGraph = DisplayGraph,
                DisplayGlossary = DisplayGlossary,
                ExportEngine = ExportEngine,
                FontChoice = FontChoice,
                TablePageOrientation = TablePageOrientation,
                GraphPageOrientation = GraphPageOrientation,
            };
        }
    }
}
