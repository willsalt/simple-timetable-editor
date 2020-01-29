using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class LocationModelExtensions
    {
        public static Location ToLocation(this LocationModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
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
