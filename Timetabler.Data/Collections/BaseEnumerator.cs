using System;
using System.Collections;
using System.Collections.Generic;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// An enumerator type for the abstract collection type <see cref="BaseCollection{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type parameter of the collection type that this is an enumerator for.</typeparam>
    public class BaseEnumerator<T> : IEnumerator<T> where T : class, IWatchableItem
    {
        private BaseCollection<T> _collection;
        private int _curIdx;

        /// <summary>
        /// Constructs the enumerator for a given <see cref="BaseCollection{T}"/>.
        /// </summary>
        /// <param name="collection">The <see cref="BaseCollection{T}"/> to construct an enumerator for.</param>
        public BaseEnumerator(BaseCollection<T> collection)
        {
            _collection = collection;
            _curIdx = -1;
            Current = null;
        }

        /// <summary>
        /// Gets the currently-enumerated object.
        /// </summary>
        public T Current { get; private set; }

        /// <summary>
        /// Gets the currently-enumerated object.
        /// </summary>
        object IEnumerator.Current
        {
            get { return Current; }
        }

        /// <summary>
        /// Dispose of this enumerator.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of this enumerator.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {

        }

        /// <summary>
        /// Move the enumerator to the next object in the collection.
        /// </summary>
        /// <returns>True if the operation was succesful; false if the end of the collection has been reached.</returns>
        public bool MoveNext()
        {
            if (++_curIdx >= _collection.Count)
            {
                return false;
            }
            Current = _collection[_curIdx];
            return true;
        }

        /// <summary>
        /// Resets the enumerator state, so that the enumerator is pointing before the start of the collection.
        /// </summary>
        public void Reset()
        {
            _curIdx = -1;
            Current = null;
        }
    }
}
