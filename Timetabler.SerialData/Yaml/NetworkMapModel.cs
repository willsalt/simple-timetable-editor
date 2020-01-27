using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    public class NetworkMapModel
    {
        public List<LocationModel> LocationList { get; set; }

        public List<BlockSectionModel> BlockSections { get; set; }

        public List<SignalboxModel> Signalboxes { get; set; }
    }
}