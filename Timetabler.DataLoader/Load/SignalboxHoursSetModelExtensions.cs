using System;
using System.Collections.Generic;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for the <see cref="SignalboxHoursSetModel" /> class.
    /// </summary>
    public static class SignalboxHoursSetModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxHoursSetModel" /> instance to a <see cref="SignalboxHoursSet" /> instance.
        /// </summary>
        /// <param name="model">The object to convert.</param>
        /// <param name="signalboxes">A dictionary of known signalboxes, for resolving references.</param>
        /// <param name="existingSets">An enumeration of existing signalbox hours sets, to ensure this routine does not duplicate the ID of an existing set.</param>
        /// <returns>A <see cref="SignalboxHoursSet" /> containing the same data as the <c>model</c> parameter with references resolved.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>model</c> parameter is <c>null</c> or if the <c>signalboxes</c> or <c>existingSets</c> 
        /// parameters are <c>null</c>.</exception>
        public static SignalboxHoursSet ToSignalboxHoursSet(
            this SignalboxHoursSetModel model, 
            IDictionary<string, Signalbox> signalboxes, 
            IEnumerable<SignalboxHoursSet> existingSets)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (signalboxes is null)
            {
                throw new ArgumentNullException(nameof(signalboxes));
            }
            if (existingSets is null)
            {
                throw new ArgumentNullException(nameof(existingSets));
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
