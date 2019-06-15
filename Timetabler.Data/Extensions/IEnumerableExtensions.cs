using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData.Comparers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{VertexInformation}" />.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Filters the items in an <see cref="IEnumerable{VertexInformation}" /> list according to whether their <see cref="VertexInformation.Time" /> property is later than (or the same as) that
        /// of the parameter.
        /// </summary>
        /// <param name="items">The enumerable to filter.</param>
        /// <param name="cut">The cutoff time.</param>
        /// <returns>An enumerable whose items have a later time property than that of the cutoff parameter.</returns>
        public static IEnumerable<VertexInformation> LaterThan(this IEnumerable<VertexInformation> items, VertexInformation cut)
        {
            if (cut?.Time == null)
            {
                return items;
            }
            return items.Where(i => i.Time != null && cut.Time <= i.Time);
        }

        /// <summary>
        /// Filters the items in an <see cref="IEnumerable{VertexInformation}" /> list according to whether their <see cref="VertexInformation.Time" /> property is earlier than (or the same as) 
        /// that of the parameter.
        /// </summary>
        /// <param name="items">The enumerable to filter.</param>
        /// <param name="cut">The cutoff time.</param>
        /// <returns>An enumerable whose items have an earlier time property than that of the cutoff parameter.</returns>
        public static IEnumerable<VertexInformation> EarlierThan(this IEnumerable<VertexInformation> items, VertexInformation cut)
        {
            if (cut?.Time == null)
            {
                return items;
            }
            return items.Where(i => i.Time != null && cut.Time >= i.Time);
        }

        /// <summary>
        /// This method takes an <see cref="IEnumerable{VertexInformation}" /> parameter and projects the elements to return an enumeration of the Time property of each element.
        /// Duplicates are removed from the enumeration, as the <see cref="VertexInformation" /> objects may well maintain references to the same underlying <see cref="TimeOfDay" /> objects
        /// </summary>
        /// <param name="items">An enumeration of <see cref="VertexInformation" /> instances.</param>
        /// <returns>An enumeration of <see cref="TimeOfDay" /> objects referred to by the instances from the parameter.</returns>
        public static IEnumerable<TimeOfDay> Times(this IEnumerable<VertexInformation> items)
        {
            return items.Select(v => v.Time).Distinct(ReferenceEqualityComparer.Default).Cast<TimeOfDay>();
        }
    }
}
