using System.Collections.Generic;

namespace Timetabler.Data
{
    /// <summary>
    /// An <see cref="IComparer{T}"/> implementation for the <see cref="Location"/> class which compares using their <see cref="Location.Mileage"/> properties.
    /// </summary>
    public class LocationComparer : IComparer<Location>
    {
        /// <summary>
        /// Compare two <see cref="Location"/> instances based on their <see cref="Location.Mileage"/> properties.  A null parameter always compares as lower than any non-null parameter.
        /// </summary>
        /// <param name="x">A <see cref="Location"/> instance, or null.</param>
        /// <param name="y">A <see cref="Location"/> instance, or null.</param>
        /// <returns>If x is less than y, return -1.  If x is greater than y, return 1.  If x and y are equal, return 0.</returns>
        public int Compare(Location x, Location y)
        {
            if (x == null)
            {
                return y == null ? 0 : -1;
            }
            if (y == null)
            {
                return 1;
            }
            if (x.Mileage == null)
            {
                return y.Mileage == null ? 0 : -1;
            }
            if (y.Mileage == null)
            {
                return 1;
            }

            return x.Mileage.CompareTo(y.Mileage);
        }
    }
}
