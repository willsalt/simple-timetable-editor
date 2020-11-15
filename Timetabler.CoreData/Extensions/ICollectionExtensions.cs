using System;
using System.Collections.Generic;

namespace Timetabler.CoreData.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="ICollection{T}"/> type.
    /// </summary>
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Utility method to make up for there being a <see cref="List{T}.AddRange" /> method but no <c>ICollection&lt;T&gt;.AddRange</c> method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <see cref="ICollection{T}"/>.</typeparam>
        /// <param name="collection">The collection to add elements to.</param>
        /// <param name="newMembers">The collection of elements to be added.</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> newMembers)
        {
            if (collection is List<T> list)
            {
                list.AddRange(newMembers);
                return;
            }
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (newMembers is null)
            {
                throw new ArgumentNullException(nameof(newMembers));
            }
            foreach (T item in newMembers)
            {
                collection.Add(item);
            }
        }
    }
}
