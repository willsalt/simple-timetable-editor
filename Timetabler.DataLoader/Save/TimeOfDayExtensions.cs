using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for converting a <see cref="TimeOfDay"/> object into serializable form.
    /// </summary>
    public static class TimeOfDayExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimeOfDay"/> instance into a <see cref="TimeOfDayModel"/> instance.
        /// </summary>
        /// <param name="time">The object to be converted.</param>
        /// <returns>A <see cref="TimeOfDayModel"/> instance containing the same data as the parameter.</returns>
        public static TimeOfDayModel ToTimeOfDayModel(this TimeOfDay time)
        {
            if (time == null)
            {
                return null;
            }

            return new TimeOfDayModel
            {
                Hours24 = time.Hours24,
                Minutes = time.Minutes,
                Seconds = time.Seconds,
            };
        }
    }
}
