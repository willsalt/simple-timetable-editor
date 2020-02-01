using System;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    /// <summary>
    /// Extension methods for YAML-specific serialisation of the <see cref="Distance" /> class.
    /// </summary>
    public static class DistanceExtensions
    {
        /// <summary>
        /// Convert a <see cref="Distance" /> instance to a <see cref="DistanceModel" /> instance.
        /// </summary>
        /// <param name="distance">The object to be converted.</param>
        /// <returns>A <see cref="DistanceModel" /> instance encoding the same distance as the original object.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <c>this</c> parameter is <c>null</c>.</exception>
        public static DistanceModel ToYamlDistanceModel(this Distance distance)
        {
            if (distance is null)
            {
                throw new NullReferenceException();
            }

            return new DistanceModel { Miles = distance.Mileage, Chains = distance.Chainage };
        }
    }
}
