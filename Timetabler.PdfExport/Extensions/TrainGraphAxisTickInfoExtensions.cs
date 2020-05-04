using System;
using Timetabler.Data.Display;
using Unicorn.Interfaces;

namespace Timetabler.PdfExport.Extensions
{
    /// <summary>
    /// Extensions methods for the <see cref="TrainGraphAxisTickInfo" /> class.
    /// </summary>
    public static class TrainGraphAxisTickInfoExtensions
    {
        /// <summary>
        /// Populate the <see cref="TrainGraphAxisTickInfo.Width" /> and <see cref="TrainGraphAxisTickInfo.Height" /> properties of a 
        /// <see cref="TrainGraphAxisTickInfo" /> object by measuring its <see cref="TrainGraphAxisTickInfo.Label" /> property with a given 
        /// <see cref="IGraphicsContext" /> and <see cref="IFontDescriptor" />.
        /// </summary>
        /// <param name="tickInfo">A <see cref="TrainGraphAxisTickInfo" /> object to be measured.</param>
        /// <param name="context">The <see cref="IGraphicsContext" /> to use for measuring.</param>
        /// <param name="font">The <see cref="IFontDescriptor" /> to use for measuring.</param>
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
