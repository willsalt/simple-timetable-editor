using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Save.Xml
{
    /// <summary>
    /// Extension methods for converting a <see cref="TrainTime"/> instance into serialisable form.
    /// </summary>
    public static class TrainTimeExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainTime"/> instance into a <see cref="TrainTimeModel"/> instance.
        /// </summary>
        /// <param name="time">The object to convert.</param>
        /// <returns>A <see cref="TrainTimeModel"/> instance containing the same data as the parameter.</returns>
        public static TrainTimeModel ToTrainTimeModel(this TrainTime time)
        {
            TrainTimeModel model = new TrainTimeModel
            {
                Time = time.Time?.ToTimeOfDayModel(),
            };

            model.FootnoteIds.AddRange(time.Footnotes.Select(n => n.Id));

            return model;
        }
    }
}
