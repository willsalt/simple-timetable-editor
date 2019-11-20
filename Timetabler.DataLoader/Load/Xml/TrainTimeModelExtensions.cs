using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Extension methods for loading <see cref="TrainTime"/> objects from serializable form into in-memory form.
    /// </summary>
    public static class TrainTimeModelExtensions
    {
        /// <summary>
        /// Convert a serializable <see cref="TrainTimeModel"/> object into a <see cref="TrainTime"/> object.
        /// </summary>
        /// <param name="model">The object to load.</param>
        /// <param name="notes">Dictionary of footnotes occurring in the timetable.</param>
        /// <returns>A <see cref="TrainTime"/> instance.</returns>
        public static TrainTime ToTrainTime(this TrainTimeModel model, Dictionary<string, Note> notes)
        {
            TrainTime tt = new TrainTime { Time = model.Time?.ToTimeOfDay() };
            
            foreach (string noteId in model.FootnoteIds)
            {
                tt.Footnotes.Add(notes?[noteId]);
            }

            return tt;
        }
    }
}
