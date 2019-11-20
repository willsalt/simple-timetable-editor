using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for serialising <see cref="Location"/> objects.
    /// </summary>
    public static class LocationExtensions
    {
        /// <summary>
        /// Convert a <see cref="Location"/> instance to a <see cref="LocationModel"/> instance.
        /// </summary>
        /// <param name="location">The data to convert.</param>
        /// <returns>A <see cref="LocationModel"/> instance representing the location parameter.</returns>
        public static LocationModel ToLocationModel(this Location location)
        {
            // == is overloaded so does not compare as expected against null - it can return equal to null for a non-null object.
            if (location is null)
            {
                return null;
            }

            return new LocationModel
            {
                Id = location.Id,
                EditorDisplayName = location.EditorDisplayName,
                TimetableDisplayName = location.TimetableDisplayName,
                GraphDisplayName = location.GraphDisplayName,
                Tiploc = location.Tiploc,
                UpArrivalDepartureAlwaysDisplayed = location.UpArrivalDepartureAlwaysDisplayed,
                UpRoutingCodesAlwaysDisplayed = location.UpRoutingCodesAlwaysDisplayed,
                DownArrivalDepartureAlwaysDisplayed = location.DownArrivalDepartureAlwaysDisplayed,
                DownRoutingCodesAlwaysDisplayed = location.DownRoutingCodesAlwaysDisplayed,
                Mileage = location.Mileage?.ToDistanceModel(),
                FontTypeName = location.FontType.ToString("g"),
                DisplaySeparatorAbove = location.DisplaySeparatorAbove,
                DisplaySeparatorBelow = location.DisplaySeparatorBelow,
            };
        }
    }
}
