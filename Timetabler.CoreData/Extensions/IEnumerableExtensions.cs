using System;
using System.Collections.Generic;

namespace Timetabler.CoreData.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Invoke a method on every item of an enumeration.  I'm aware that this is "spiritually against" the design of LINQ, but wanted the behaviour of a 
        /// foreach loop combined with the additional index parameter than LINQ methods have.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="source">Any enumeration</param>
        /// <param name="action">A method to be called for each element of the enumeration, together with the index of that element.</param>
        /// <exception cref="NullReferenceException">Thrown if the <c>source</c> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the <c>action</c> parameter is <c>null</c>.</exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            IEnumerator<T> enumerator = source.GetEnumerator();
            int ctr = 0;
            while (enumerator.MoveNext())
            {
                action(enumerator.Current, ctr++);
            }
        }
    }
}
