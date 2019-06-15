using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Timetabler.CoreData.Helpers
{
    /// <summary>
    /// An <see cref="IEqualityComparer" /> implementation which always compares strictly by reference equality even for types that implement their own Equals() method.
    /// </summary>
    public sealed class ReferenceEqualityComparer : IEqualityComparer, IEqualityComparer<object>
    {
        /// <summary>
        /// The default instance of this comparer.
        /// </summary>
        public static readonly ReferenceEqualityComparer Default = new ReferenceEqualityComparer();

        private ReferenceEqualityComparer() { }

        /// <summary>
        /// Returns true if the parameters are references to the same object instance, false if not.
        /// </summary>
        /// <param name="x">The first object</param>
        /// <param name="y">The second object</param>
        /// <returns>True if the objects are the same instance, false if not.</returns>
        public new bool Equals(object x, object y)
        {
            return x == y;
        }

        /// <summary>
        /// Return a hashcode for this object, using the runtime implementation.
        /// </summary>
        /// <param name="obj">The object to generate the hashcode of.</param>
        /// <returns>An int representing the hashcode of the object.</returns>
        public int GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
}
