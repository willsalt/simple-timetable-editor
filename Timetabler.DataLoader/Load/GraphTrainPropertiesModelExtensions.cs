using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using Timetabler.Data;
using Timetabler.XmlData;

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

            int col;
            if (int.TryParse(model.ColourCode, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out col))
            {
                gtp.Colour = Color.FromArgb(col);
            }

            DashStyle style;
            if (Enum.TryParse(model.DashStyleName, out style))
            {
                gtp.DashStyle = style;
            }

            return gtp;
        }
    }
}
