using System.Globalization;
using Timetabler.CoreData;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="TimeOfDay" /> class.
    /// </summary>
    public static class TimeOfDayExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimeOfDay" /> instance to a <see cref="TimeOfDayModel" /> instance.
        /// </summary>
        /// <param name="tod">The object to convert.</param>
        /// <returns>A <see cref="TimeOfDayModel" /> instance containing the same data as the parameter, or <c>null</c> if the parameter is <c>null</c>.</returns>
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
