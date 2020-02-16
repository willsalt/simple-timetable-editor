using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    public class SignalboxHoursSetModel
    {
        public string Category { get; set; }

        public List<SignalboxHoursModel> Signalboxes { get; } = new List<SignalboxHoursModel>();
    }
}
