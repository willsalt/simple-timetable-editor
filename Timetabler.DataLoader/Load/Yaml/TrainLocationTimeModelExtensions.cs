using System;
using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    /// <summary>
    /// Extension methods for the <see cref="TrainLocationTimeModel" /> class.
    /// </summary>
    public static class TrainLocationTimeModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainLocationTimeModel" /> instance to a <see cref="TrainLocationTime" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <param name="locations">A dictionary of known locations, to use to resolve the location reference in the model.</param>
        /// <param name="notes">A dictionary of known footnotes, to use to resolve any footnote references in the model.</param>
        /// <param name="options">Document options to use to determine how to format strings.</param>
        /// <returns>A <see cref="TrainLocationTime" /> object containing the same data as the <c>model</c> parameter, with ID references resolved.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <c>model</c> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the <c>options</c> parameter is <c>null</c>.</exception>
        public static TrainLocationTime ToTrainLocationTime(
            this TrainLocationTimeModel model,
            Dictionary<string, Location> locations,
            Dictionary<string, Note> notes,
            DocumentOptions options)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            TrainLocationTime output = new TrainLocationTime
            {
                Pass = model.Pass ?? false,
                ArrivalTime = model.Arrival?.ToTrainTime(notes),
                DepartureTime = model.Departure?.ToTrainTime(notes),
                Path = model.Path,
                Platform = model.Platform,
                Line = model.Line,
                FormattingStrings = options.FormattingStrings,
            };

            if (model.LocationId != null && locations != null && locations.ContainsKey(model.LocationId))
            {
                output.Location = locations[model.LocationId];
            }

            return output;
        }
    }
}
