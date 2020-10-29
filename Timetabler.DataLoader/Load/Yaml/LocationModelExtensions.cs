using System;
using System.Collections.Generic;
using Timetabler.CoreData;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    /// <summary>
    /// Extension methods for the <see cref="LocationModel" /> class.
    /// </summary>
    public static class LocationModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="LocationModel" /> instance to a <see cref="Location" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A <see cref="Location" /> object containing the same data as the parameter.</returns>
        public static Location ToLocation(this LocationModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }
            if (string.IsNullOrWhiteSpace(model.Id))
            {
                throw new ArgumentException("ID missing");
            }

            Location loc = new Location
            {
                Id = model.Id,
                EditorDisplayName = model.EditorDisplayName,
                TimetableDisplayName = model.TimetableDisplayName,
                GraphDisplayName = model.GraphDisplayName,
                Tiploc = model.LocationCode,
                UpArrivalDepartureAlwaysDisplayed = model.UpArrivalDepartureAlwaysDisplayed ?? 0,
                UpRoutingCodesAlwaysDisplayed = model.UpRoutingCodesAlwaysDisplayed ?? 0,
                DownArrivalDepartureAlwaysDisplayed = model.DownArrivalDepartureAlwaysDisplayed ?? 0,
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
