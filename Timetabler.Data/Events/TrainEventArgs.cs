using System;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// An event argument class for train-related events.
    /// </summary>
    public class TrainEventArgs : EventArgs
    {
        /// <summary>
        /// The train with which this event is concerned.
        /// </summary>
        public Train Train { get; set; }
    }
}
