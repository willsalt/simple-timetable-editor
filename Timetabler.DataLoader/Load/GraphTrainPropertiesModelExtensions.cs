using System;
using System.Globalization;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extensions methods for the <see cref="GraphTrainPropertiesModel" /> class.
    /// </summary>
    public static class GraphTrainPropertiesModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="GraphTrainPropertiesModel" /> instance to a <see cref="GraphTrainProperties" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A <see cref="GraphTrainProperties" /> instance containing the same data as the original object.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static GraphTrainProperties ToGraphTrainProperties(this GraphTrainPropertiesModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            GraphTrainProperties gtp = new GraphTrainProperties { Width = model.Width ?? 1f };

            if (uint.TryParse(model.Colour, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out uint col))
            {
                gtp.Colour = new Colour(col);
            }

            if (Enum.TryParse(model.DashStyleName, out DashStyle style))
            {
                gtp.DashStyle = style;
            }

            return gtp;
        }
    }
}
