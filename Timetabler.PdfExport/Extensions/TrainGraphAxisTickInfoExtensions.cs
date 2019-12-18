using System;
using Timetabler.Data.Display;
using Unicorn.Interfaces;

namespace Timetabler.PdfExport.Extensions
{
    public static class TrainGraphAxisTickInfoExtensions
    {
        public static void PopulateSize(this TrainGraphAxisTickInfo tickInfo, IGraphicsContext context, IFontDescriptor font)
        {
            if (tickInfo is null)
            {
                throw new ArgumentNullException(nameof(tickInfo));
            }
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            UniSize measure = context.MeasureString(tickInfo.Label, font);
            tickInfo.Width = measure.Width;
            tickInfo.Height = measure.Height;
        }
    }
}
