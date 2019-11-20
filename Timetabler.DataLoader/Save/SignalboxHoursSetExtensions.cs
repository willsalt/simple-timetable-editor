using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for saving <see cref="SignalboxHoursSet" /> instances in a serialisable form.
    /// </summary>
    public static class SignalboxHoursSetExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxHoursSet" /> instance into a <see cref="SignalboxHoursSetModel" /> instance.
        /// </summary>
        /// <param name="hoursSet">The data to be converted.</param>
        /// <returns>A <see cref="SignalboxHoursSetModel" /> instance that is equivalent to the hoursSet parameter.</returns>
        public static SignalboxHoursSetModel ToSignalboxHoursSetModel(this SignalboxHoursSet hoursSet)
        {
            return new SignalboxHoursSetModel
            {
                Category = hoursSet.Category,
                Signalboxes = hoursSet.Hours.Values.Select(h => h.ToSignalboxHoursModel()).ToList(),
            };
        }
    }
}
