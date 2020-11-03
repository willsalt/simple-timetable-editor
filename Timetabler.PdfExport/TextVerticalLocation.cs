namespace Timetabler.PdfExport
{
    internal class TextVerticalLocation
    {
        internal double ClearanceTop { get; private set; }

        internal double Top { get; private set; }

        internal double Baseline { get; private set; }

        internal double TextMidLine => (Bottom + Top) / 2;

        internal double TextBodyMidLine => (Baseline + Top) / 2;

        internal double Bottom { get; private set; }

        internal double ClearanceBottom { get; private set; }

        internal double ClearanceHeight => ClearanceBottom - ClearanceTop;

        internal TextVerticalLocation(double clearTop, double top, double baseline, double bottom, double clearBottom)
        {
            ClearanceTop = clearTop;
            Top = top;
            Baseline = baseline;
            Bottom = bottom;
            ClearanceBottom = clearBottom;
        }
    }
}
