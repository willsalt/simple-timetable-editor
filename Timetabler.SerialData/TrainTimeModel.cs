using System.Collections.Generic;

namespace Timetabler.SerialData
{
    /// <summary>
    /// Class representing a time of day plus optionally additional footnotes.
    /// </summary>
    public class TrainTimeModel
    {
        /// <summary>
        /// The time of day.
        /// </summary>
        public TimeOfDayModel At { get; set; }

        /// <summary>
        /// The list of footnotes to be displayed along with the time.
        /// </summary>
        public ICollection<string> FootnoteIds { get; } = new List<string>();
    }
}
