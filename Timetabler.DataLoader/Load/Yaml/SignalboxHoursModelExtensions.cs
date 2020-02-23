using System;
using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    /// <summary>
    /// Extension methods for the <see cref="SignalboxHoursModel" /> class.
    /// </summary>
    public static class SignalboxHoursModelExtensions
    {
        /// <summary>
        /// Converts a <see cref="SignalboxHoursModel" /> instance into a <see cref="SignalboxHours" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <param name="signalboxes">A dictionary of known signalboxes, to convert the signalbox ID into a reference.</param>
        /// <returns>A <see cref="SignalboxHours" /> instance.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <c>this</c> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the <c>signalboxes</c> parameter is <c>null</c>.</exception>
        public static SignalboxHours ToSignalboxHours(this SignalboxHoursModel model, IDictionary<string, Signalbox> signalboxes)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }
            if (signalboxes is null)
            {
                throw new ArgumentNullException(nameof(signalboxes));
            }

            return new SignalboxHours
            {
                Signalbox = signalboxes.ContainsKey(model.SignalboxId) ? signalboxes[model.SignalboxId] : null,
                EndTime = model.FinishTime.ToTimeOfDay(),
                StartTime = model.StartTime.ToTimeOfDay(),
                TokenBalanceWarning = model.TokenBalanceWarning ?? false,
            };
        }
    }
}
