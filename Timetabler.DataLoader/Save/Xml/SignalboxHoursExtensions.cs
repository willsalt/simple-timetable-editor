using System;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Save.Xml
{
    /// <summary>
    /// Extension methods for saving <see cref="SignalboxHours" /> instances to serialisable form.
    /// </summary>
    public static class SignalboxHoursExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxHours" /> instance into a <see cref="SignalboxHoursModel" /> instance.
        /// </summary>
        /// <param name="hours">The data to be converted.</param>
        /// <returns>A <see cref="SignalboxHoursModel" /> instance that is equivalent to the hours parameter.</returns>
        public static SignalboxHoursModel ToSignalboxHoursModel(this SignalboxHours hours)
        {
            if (hours is null)
            {
                throw new ArgumentNullException(nameof(hours));
            }

            return new SignalboxHoursModel
            {
                SignalboxId = hours.Signalbox?.Id,
                FinishTime = hours.EndTime.ToTimeOfDayModel(),
                StartTime = hours.StartTime.ToTimeOfDayModel(),
                TokenBalanceWarning = hours.TokenBalanceWarning,
            };
        }
    }
}
