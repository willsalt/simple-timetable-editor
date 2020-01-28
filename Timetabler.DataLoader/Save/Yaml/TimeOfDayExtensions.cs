using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.CoreData;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class TimeOfDayExtensions
    {
        public static TimeOfDayModel ToYamlTimeOfDayModel(this TimeOfDay tod)
        {
            if (tod is null)
            {
                return null;
            }

            return new TimeOfDayModel
            {
                Time = string.Format(CultureInfo.InvariantCulture, "{0}:{1}:{2}", tod.Hours24, tod.Minutes, tod.Seconds)
            };
        }
    }
}
