﻿using System;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
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
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static SignalboxHoursSetModel ToYamlSignalboxHoursSetModel(this SignalboxHoursSet set)
        {
            if (set is null)
            {
                throw new NullReferenceException();
            }

            SignalboxHoursSetModel shsm = new SignalboxHoursSetModel
            {
                Category = set.Category,
            };
            shsm.Signalboxes.AddRange(set.Hours.Values.Select(h => h.ToYamlSignalboxHoursModel()));
            return shsm;
        }
    }
}
