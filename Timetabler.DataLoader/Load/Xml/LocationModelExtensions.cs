using System;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Extension class for converting <see cref="LocationModel"/> instances to <see cref="Location"/> instances.
    /// </summary>
    public static class LocationModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="LocationModel"/> to a <see cref="Location"/>.
        /// </summary>
        /// <param name="model">The model to be converted.</param>
        /// <returns>A <see cref="Location"/> instance containing the same data as the model.</returns>
        public static Location ToLocation(this LocationModel model)
        {
            if (model == null)
            {
                return null;
            }

            Location loc = new Location
            {
                Id = model.Id,
                EditorDisplayName = model.EditorDisplayName,
                TimetableDisplayName = model.TimetableDisplayName,
                GraphDisplayName = model.GraphDisplayName,
                Tiploc = model.Tiploc,
                UpArrivalDepartureAlwaysDisplayed = model.UpArrivalDepartureAlwaysDisplayed,
                UpRoutingCodesAlwaysDisplayed = model.UpRoutingCodesAlwaysDisplayed ?? 0,
                DownArrivalDepartureAlwaysDisplayed = model.DownArrivalDepartureAlwaysDisplayed,
                DownRoutingCodesAlwaysDisplayed = model.DownRoutingCodesAlwaysDisplayed ?? 0,
                Mileage = model.Mileage.ToDistance(),
                DisplaySeparatorAbove = model.DisplaySeparatorAbove ?? false,
                DisplaySeparatorBelow = model.DisplaySeparatorBelow ?? false,
            };

            if (!string.IsNullOrWhiteSpace(model.FontTypeName) && Enum.TryParse(model.FontTypeName, out LocationFontType lft))
            {
                loc.FontType = lft;
            }

            return loc;
        }
    }
}
