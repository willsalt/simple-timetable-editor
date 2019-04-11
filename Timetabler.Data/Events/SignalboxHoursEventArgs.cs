using System;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// <see cref="EventArgs"/> subclass for events relating to <see cref="SignalboxHours" /> objects.
    /// </summary>
    public class SignalboxHoursEventArgs : EventArgs
    {
        /// <summary>
        /// The object to which this event relates.
        /// </summary>
        public SignalboxHours SignalboxHours { get; set; }
    }
}
