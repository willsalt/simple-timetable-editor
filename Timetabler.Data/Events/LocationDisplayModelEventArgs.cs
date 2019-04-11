using System;
using Timetabler.Data.Display;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// Event arguments for <see cref="LocationDisplayModel"/>-related events. 
    /// </summary>
    public class LocationDisplayModelEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="LocationDisplayModel" /> that this event relates to. 
        /// </summary>
        public LocationDisplayModel Model { get; set; }

        /// <summary>
        /// If the event is related to a collection, the index of the <see cref="LocationDisplayModel" /> concerned within the collection. 
        /// </summary>
        public int? Index { get; set; }
    }
}
