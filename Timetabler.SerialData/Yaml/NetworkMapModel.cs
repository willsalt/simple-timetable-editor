using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// Class describing a map in serialisable form.
    /// </summary>
    public class NetworkMapModel
    {
        /// <summary>
        /// The locations making up this map.
        /// </summary>
        public List<LocationModel> LocationList { get; } = new List<LocationModel>();

        /// <summary>
        /// The block sections that exist on the map.
        /// </summary>
        public List<BlockSectionModel> BlockSections { get; } = new List<BlockSectionModel>();

        /// <summary>
        /// The signalboxes on the map.
        /// </summary>
        public List<SignalboxModel> Signalboxes { get; } = new List<SignalboxModel>();
    }
}
