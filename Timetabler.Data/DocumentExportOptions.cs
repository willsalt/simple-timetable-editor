﻿using Timetabler.CoreData;

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
        /// Width of axes and grid lines in the train graph output.
        /// </summary>
        public double GraphAxisLineWidth { get; set; }

        /// <summary>
        /// Width of the lines used to indicate that a train passes through a location that is not a timing point.
        /// </summary>
        public double FillerDashLineWidth { get; set; }

        /// <summary>
        /// The output orientation of table pages.
        /// </summary>
        public Orientation TablePageOrientation { get; set; }

        /// <summary>
        /// The output orientation of graph pages.
        /// </summary>
        public Orientation GraphPageOrientation { get; set; }

        /// <summary>
        /// The label used at the top-left of Up timetable sections.  Defaults to "UP" (or its internationalised equivalent).
        /// </summary>
        public string UpSectionLabel { get; set; }

        /// <summary>
        /// The label used at the top-left of Down timetable sections.  Defaults to "DOWN" (or its internationalised equivalent).
        /// </summary>
        public string DownSectionLabel { get; set; }

        /// <summary>
        /// The label used at the top of segments that start in the morning (e.g. "a.m.").
        /// </summary>
        public string MorningLabel { get; set; }

        /// <summary>
        /// The label used at the top of segments that start at midday (e.g. "noon").
        /// </summary>
        public string MiddayLabel { get; set; }

        /// <summary>
        /// The label used at the top of segments that start in the afternoon or evening (e.g. "P.M.").
        /// </summary>
        public string AfternoonLabel { get; set; }

        /// <summary>
        /// Whether to show a table of location distances in the output.
        /// </summary>
        public SectionSelection DistancesInOutput { get; set; }

        /// <summary>
        /// Which direction of travel comes first in the output.
        /// </summary>
        public Direction FirstDirectionExported { get; set; }

        /// <summary>
        /// Default constructor - sets the default values of the <see cref="LineWidth" />, <see cref="GraphAxisLineWidth" /> and 
        /// <see cref="FillerDashLineWidth" /> properties, and loads the default values of the <see cref="UpSectionLabel" /> and <see cref="DownSectionLabel" />
        /// properties from the resources file.
        /// </summary>
        public DocumentExportOptions()
        {
            LineWidth = 1.0;
            GraphAxisLineWidth = 1.0;
            FillerDashLineWidth = 0.5;
            TablePageOrientation = Orientation.Landscape;
            GraphPageOrientation = Orientation.Landscape;
            UpSectionLabel = Resources.DocumentExportOptions_DefaultUpSectionLabel;
            DownSectionLabel = Resources.DocumentExportOptions_DefaultDownSectionLabel;
            MorningLabel = Resources.DocumentExportOptions_DefaultMorningLabel;
            MiddayLabel = Resources.DocumentExportOptions_DefaultMiddayLabel;
            AfternoonLabel = Resources.DocumentExportOptions_DefaultAfternoonLabel;
            FirstDirectionExported = Direction.Down;
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
                GraphAxisLineWidth = GraphAxisLineWidth,
                DisplayGraph = DisplayGraph,
                DisplayGlossary = DisplayGlossary,
                TablePageOrientation = TablePageOrientation,
                GraphPageOrientation = GraphPageOrientation,
                UpSectionLabel = UpSectionLabel,
                DownSectionLabel = DownSectionLabel,
                DistancesInOutput = DistancesInOutput,
                MorningLabel = MorningLabel,
                MiddayLabel = MiddayLabel,
                AfternoonLabel = AfternoonLabel,
                FirstDirectionExported = FirstDirectionExported,
            };
        }
    }
}
