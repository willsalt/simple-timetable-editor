using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="Location" /> class.
    /// </summary>
    public static class LocationExtensions
    {
        /// <summary>
        /// Converts a <see cref="Location" /> instance to a <see cref="LocationModel" /> instance.
        /// </summary>
        /// <param name="location">The object to be converted.</param>
        /// <returns>A <see cref="LocationModel" /> instance containing the same data in serialisable form, or <c>null</c> if the parameter is <c>null</c>.</returns>
        public static LocationModel ToLocationModel(this Location location)
        {
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
                LocationCode = location.Tiploc,
                UpArrivalDepartureAlwaysDisplayed = location.UpArrivalDepartureAlwaysDisplayed,
                UpRoutingCodesAlwaysDisplayed = location.UpRoutingCodesAlwaysDisplayed,
                DownArrivalDepartureAlwaysDisplayed = location.DownArrivalDepartureAlwaysDisplayed,
                DownRoutingCodesAlwaysDisplayed = location.DownRoutingCodesAlwaysDisplayed,
                Mileage = location.Mileage.ToDistanceModel(),
                FontTypeName = location.FontType.ToString("g"),
                DisplaySeparatorAbove = location.DisplaySeparatorAbove,
                DisplaySeparatorBelow = location.DisplaySeparatorBelow,
            };
        }
    }
}
