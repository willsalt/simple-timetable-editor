using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Data.Display;

namespace Timetabler.PdfExport
{
    internal class TimetableExportSection
    {
        internal Direction Direction { get; private set; }

        internal TimetableSectionModel SectionData { get; private set; }

        internal string Label { get; private set; }

        internal TimetableExportSection(Direction dir, TimetableSectionModel data, string label)
        {
            Direction = dir;
            SectionData = data;
            Label = label;
        }

        internal static TimetableExportSection FromDocument(TimetableDocument document, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                default:
                    return new TimetableExportSection(direction, document.DownTrainsDisplay, document.ExportOptions.DownSectionLabel);
                case Direction.Up:
                    return new TimetableExportSection(direction, document.UpTrainsDisplay, document.ExportOptions.UpSectionLabel);
            }
        }
    }
}
