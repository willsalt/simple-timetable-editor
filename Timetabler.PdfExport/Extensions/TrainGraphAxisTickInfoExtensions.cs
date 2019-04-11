using Timetabler.Data.Display;
using Unicorn.Interfaces;

namespace Timetabler.PdfExport.Extensions
{
    public static class TrainGraphAxisTickInfoExtensions
    {
        public static void PopulateSize(this TrainGraphAxisTickInfo tickInfo, IGraphicsContext context, IFontDescriptor font)
        {
            UniSize measure = context.MeasureString(tickInfo.Label, font);
            tickInfo.Width = measure.Width;
            tickInfo.Height = measure.Height;
        }
    }
}
