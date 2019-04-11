using System;
using Timetabler.Data.Display;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// Event arguments class for <see cref="TrainSegmentModel" />-related events. 
    /// </summary>
    public class TrainSegmentModelEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="TrainSegmentModel" /> to which the event relates. 
        /// </summary>
        public TrainSegmentModel Model { get; set; }

        /// <summary>
        /// If the event is related to a collection, the index of the specific model within the collection.
        /// </summary>
        public int? Index { get; set; }
    }
}
