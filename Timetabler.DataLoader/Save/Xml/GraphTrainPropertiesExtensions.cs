using System;
using System.Drawing.Drawing2D;
using System.Globalization;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Save.Xml
{
    /// <summary>
    /// Extension methos for loading a <see cref="GraphTrainProperties"/> object from serializable form.
    /// </summary>
    public static class GraphTrainPropertiesExtensions
    {
        /// <summary>
        /// Convert a <see cref="GraphTrainPropertiesModel"/> instance into a <see cref="GraphTrainProperties"/> instance.
        /// </summary>
        /// <param name="gtp">The model object to load.</param>
        /// <returns>A <see cref="GraphTrainProperties"/> instance containing the same data as the model.</returns>
        public static GraphTrainPropertiesModel ToGraphTrainPropertiesModel(this GraphTrainProperties gtp)
        {
            if (gtp is null)
            {
                throw new ArgumentNullException(nameof(gtp));
            }

            return new GraphTrainPropertiesModel
            {
                ColourCode = gtp.Colour.ToArgb().ToString("X8", CultureInfo.InvariantCulture),
                DashStyleName = Enum.GetName(typeof(DashStyle), gtp.DashStyle),
                Width = gtp.Width,
            };
        }
    }
}
