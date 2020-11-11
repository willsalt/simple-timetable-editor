using System;
using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for the <see cref="TrainModel" /> class.
    /// </summary>
    public static class TrainModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainModel" /> instance to a <see cref="Train" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <param name="locations">A dictionary of known locations, to be used to resolve references to locations the train visits.</param>
        /// <param name="trainClasses">A dictionary of known train classes, to be used to resolve the reference to the train's class.</param>
        /// <param name="notes">A dictionary of known footnotes, to be used to resolve references to any footnotes that are relevant.</param>
        /// <param name="options">Options for this document, to be used to control any document-level settings.</param>
        /// <returns>A <see cref="Train" /> instance containing the same data as the <c>model</c> parameter with all ID-based references resolved to objects.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <c>model</c> parameter is null.</exception>
        public static Train ToTrain(
            this TrainModel model,
            Dictionary<string, Location> locations,
            Dictionary<string, TrainClass> trainClasses,
            Dictionary<string, Note> notes,
            DocumentOptions options)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }
            if (string.IsNullOrWhiteSpace(model.Id))
            {
                throw new ArgumentException("ID missing");
            }

            Train trn = new Train
            {
                Id = model.Id,
                Headcode = model.Headcode,
                LocoDiagram = model.LocoDiagram,
                TrainClass = string.IsNullOrEmpty(model.TrainClassId) ? null : trainClasses?[model.TrainClassId],
                TrainClassId = model.TrainClassId,
                GraphProperties = model.GraphProperties.ToGraphTrainProperties(),
                IncludeSeparatorAbove = model.IncludeSeparatorAbove ?? false,
                IncludeSeparatorBelow = model.IncludeSeparatorBelow ?? false,
                InlineNote = model.InlineNote ?? string.Empty,
                ToWork = model.SetToWork?.ToToWork(),
                LocoToWork = model.LocoToWork?.ToToWork(),
            };

            foreach (TrainLocationTimeModel timingPoint in model.TrainTimes)
            {
                trn.TrainTimes.Add(timingPoint.ToTrainLocationTime(locations, notes, options));
            }

            foreach (string noteId in model.FootnoteIds)
            {
                trn.Footnotes.Add(notes?[noteId]);
            }

            return trn;
        }
    }
}
