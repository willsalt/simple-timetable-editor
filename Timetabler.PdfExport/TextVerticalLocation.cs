namespace Timetabler.PdfExport
{
    internal class TextVerticalLocation
    {
        internal double Top { get; set; }

        internal double Baseline { get; set; }

        internal double TextMidLine { get { return (Bottom + Top) / 2; } }

        internal double Bottom { get; set; }
    }
}
