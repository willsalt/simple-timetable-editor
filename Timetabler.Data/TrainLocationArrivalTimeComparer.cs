using System.Collections.Generic;
using Timetabler.CoreData;

namespace Timetabler.Data
{
    /// <summary>
    /// An <see cref="IComparer{T}"/> implementation which compares <see cref="TrainLocationTime"/> objects based on their arrival time.
    /// </summary>
    public class TrainLocationArrivalTimeComparer : IComparer<TrainLocationTime>
    {
        /// <summary>
        /// Compare two <see cref="TrainLocationTime"/> objects based on their arrival time.  Parameters which are null, or whose arrival time property is null, 
        /// compare lower than any which have that property populated.
        /// </summary>
        /// <param name="x">A <see cref="TrainLocationTime"/> object, or null.</param>
        /// <param name="y">A <see cref="TrainLocationTime"/> object, or null.</param>
        /// <returns>Returns -1, 0 or 1 to indicate if x is less than, equal to or greater than y.</returns>
        public int Compare(TrainLocationTime x, TrainLocationTime y)
        {
            if (x == null)
            {
                return (y == null) ? 0 : -1;
            }
            if (y == null)
            {
                return 1;
            }

            TimeOfDay xTime = x.ArrivalTime?.Time ?? x.DepartureTime?.Time;
            TimeOfDay yTime = y.ArrivalTime?.Time ?? y.DepartureTime?.Time;

            if (xTime == null)
            {
                return yTime != null ? -1 : 0;
            }
            if (yTime == null)
            {
                return 1;
            }

            return xTime.CompareTo(yTime);
        }
    }
}
