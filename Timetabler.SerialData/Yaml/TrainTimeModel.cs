using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    public class TrainTimeModel
    {
        public TimeOfDayModel At { get; set; }

        public List<string> FootnoteIds { get; set; }
    }
}