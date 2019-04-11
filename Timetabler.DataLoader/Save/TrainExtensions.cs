using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for converting a <see cref="Train"/> instance into serialisable form.
    /// </summary>
    public static class TrainExtensions
    {
        /// <summary>
        /// Convert a <see cref="Train"/> instance into a <see cref="TrainModel"/> instance.
        /// </summary>
        /// <param name="train">The object to convert.</param>
        /// <returns>A <see cref="TrainModel"/> instance containing the same data as the parameter.</returns>
        public static TrainModel ToTrainModel(this Train train)
        {
            TrainModel model = new TrainModel
            {
                Id = train.Id,
                GraphProperties = train.GraphProperties.ToGraphTrainPropertiesModel(),
                Headcode = train.Headcode,
                LocoDiagram = train.LocoDiagram,
                TrainClassId = train.TrainClass?.Id,
                IncludeSeparatorAbove = train.IncludeSeparatorAbove,
                IncludeSeparatorBelow = train.IncludeSeparatorBelow,
                InlineNote = train.InlineNote ?? string.Empty,
                FootnoteIds = new List<string>(),
                TrainTimes = new List<TrainLocationTimeModel>(),
                ToWork = train.ToWork?.ToToWorkModel(),
                LocoToWork = train.LocoToWork?.ToToWorkModel(),
            };

            model.FootnoteIds.AddRange(train.Footnotes.Select(n => n.Id));
            model.TrainTimes.AddRange(train.TrainTimes.Select(tt => tt.ToTrainLocationTimeModel()));

            return model;
        }
    }
}
