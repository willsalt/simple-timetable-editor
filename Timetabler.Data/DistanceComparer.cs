using System.Collections.Generic;

namespace Timetabler.Data
{
    /// <summary>
    /// An <see cref="IComparer{T}" /> implementation for the <see cref="Distance"/> class.
    /// </summary>
    public class DistanceComparer : IComparer<Distance>
    {
        /// <summary>
        /// Compare two <see cref="Distance"/> objects and return an integer to indicate which is greater and which smaller.  Null parameters compare lower than any non-null parameter.
        /// </summary>
        /// <param name="x">A Distance object.</param>
        /// <param name="y">A second Distance object.</param>
        /// <returns>An integer indicating whether x is smaller than, equal to or greater than y.</returns>
        public int Compare(Distance x, Distance y)
        {
            if (x == null)
            {
                return y == null ? 0 : -1;
            }
            return x.CompareTo(y);
        }
    }
}
