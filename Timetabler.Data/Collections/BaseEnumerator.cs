using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private T _cur;

        /// <summary>
        /// Constructs the enumerator for a given <see cref="BaseCollection{T}"/>.
        /// </summary>
        /// <param name="collection">The <see cref="BaseCollection{T}"/> to construct an enumerator for.</param>
        public BaseEnumerator(BaseCollection<T> collection)
        {
            _collection = collection;
            _curIdx = -1;
            _cur = null;
        }

        /// <summary>
        /// Gets the currently-enumerated object.
        /// </summary>
        public T Current
        {
            get { return _cur; }
        }

        /// <summary>
        /// Gets the currently-enumerated object.
        /// </summary>
        object IEnumerator.Current
        {
            get { return _cur; }
        }

        /// <summary>
        /// Dispose of this enumerator.
        /// </summary>
        public void Dispose()
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
            _cur = _collection[_curIdx];
            return true;
        }

        /// <summary>
        /// Resets the enumerator state, so that the enumerator is pointing before the start of the collection.
        /// </summary>
        public void Reset()
        {
            _curIdx = -1;
            _cur = null;
        }
    }
}
