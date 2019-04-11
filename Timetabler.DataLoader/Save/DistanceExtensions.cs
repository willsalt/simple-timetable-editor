using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for saving serializable <see cref="Distance"/> objects into in-memory form.
    /// </summary>
    public static class DistanceExtensions
    {
        /// <summary>
        /// Convert a <see cref="Distance"/> object into a <see cref="DistanceModel"/> object.
        /// </summary>
        /// <param name="distance">The object to convert.</param>
        /// <returns>A <see cref="DistanceModel"/> object representing the distance parameter.</returns>
        public static DistanceModel ToDistanceModel(this Distance distance)
        {
            return new DistanceModel
            {
                Mileage = distance.Mileage,
                Chainage = distance.Chainage
            };
        }
    }
}
