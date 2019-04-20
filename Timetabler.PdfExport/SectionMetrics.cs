namespace Timetabler.PdfExport
{
    internal class SectionMetrics
    {
        internal double TitleHeight { get; set; }

        internal double SubtitleHeight { get; set; }

        internal double HeaderHeight { get; set; }

        internal bool HeaderIncludesFootnoteRow { get; set; }

        internal double ColumnWidth { get; set; }

        internal LocationBoxDimensions MainSectionMetrics { get; set; }

        internal double ToWorkHeight { get; set; }

        internal double LocoToWorkHeight { get; set; }

        internal double TotalHeight { get { return TitleHeight + SubtitleHeight + TableHeight; } }

        internal double TableHeight { get { return HeaderHeight + MainSectionMetrics.TotalSize.Height + ToWorkHeight + LocoToWorkHeight; } }

        internal double HeaderOffset { get { return TitleHeight + SubtitleHeight; } }

        internal double MainSectionOffset { get { return TitleHeight + SubtitleHeight + HeaderHeight; } }

        internal double ToWorkOffset { get { return TitleHeight + SubtitleHeight + HeaderHeight + MainSectionMetrics.TotalSize.Height; } }

        internal double MainSectionBoundingHeight { get { return SubtitleHeight + HeaderHeight + MainSectionMetrics.TotalSize.Height + ToWorkHeight + LocoToWorkHeight; } }

        internal bool IncludeLocoDiagramRow { get; set; }

        internal bool IncludeToWorkRow { get; set; }

        internal bool IncludeLocoToWorkRow { get; set; }

        internal SectionMetrics CopyWithNoTitle()
        {
            return new SectionMetrics
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
