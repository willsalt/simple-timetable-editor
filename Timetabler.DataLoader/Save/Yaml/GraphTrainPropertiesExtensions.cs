using System;
using System.Drawing.Drawing2D;
using System.Globalization;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
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
        public static GraphTrainPropertiesModel ToYamlGraphTrainPropertiesModel(this GraphTrainProperties properties)
        {
            if (properties is null)
            {
                throw new NullReferenceException();
            }

            return new GraphTrainPropertiesModel
            {
                Colour = properties.Colour.ToArgb().ToString("X8", CultureInfo.InvariantCulture),
                DashStyleName = Enum.GetName(typeof(DashStyle), properties.DashStyle),
                Width = properties.Width,
            };
        }
    }
}
