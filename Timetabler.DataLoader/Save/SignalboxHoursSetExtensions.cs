using System;
using System.Linq;
using Timetabler.CoreData.Extensions;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="SignalboxHoursSet" /> class.
    /// </summary>
    public static class SignalboxHoursSetExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxHoursSet" /> instance to a <see cref="SignalboxHoursSetModel" /> instance.
        /// </summary>
        /// <param name="set">The object to convert.</param>
        /// <returns>A <see cref="SignalboxHoursSetModel" /> instance containing the same data as the parameter in serialisable form.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is <c>null</c>.</exception>
        public static SignalboxHoursSetModel ToSignalboxHoursSetModel(this SignalboxHoursSet set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set));
            }

            SignalboxHoursSetModel shsm = new SignalboxHoursSetModel
            {
                Category = set.Category,
            };
            shsm.Signalboxes.AddRange(set.Hours.Values.Select(h => h.ToSignalboxHoursModel()));
            return shsm;
        }
    }
}
