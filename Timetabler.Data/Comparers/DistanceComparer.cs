using System.Collections.Generic;

namespace Timetabler.Data.Comparers
{
    /// <summary>
    /// An <see cref="IComparer{T}" /> implementation for the <see cref="Distance"/> class.
    /// </summary>
    public class DistanceComparer : IComparer<Distance>
    {
        /// <summary>
        /// Compare two <see cref="Distance"/> values and return an integer to indicate which is greater and which smaller.
        /// </summary>
        /// <param name="x">A Distance object.</param>
        /// <param name="y">A second Distance object.</param>
        /// <returns>An integer indicating whether x is smaller than, equal to or greater than y.</returns>
        public int Compare(Distance x, Distance y) => x.CompareTo(y);
    }
}
