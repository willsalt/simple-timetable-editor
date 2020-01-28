using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class TrainExtensions
    {
        public static TrainModel ToYamlTrainModel(this Train train)
        {
            if (train is null)
            {
                throw new NullReferenceException();
            }

            return new TrainModel
            {
                Id = train.Id,
                GraphProperties = train.GraphProperties.ToYamlGraphTrainPropertiesModel(),
                Headcode = train.Headcode,
                LocoDiagram = train.LocoDiagram,
                TrainClassId = train.TrainClassId,
                IncludeSeparatorAbove = train.IncludeSeparatorAbove,
                IncludeSeparatorBelow = train.IncludeSeparatorBelow,
                InlineNote = train.InlineNote,
                SetToWork = train.ToWork?.ToYamlToWorkModel(),
                LocoToWork = train.LocoToWork?.ToYamlToWorkModel(),
                FootnoteIds = train.Footnotes.Select(n => n.Id).ToList(),
                TrainTimes = train.TrainTimes.Select(tt => tt.ToYamlTrainLocationTimeModel()).ToList(),
            };
        }
    }
}
