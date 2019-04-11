using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;

namespace Timetabler.Models
{
    /// <summary>
    /// Data model for editing <see cref="SignalboxHours" /> objects.
    /// </summary>
    public class SignalboxHoursEditFormModel
    {
        /// <summary>
        /// The data to be edited.
        /// </summary>
        public SignalboxHours Data { get; set; }

        /// <summary>
        /// Whether to use the 12-hour or 24-hour clock in the UI.
        /// </summary>
        public ClockType InputMode { get; set; }
    }
}
