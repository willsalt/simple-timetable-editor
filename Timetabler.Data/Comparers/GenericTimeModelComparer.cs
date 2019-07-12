using System.Collections.Generic;
using Timetabler.Data.Display;

namespace Timetabler.Data.Comparers
{
    /// <summary>
    /// An <see cref="IComparer{TrainLocationTimeModel}" /> implementation.
    /// </summary>
    public class GenericTimeModelComparer : IComparer<GenericTimeModel>
    {
        /// <summary>
        /// A static instance of this class, to act as a singleton instance.
        /// </summary>
        public static GenericTimeModelComparer Default = new GenericTimeModelComparer();

        /// <summary>
        /// Compares two <see cref="GenericTimeModel" /> objects according to their <see cref="GenericTimeModel.ActualTime" /> properties.
        /// If one and only one parameter or its <see cref="GenericTimeModel.ActualTime" /> property is null, it compares as earlier than the other.
        /// </summary>
        /// <param name="x">The first object to compare</param>
        /// <param name="y">The second object to compare</param>
        /// <returns>-1, 0 or 1 according to whether the first parameter is earlier, at the same time as, or later than the second parameter.</returns>
        public int Compare(GenericTimeModel x, GenericTimeModel y)
        {
            if (x?.ActualTime == null)
            {
                return (y?.ActualTime == null) ? 0 : -1;
            }
            if (y?.ActualTime == null)
            {
                return 1;
            }
            return x.ActualTime.CompareTo(y.ActualTime);
        }
    }
}
