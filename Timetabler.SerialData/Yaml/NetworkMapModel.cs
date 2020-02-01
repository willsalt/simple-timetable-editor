using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    public class NetworkMapModel
    {
        public List<LocationModel> LocationList { get; } = new List<LocationModel>();

        public List<BlockSectionModel> BlockSections { get; } = new List<BlockSectionModel>();

        public List<SignalboxModel> Signalboxes { get; } = new List<SignalboxModel>();
    }
}