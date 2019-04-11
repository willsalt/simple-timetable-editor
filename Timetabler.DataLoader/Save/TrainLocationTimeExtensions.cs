using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for converting <see cref="TrainLocationTime"/> instances into serialisable form.
    /// </summary>
    public static class TrainLocationTimeExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainLocationTime"/> instance into a <see cref="TrainLocationTimeModel"/> instance.
        /// </summary>
        /// <param name="tlt">The instance to be converted.</param>
        /// <returns>A <see cref="TrainLocationTimeModel"/> instance containing the same data as the parameter.</returns>
        public static TrainLocationTimeModel ToTrainLocationTimeModel(this TrainLocationTime tlt)
        {
            return new TrainLocationTimeModel
            {
                ArrivalTime = tlt.ArrivalTime.ToTrainTimeModel(),
                DepartureTime = tlt.DepartureTime.ToTrainTimeModel(),
                LocationId = tlt.Location.Id,
                Pass = tlt.Pass,
                Platform = tlt.Platform,
                Path = tlt.Path,
                Line = tlt.Line,
            };
        }
    }
}
