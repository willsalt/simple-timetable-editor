using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetabler.Data
{
    /// <summary>
    /// An <see cref="IComparer{T}"/> implementation which compares <see cref="TrainLocationTime"/> objects based on their departure time.
    /// </summary>
    public class TrainLocationDepartureTimeComparer : IComparer<TrainLocationTime>
    {
        /// <summary>
        /// Compare two <see cref="TrainLocationTime"/> objects based on their departure time.  Parameters which are null, or whose departure time property is null, 
        /// compare lower than any which have that property populated.
        /// </summary>
        /// <param name="x">A <see cref="TrainLocationTime"/> object, or null.</param>
        /// <param name="y">A <see cref="TrainLocationTime"/> object, or null.</param>
        /// <returns>Returns -1, 0 or 1 to indicate if x is less than, equal to or greater than y.</returns>
        public int Compare(TrainLocationTime x, TrainLocationTime y)
        {
            if (x == null)
            {
                return y == null ? 0 : -1;
            }
            if (y == null)
            {
                return 1;
            }

            if (x.DepartureTime?.Time == null)
            {
                return y.DepartureTime?.Time != null ? -1 : 0;
            }
            if (y.DepartureTime?.Time == null)
            {
                return 1;
            }

            return x.DepartureTime.Time.CompareTo(y.DepartureTime.Time);
        }
    }
}
