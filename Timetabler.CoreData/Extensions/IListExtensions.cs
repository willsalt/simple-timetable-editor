using System;
using System.Collections.Generic;

namespace Timetabler.CoreData.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="IList{T}" /> type.
    /// </summary>
    public static class IListExtensions
    {
        /// <summary>
        /// Remove a contiguous range of items from a list.
        /// </summary>
        /// <typeparam name="T">The type of the items in the list.</typeparam>
        /// <param name="list">The list to remove items from.</param>
        /// <param name="index">The index of the first item to remove from the list.</param>
        /// <param name="count">The number of items to remove from the list.</param>
        /// <exception cref="ArgumentNullException">Thrown if the <c>list</c> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>index</c> parameter is less than 0 or if the <c>count</c> parameter is less than 0.</exception>
        /// <exception cref="ArgumentException">Thrown if the <c>index</c> and <c>count</c> parameters do not represent a valid range of items.</exception>
        public static void RemoveRange<T>(this IList<T> list, int index, int count)
        {
            if (list is List<T> concreteList)
            {
                concreteList.RemoveRange(index, count);
                return;
            }
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index)); 
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (index + count >= list.Count)
            {
                throw new ArgumentException("Parameters do not represent a valid range of elements within the list.");
            }
            for (int i = 0; i < count; ++i)
            {
                list.RemoveAt(index);
            }
        }
    }
}
