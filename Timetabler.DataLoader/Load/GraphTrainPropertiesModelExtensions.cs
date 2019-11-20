using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Class for loading a <see cref="GraphTrainProperties"/> object from serialised form into memory.
    /// </summary>
    public static class GraphTrainPropertiesModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="GraphTrainPropertiesModel"/> object into a <see cref="GraphTrainProperties"/> object.
        /// </summary>
        /// <param name="model">The data to be converted.</param>
        /// <returns>The <see cref="GraphTrainProperties"/> instance.</returns>
        public static GraphTrainProperties ToGraphTrainProperties(this GraphTrainPropertiesModel model)
        {
            if (model == null)
            {
                return null;
            }

            GraphTrainProperties gtp = new GraphTrainProperties { Width = model.Width };

            if (int.TryParse(model.ColourCode, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int col))
            {
                gtp.Colour = Color.FromArgb(col);
            }

            if (Enum.TryParse(model.DashStyleName, out DashStyle style))
            {
                gtp.DashStyle = style;
            }

            return gtp;
        }
    }
}
