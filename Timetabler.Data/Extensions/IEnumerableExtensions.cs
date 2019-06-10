using System.Collections.Generic;
using System.Linq;
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
    }
}
