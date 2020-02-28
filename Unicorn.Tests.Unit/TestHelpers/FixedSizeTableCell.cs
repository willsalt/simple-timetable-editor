using Unicorn.Interfaces;

namespace Unicorn.Tests.Unit.TestHelpers
{
    internal class FixedSizeTableCell : TableCell
    {
        internal double Width { get; private set; }

        internal double Height { get; private set; }

        internal FixedSizeTableCell(double width, double height)
        {
            Width = width;
            Height = height;
            MeasureSize(null);
        }

        public override void DrawContentsAt(IGraphicsContext context, double x, double y)
        {
        }

        public override void MeasureSize(IGraphicsContext context)
        {
            ContentWidth = Width;
            ContentAscent = Height / 2;
            ContentDescent = Height / 2;
        }
    }
}
