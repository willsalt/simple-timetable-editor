using System;
using Timetabler.Data.Display;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// The arguments to <see cref="TrainSegmentModel"/>-related events.
    /// </summary>
    public class TrainSegmentEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="TrainSegmentModel"/> to which the event relates.
        /// </summary>
        public TrainSegmentModel TrainSegment { get; set; }

        /// <summary>
        /// The index number of the <see cref="TrainSegmentModel"/> within its parent timetable section.
        /// </summary>
        public int Index { get; set; }
    }
}
