using System;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// <see cref="EventArgs" /> subclass for events relating to <see cref="SignalboxHoursSet" /> objects.
    /// </summary>
    public class SignalboxHoursSetEventArgs : EventArgs
    {
        /// <summary>
        /// The object to which this event relates.
        /// </summary>
        public SignalboxHoursSet HoursSet { get; set; }
    }
}
