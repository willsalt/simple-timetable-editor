using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    public class TrainModel
    {
        public string Id { get; set; }

        public string Headcode { get; set; }

        public string LocoDiagram { get; set; }

        public string TrainClassId { get; set; }

        public GraphTrainPropertiesModel GraphProperties { get; set; }

        public List<TrainLocationTimeModel> TrainTimes { get; set; }

        public List<string> FootnoteIds { get; set; }

        public bool? IncludeSeparatorAbove { get; set; }

        public bool? IncludeSeparatorBelow { get; set; }

        public string InlineNote { get; set; }

        public ToWorkModel SetToWork { get; set; }

        public ToWorkModel LocoToWork { get; set; }
    }
}