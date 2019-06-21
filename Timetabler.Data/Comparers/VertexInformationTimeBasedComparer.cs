using System.Collections.Generic;
using Timetabler.Data.Display;

namespace Timetabler.Data.Comparers
{
    /// <summary>
    /// An <see cref="IComparer{VertexInformation}" /> implementation which compares based on the <see cref="VertexInformation.Time" /> property of each object.
    /// </summary>
    public class VertexInformationTimeBasedComparer : IComparer<VertexInformation>
    {
        /// <summary>
        /// Returns a comparison result based on the <see cref="VertexInformation.Time" /> property of the x and y parameters.
        /// </summary>
        /// <param name="x">A <see cref="VertexInformation" /> instance.</param>
        /// <param name="y">A <see cref="VertexInformation" /> instance.</param>
        /// <returns>A value of -1, 0 or 1 according to whether the first parameter is earlier, the same time as, or later than the second.</returns>
        public int Compare(VertexInformation x, VertexInformation y)
        {
            if (x?.Time == null)
            {
                return y?.Time == null ? 0 : -1;
            }
            if (y?.Time == null)
            {
                return 1;
            }
            return x.Time.CompareTo(y.Time);
        }
    }
}
