using System;
using System.Collections.Generic;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Extension methods for loading the <see cref="SignalboxHoursSetModel" /> class.
    /// </summary>
    public static class SignalboxHoursSetModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxHoursSetModel" /> instance into a <see cref="SignalboxHoursSet" /> instance.
        /// </summary>
        /// <param name="model">The data to be converted.</param>
        /// <param name="signalboxes">A dictionary of signalboxes, for mapping signalbox IDs to <see cref="Signalbox" /> instances.</param>
        /// <param name="existingSets">Existing <see cref="SignalboxHoursSet" /> instances, to ensure any newly-created IDs are unique.</param>
        /// <returns>A <see cref="SignalboxHoursSet" /> instance.</returns>
        public static SignalboxHoursSet ToSignalboxHoursSet(this SignalboxHoursSetModel model, IDictionary<string, Signalbox> signalboxes, IEnumerable<SignalboxHoursSet> existingSets)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            SignalboxHoursSet hoursSet = new SignalboxHoursSet { Id = GeneralHelper.GetNewId(existingSets), Category = model.Category };
            foreach (SignalboxHoursModel hoursModel in model.Signalboxes)
            {
                SignalboxHours hours = hoursModel.ToSignalboxHours(signalboxes);
                hoursSet.Hours.Add(hours.Signalbox.Id, hours);
            }
            return hoursSet;
        }
    }
}
