using Timetabler.Data;

namespace Timetabler.Models
{
    /// <summary>
    /// Data model for the <see cref="SignalboxHoursSetEditForm" /> form.
    /// </summary>
    public class SignalboxHoursSetEditFormModel
    {
        /// <summary>
        /// The data to be edited.
        /// </summary>
        public SignalboxHoursSet Data { get; set; }

        /// <summary>
        /// The clock input mode (12/24 hours) to use.
        /// </summary>
        public ClockType InputMode { get; set; }
    }
}
