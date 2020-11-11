using System;
using System.Globalization;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="GraphTrainProperties" /> class.
    /// </summary>
    public static class GraphTrainPropertiesExtensions
    {
        /// <summary>
        /// Converts a <see cref="GraphTrainProperties" /> instance to a <see cref="GraphTrainPropertiesModel" /> instance.
        /// </summary>
        /// <param name="properties">The object to be converted.</param>
        /// <returns>A <see cref="GraphTrainPropertiesModel" /> instance containing the same data in serialisable form.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static GraphTrainPropertiesModel ToGraphTrainPropertiesModel(this GraphTrainProperties properties)
        {
            if (properties is null)
            {
                throw new NullReferenceException();
            }

            return new GraphTrainPropertiesModel
            {
                Colour = properties.Colour.Argb.ToString("X8", CultureInfo.InvariantCulture),
                DashStyleName = Enum.GetName(typeof(DashStyle), properties.DashStyle),
                Width = properties.Width,
            };
        }
    }
}
