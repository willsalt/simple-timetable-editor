using System;
using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for the <see cref="TrainTimeModel" /> class.
    /// </summary>
    public static class TrainTimeModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainTimeModel" /> instance to a <see cref="TrainTime" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <param name="notes">A dictionary of known footnotes, used to resolve ID-based references to footnotes in the model.</param>
        /// <returns>A <see cref="TrainTime" /> object containing the same data as the <c>model</c> parameter, with all references resolved.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <c>model</c> parameter is null.</exception>
        public static TrainTime ToTrainTime(this TrainTimeModel model, IDictionary<string, Note> notes)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            TrainTime tt = new TrainTime { Time = model.At?.ToTimeOfDay() };

            foreach (string noteId in model.FootnoteIds)
            {
                Note note = notes?[noteId];
                if (note != null)
                {
                    tt.Footnotes.Add(notes?[noteId]);
                }
            }

            return tt;
        }
    }
}
