using System;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// An <see cref="EventArgs"/> class for <see cref="Location"/>-related events.
    /// </summary>
    public class LocationEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="Location"/> to which the event relates.
        /// </summary>
        public Location Location { get; set; }
    }
}
