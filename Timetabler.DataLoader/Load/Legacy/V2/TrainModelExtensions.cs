using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Load.Legacy.V2
{
    /// <summary>
    /// Extension methods for loading train objects from serializable form into in-memory form.
    /// </summary>
    public static class TrainModelExtensions
    {
        /// <summary>
        /// Convert a serializable <see cref="XmlData.Legacy.V2.TrainModel"/> object into a <see cref="Train"/> object.
        /// </summary>
        /// <param name="model">The object to load.</param>
        /// <param name="locations">Dictionary of locations occurring in the timetable.</param>
        /// <param name="trainClasses">Dictionary of train classes occurring in the timetable.</param>
        /// <param name="notes">Dictionary of footnotes occurring in the timetable.</param>
        /// <returns>A <see cref="Train"/> instance.</returns>
        public static Train ToTrain(this XmlData.Legacy.V2.TrainModel model, Dictionary<string, Location> locations, Dictionary<string, TrainClass> trainClasses, Dictionary<string, Note> notes)
        {
            Train trn = new Train
            {
                Id = model.Id,
                Headcode = model.Headcode,
                LocoDiagram = model.LocoDiagram,
                TrainClass = string.IsNullOrEmpty(model.TrainClassId) ? null : trainClasses?[model.TrainClassId],
                GraphProperties = model.GraphProperties.ToGraphTrainProperties(),
            };

            foreach (TrainLocationTimeModel timingPoint in model.TrainTimes)
            {
                trn.TrainTimes.Add(timingPoint.ToTrainLocationTime(locations, notes));
            }

            foreach (string noteId in model.FootnoteIds)
            {
                trn.Footnotes.Add(notes?[noteId]);
            }

            return trn;
        }
    }
}
