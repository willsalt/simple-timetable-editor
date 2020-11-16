using System.Collections.Generic;

namespace Timetabler.SerialData
{
    /// <summary>
    /// Class describing a map in serialisable form.
    /// </summary>
    public class NetworkMapModel
    {
        /// <summary>
        /// The locations making up this map.
        /// </summary>
        public ICollection<LocationModel> LocationList { get; } = new List<LocationModel>();

        /// <summary>
        /// The block sections that exist on the map.
        /// </summary>
        public ICollection<BlockSectionModel> BlockSections { get; } = new List<BlockSectionModel>();

        /// <summary>
        /// The signalboxes on the map.
        /// </summary>
        public ICollection<SignalboxModel> Signalboxes { get; } = new List<SignalboxModel>();
    }
}
