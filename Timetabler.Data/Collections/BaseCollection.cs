using System;
using System.Collections;
using System.Collections.Generic;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// Base class for custom collections.
    /// </summary>
    /// <typeparam name="T">The type which this is a collection of.</typeparam>
    public abstract class BaseCollection<T> : ICollection<T> where T : class, IWatchableItem
    {
        /// <summary>
        /// Stores the collection contents.
        /// </summary>
        protected List<T> InnerCollection { get; } = new List<T>();

        /// <summary>
        /// Access members of the collection by index.
        /// </summary>
        /// <param name="index">The index of the item to be accessed.</param>
        /// <returns>The item of the collection with the given index.</returns>
        public virtual T this[int index]
        {
            get
            {
                return InnerCollection[index];
            }
            set
            {
                lock (InnerCollection)
                {
                    if (InnerCollection[index] != value)
                    {
                        InnerCollection[index].Modified -= ContentsModified;
                        OnRemove(InnerCollection[index], index);
                        InnerCollection[index] = value;
                        OnAdd(InnerCollection[index], index);
                        InnerCollection[index].Modified += ContentsModified;
                    }
                }
            }
        }

        /// <summary>
        /// The number of items in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return InnerCollection.Count;
            }
        }

        /// <summary>
        /// Always returns false.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        

        /// <summary>
        /// Add an item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public virtual void Add(T item)
        {
            lock (InnerCollection)
            {
                InnerCollection.Add(item);
                OnAdd(item, InnerCollection.Count - 1);
            }
            if (item != null)
            {
                item.Modified += ContentsModified;
            }
        }

        /// <summary>
        /// Insert an item into the collection at a specific index.
        /// </summary>
        /// <param name="idx">The index to insert the item at.</param>
        /// <param name="item">The item to be inserted.</param>
        public virtual void Insert(int idx, T item)
        {
            lock (InnerCollection)
            {
                InnerCollection.Insert(idx, item);
                OnAdd(item, idx);
            }
            if (item != null)
            {
                item.Modified += ContentsModified;
            }
        }

        /// <summary>
        /// Handles the Modified event of members of the collection.
        /// </summary>
        /// <param name="sender">The object which has raised the event.</param>
        /// <param name="e">The event arguments.</param>
        protected void ContentsModified(object sender, ModifiedEventArgs e)
        {
            if (e != null)
            {
                OnContentsModified(e.ModifiedItem as T);
            }
        }

        /// <summary>
        /// Called when an item is added to the collection, so that implementations can raise events.
        /// </summary>
        /// <param name="item">The item which has been added to the collection.</param>
        /// <param name="idx">The index of the new item in the collection.</param>
        protected abstract void OnAdd(T item, int? idx);

        /// <summary>
        /// Called when an item in the collection has been modified.
        /// </summary>
        /// <param name="item">The item which has been modified.</param>
        /// <remarks>&quot;Modified&quot; in this context means that the item's <see cref="IWatchableItem.Modified"/> event has been raised.</remarks>
        protected abstract void OnContentsModified(T item);

        /// <summary>
        /// Clear the contents of the collection.
        /// </summary>
        public void Clear()
        {
            lock (InnerCollection)
            {
                ClearImpl();
            }
        }

        private void ClearImpl()
        {
            InnerCollection.ForEach(i => i.Modified -= ContentsModified);
            InnerCollection.Clear();
        }

        /// <summary>
        /// Clear the contents of the collection and replace it with new contents.  Does not trigger Add or Remove events.
        /// </summary>
        /// <param name="newContents">The new contents of the collection.</param>
        public void Overwrite(IEnumerable<T> newContents)
        {
            lock (InnerCollection)
            {
                ClearImpl();
                InnerCollection.AddRange(newContents);
                InnerCollection.ForEach(i => i.Modified += ContentsModified);
            }
        }

        /// <summary>
        /// Indicates whether or not an object is a member of the collection.
        /// </summary>
        /// <param name="item">The item to be searched for.</param>
        /// <returns>True if the item is contained in the collection, false if not.</returns>
        public bool Contains(T item)
        {
            return InnerCollection.Contains(item);
        }

        /// <summary>
        /// Returns the index of an item in the collection.
        /// </summary>
        /// <param name="item">The item to be searched for.</param>
        /// <returns>The index of the item if it is contained in the collection, or -1 if not.</returns>
        public int IndexOf(T item)
        {
            return InnerCollection.IndexOf(item);
        }

        /// <summary>
        /// Copy the contents of the collection into an array, starting at the given index.
        /// </summary>
        /// <param name="array">The array to copy the collection contents into.</param>
        /// <param name="arrayIndex">The index from which to start copying the collection contents into.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the arrayIndex parameter is less than zero.</exception>
        /// <exception cref="ArgumentException">Thrown if the array is not large enough to contain the collection contents.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException(Resources.BaseCollection_CopyTo_Error_InsufficientArrayLength, nameof(array));
            }

            lock (InnerCollection)
            {
                for (int i = 0; i < Count; ++i)
                {
                    array[arrayIndex + i] = InnerCollection[i];
                }
            }
        }

        /// <summary>
        /// Return an enumerator.
        /// </summary>
        /// <returns>An enumerator for this collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new BaseEnumerator<T>(this);
        }
        
        /// <summary>
        /// Remove the first instance of an item from the collection, if present.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        /// <returns>True if the item was removed from the collection; false if the collection did not contain the item.</returns>
        public virtual bool Remove(T item)
        {
            if (item is null)
            {
                return false;
            }
            lock (InnerCollection)
            {
                for (int i = 0; i < InnerCollection.Count; ++i)
                {
                    if (InnerCollection[i] == item)
                    {
                        InnerCollection.RemoveAt(i);
                        item.Modified -= ContentsModified;
                        OnRemove(item, i);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Remove the item at a given index.
        /// </summary>
        /// <param name="idx">The index of the item to remove.</param>
        public virtual void RemoveAt(int idx)
        {
            if (idx < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            lock (InnerCollection)
            {
                if (idx >= InnerCollection.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(idx));
                }

                T item = InnerCollection[idx];
                InnerCollection.RemoveAt(idx);
                item.Modified -= ContentsModified;
                OnRemove(item, idx);
            }
        }

        /// <summary>
        /// Remove all items matching a predicate.
        /// </summary>
        /// <param name="predicate">The delegate that defines the condition to choose which elements to remove.</param>
        /// <returns>The number of elements removed from the collection.</returns>
        public int RemoveAll(Func<T, bool> predicate)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            int count = 0;
            for (int i = 0; i < Count; ++i)
            {
                if (predicate(this[i]))
                {
                    RemoveAt(i);
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Called when an item is removed from the collection, so that implementations can raise events.
        /// </summary>
        /// <param name="item">The removed item.</param>
        /// <param name="idx">Former index of the removed item.</param>
        protected abstract void OnRemove(T item, int idx);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
