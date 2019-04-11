using System.Collections;
using System.Collections.Generic;

namespace Unicorn
{
    /// <summary>
    /// An enumerator class for <see cref="TableCell"/> instances.
    /// </summary>
    public class TableCellEnumerator : IEnumerator<TableCell>
    {
        private TableCellCollection _collection;
        private int _curIdx;
        private TableCell _cur;

        /// <summary>
        /// Constructs the enumerator for a given <see cref="TableCellCollection"/>.
        /// </summary>
        /// <param name="collection">The <see cref="TableCellCollection"/> to construct an enumerator for.</param>
        public TableCellEnumerator(TableCellCollection collection)
        {
            _collection = collection;
            _curIdx = -1;
            _cur = null;
        }

        /// <summary>
        /// Gets the currently-enumerated object.
        /// </summary>
        public TableCell Current
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
