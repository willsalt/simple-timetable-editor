using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.CoreData;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class TimeOfDayModelExtensions
    {
        public static TimeOfDay ToTimeOfDay(this TimeOfDayModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(model.Time))
            {
                throw new FormatException("Empty time of day could not be parsed.");
            }
            string[] parts = model.Time.Split(':');
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            try
            {
                if (parts.Length > 0)
                {
                    hours = int.Parse(parts[0], CultureInfo.InvariantCulture);
                }
                if (parts.Length > 1)
                {
                    minutes = int.Parse(parts[1], CultureInfo.InvariantCulture);
                }
                if (parts.Length > 2)
                {
                    seconds = int.Parse(parts[2], CultureInfo.InvariantCulture);
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Time of day could not be parsed.", ex);
            }
            catch (OverflowException ex)
            {
                throw new FormatException("Time of day could not be parsed.", ex);
            }

            return new TimeOfDay(hours, minutes, seconds);
        }
    }
}
