namespace Timetabler.PdfExport
{
    internal class SectionMetrics
    {
        internal bool DisplayDistanceColumn { get; set; }

        internal double LineWidth { get; set; }

        internal double TitleHeight { get; set; }

        internal double SubtitleHeight { get; set; }

        internal double HeaderHeight { get; set; }

        internal bool HeaderIncludesFootnoteRow { get; set; }

        internal double ColumnWidth { get; set; }

        internal LocationBoxDimensions LocationMetrics { get; set; }

        internal double ToWorkHeight { get; set; }

        internal double LocoToWorkHeight { get; set; }

        internal double TotalHeight => TitleHeight + SubtitleHeight + TableHeight + LineWidth;

        internal double TableHeight => HeaderHeight + LocationMetrics.TotalSize.Height + ToWorkHeight + LocoToWorkHeight;

        internal double HeaderOffset => TitleHeight + SubtitleHeight;

        internal double MainSectionOffset => TitleHeight + SubtitleHeight + HeaderHeight;

        internal double ToWorkOffset => TitleHeight + SubtitleHeight + HeaderHeight + LocationMetrics.TotalSize.Height;

        internal double MainSectionBoundingHeight => SubtitleHeight + HeaderHeight + LocationMetrics.TotalSize.Height + ToWorkHeight + LocoToWorkHeight;

        internal bool IncludeLocoDiagramRow { get; set; }

        internal bool IncludeToWorkRow { get; set; }

        internal bool IncludeLocoToWorkRow { get; set; }

        internal SectionMetrics(double lineWidth)
        {
            LineWidth = lineWidth;
        }

        internal SectionMetrics CopyWithNoTitle(bool copyDisplayDistance)
        {
            return new SectionMetrics(LineWidth)
            {
                TitleHeight = 0,
                SubtitleHeight = 0,
                HeaderHeight = HeaderHeight,
                ColumnWidth = ColumnWidth,
                LocationMetrics = LocationMetrics,
                IncludeLocoDiagramRow = IncludeLocoDiagramRow,
                IncludeToWorkRow = IncludeToWorkRow,
                ToWorkHeight = ToWorkHeight,
                IncludeLocoToWorkRow = IncludeLocoToWorkRow,
                LocoToWorkHeight = LocoToWorkHeight,
                HeaderIncludesFootnoteRow = HeaderIncludesFootnoteRow,
                DisplayDistanceColumn = copyDisplayDistance ? DisplayDistanceColumn : false,
            };
        }
    }
}
