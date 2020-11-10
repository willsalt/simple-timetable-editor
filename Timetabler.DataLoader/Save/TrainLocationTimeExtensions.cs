using System;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    /// <summary>
    /// YAML-related extension methods for <see cref="TrainLocationTime" /> class.
    /// </summary>
    public static class TrainLocationTimeExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainLocationTime" /> instance to a <see cref="TrainLocationTimeModel" /> instance.
        /// </summary>
        /// <param name="tlt">The object to be converted.</param>
        /// <returns>A <see cref="TrainLocationTimeModel" /> instance containing the same data as the parameter in serialisable form.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static TrainLocationTimeModel ToYamlTrainLocationTimeModel(this TrainLocationTime tlt)
        {
            if (tlt is null)
            {
                throw new NullReferenceException();
            }

            return new TrainLocationTimeModel
            {
                Arrival = tlt.ArrivalTime.ToYamlTrainTimeModel(),
                Departure = tlt.DepartureTime.ToYamlTrainTimeModel(),
                LocationId = tlt.Location.Id,
                Pass = tlt.Pass,
                Platform = tlt.Platform,
                Path = tlt.Path,
                Line = tlt.Line,
            };
        }
    }
}
