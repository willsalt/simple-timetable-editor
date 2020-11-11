using System;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="TrainTime" /> class.
    /// </summary>
    public static class TrainTimeExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainTime" /> instance to a <see cref="TrainTimeModel" /> instance.
        /// </summary>
        /// <param name="tt">The object to convert.</param>
        /// <returns>A <see cref="TrainTimeModel" /> instance containing the same data as the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        public static TrainTimeModel ToTrainTimeModel(this TrainTime tt)
        {
            if (tt is null)
            {
                throw new NullReferenceException();
            }

            TrainTimeModel model = new TrainTimeModel
            {
                At = tt.Time?.ToTimeOfDayModel(),
            };

            model.FootnoteIds.AddRange(tt.Footnotes.Select(n => n.Id));

            return model;
        }
    }
}
