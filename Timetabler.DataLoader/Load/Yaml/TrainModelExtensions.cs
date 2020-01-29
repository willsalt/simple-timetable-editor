using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class TrainModelExtensions
    {
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
