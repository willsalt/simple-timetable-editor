using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class LocationExtensions
    {
        public static LocationModel ToYamlLocationModel(this Location location)
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
                Mileage = location.Mileage?.ToYamlDistanceModel(),
                FontTypeName = location.FontType.ToString("g"),
                DisplaySeparatorAbove = location.DisplaySeparatorAbove,
                DisplaySeparatorBelow = location.DisplaySeparatorBelow,
            };
        }
    }
}
