using System.Drawing;
using Timetabler.Data.Display;

namespace Timetabler.Extensions
{
    /// <summary>
    /// Extensions for train graph axis tick information objects.
    /// </summary>
    public static class TrainGraphAxisTickInfoExtensions
    {
        /// <summary>
        /// Populate the <see cref="TrainGraphAxisTickInfo.Width"/> and <see cref="TrainGraphAxisTickInfo.Height"/> properties.
        /// </summary>
        /// <param name="tickInfo">The tick object to populate.</param>
        /// <param name="graphicsContext">The <see cref="Graphics"/> object used to measure the tick's label.</param>
        /// <param name="font">The font used to measure the tick's label.</param>
        public static void PopulateSize(this TrainGraphAxisTickInfo tickInfo, Graphics graphicsContext, Font font)
        {
            SizeF size = graphicsContext.MeasureString(tickInfo.Label, font);
            tickInfo.Width = size.Width;
            tickInfo.Height = size.Height;
        }
    }
}
