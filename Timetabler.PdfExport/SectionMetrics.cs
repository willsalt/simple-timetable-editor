namespace Timetabler.PdfExport
{
    internal class SectionMetrics
    {
        internal double LineWidth { get; set; }

        internal double TitleHeight { get; set; }

        internal double SubtitleHeight { get; set; }

        internal double HeaderHeight { get; set; }

        internal bool HeaderIncludesFootnoteRow { get; set; }

        internal double ColumnWidth { get; set; }

        internal LocationBoxDimensions MainSectionMetrics { get; set; }

        internal double ToWorkHeight { get; set; }

        internal double LocoToWorkHeight { get; set; }

        internal double TotalHeight => TitleHeight + SubtitleHeight + TableHeight + LineWidth;

        internal double TableHeight => HeaderHeight + MainSectionMetrics.TotalSize.Height + ToWorkHeight + LocoToWorkHeight;

        internal double HeaderOffset => TitleHeight + SubtitleHeight;

        internal double MainSectionOffset => TitleHeight + SubtitleHeight + HeaderHeight;

        internal double ToWorkOffset => TitleHeight + SubtitleHeight + HeaderHeight + MainSectionMetrics.TotalSize.Height;

        internal double MainSectionBoundingHeight => SubtitleHeight + HeaderHeight + MainSectionMetrics.TotalSize.Height + ToWorkHeight + LocoToWorkHeight;

        internal bool IncludeLocoDiagramRow { get; set; }

        internal bool IncludeToWorkRow { get; set; }

        internal bool IncludeLocoToWorkRow { get; set; }

        internal SectionMetrics(double lineWidth)
        {
            LineWidth = lineWidth;
        }

        internal SectionMetrics CopyWithNoTitle()
        {
            return new SectionMetrics(LineWidth)
            {
                TitleHeight = 0,
                SubtitleHeight = 0,
                HeaderHeight = HeaderHeight,
                ColumnWidth = ColumnWidth,
                MainSectionMetrics = MainSectionMetrics,
                IncludeLocoDiagramRow = IncludeLocoDiagramRow,
                IncludeToWorkRow = IncludeToWorkRow,
                ToWorkHeight = ToWorkHeight,
                IncludeLocoToWorkRow = IncludeLocoToWorkRow,
                LocoToWorkHeight = LocoToWorkHeight,
                HeaderIncludesFootnoteRow = HeaderIncludesFootnoteRow,
            };
        }
    }
}
