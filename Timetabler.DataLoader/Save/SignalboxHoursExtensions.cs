﻿using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="SignalboxHours" /> class.
    /// </summary>
    public static class SignalboxHoursExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxHours" /> instance to a <see cref="SignalboxHoursModel" /> instance.
        /// </summary>
        /// <param name="hours">The object to be converted.</param>
        /// <returns>A <see cref="SignalboxHoursModel" /> instance containing the same data as the parameter in serialisable form.</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter is <c>null</c>.</exception>
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
