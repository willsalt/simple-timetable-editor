using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for loading the <see cref="SignalboxHoursModel" /> class into memory.
    /// </summary>
    public static class SignalboxHoursModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxHoursModel" /> instance into a <see cref="SignalboxHours" /> instance.
        /// </summary>
        /// <param name="model">The data to be converted.</param>
        /// <param name="signalboxes">A dictionary of signalboxes, for mapping signalbox IDs to <see cref="Signalbox" /> objects.</param>
        /// <returns>A <see cref="SignalboxHours" /> instance whose contents match those of the model parameter.</returns>
        public static SignalboxHours ToSignalboxHours(this SignalboxHoursModel model, IDictionary<string, Signalbox> signalboxes)
        {
            return new SignalboxHours
            {
                Signalbox = signalboxes.ContainsKey(model.SignalboxId) ? signalboxes[model.SignalboxId] : null,
                EndTime = model.FinishTime.ToTimeOfDay(),
                StartTime = model.StartTime.ToTimeOfDay(),
                TokenBalanceWarning = model.TokenBalanceWarning,
            };
        }
    }
}
