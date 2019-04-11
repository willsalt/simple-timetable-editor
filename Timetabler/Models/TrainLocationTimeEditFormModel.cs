using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.Data.Collections;

namespace Timetabler.Models
{
    /// <summary>
    /// The model for data to be edited in a <see cref="TrainLocationTimeEditForm"/>.
    /// </summary>
    public class TrainLocationTimeEditFormModel
    {
        /// <summary>
        /// List of valid locations where this timing point may occur, for combo-box population.
        /// </summary>
        public LocationCollection ValidLocations { get; set; }

        /// <summary>
        /// List of valid footnotes which may apply to a timing point.
        /// </summary>
        public List<Note> ValidNotes { get; set; }
        
        /// <summary>
        /// The timing data object to be edited.
        /// </summary>
        public TrainLocationTime Data { get; set; } 

        /// <summary>
        /// Whether the dialog box should accept input in 12-hour or 24-hour mode.
        /// </summary>
        public ClockType InputMode { get; set; }
    }
}
