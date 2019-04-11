using System;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// Event arguments class for signalbox-specific events.
    /// </summary>
    public class SignalboxEventArgs : EventArgs
    {
        /// <summary>
        /// The signalbox to which this event refers.
        /// </summary>
        public Signalbox Signalbox { get; set; }

        /// <summary>
        /// If the signalbox is a member of a collection, the (new) index of the signalbox in the collection.
        /// </summary>
        public int? Index { get; set; }
    }
}
