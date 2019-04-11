using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;
using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// A collection class for <see cref="SignalboxHours" /> objects.  Based on the <see cref="IDictionary" /> interface.
    /// </summary>
    public class SignalboxHoursCollection : IDictionary<string, SignalboxHours>, ICollection<KeyValuePair<string, SignalboxHours>>
    {
        /// <summary>
        /// Event raised when an object is added to the collection.
        /// </summary>
        public event SignalboxHoursEventHandler SignalboxHoursAdd;

        /// <summary>
        /// Event raised when an object is removed from the collection.
        /// </summary>
        public event SignalboxHoursEventHandler SignalboxHoursRemove;

        /// <summary>
        /// Event raised when a member of the collection raises the <see cref="IWatchableItem.Modified"/> event.
        /// </summary>
        public event SignalboxHoursEventHandler SignalboxHoursModified;

        private Dictionary<string, SignalboxHours> _innerCollection;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SignalboxHoursCollection()
        {
            _innerCollection = new Dictionary<string, SignalboxHours>();
        }

        /// <summary>
        /// Collection indexer.
        /// </summary>
        /// <param name="key">The key to look up in the collection.</param>
        /// <returns></returns>
        public SignalboxHours this[string key]
        {
            get
            {
                return _innerCollection[key];
            }

            set
            {
                lock (_innerCollection)
                {
                    if (_innerCollection[key] != value)
                    {
                        _innerCollection[key].Modified -= ContentsModified;
                        OnRemove(_innerCollection[key]);
                        _innerCollection[key] = value;
                        OnAdd(_innerCollection[key]);
                        _innerCollection[key].Modified += ContentsModified;
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="SignalboxHoursRemove" /> event.
        /// </summary>
        /// <param name="signalboxHours">The <see cref="SignalboxHours" /> object removed from the collection.</param>
        protected virtual void OnRemove(SignalboxHours signalboxHours)
        {
            SignalboxHoursRemove?.Invoke(this, new SignalboxHoursEventArgs { SignalboxHours = signalboxHours });
        }

        /// <summary>
        /// Raises the <see cref="SignalboxHoursAdd" /> event.
        /// </summary>
        /// <param name="signalboxHours">The <see cref="SignalboxHours" /> object added to the collection.</param>
        protected virtual void OnAdd(SignalboxHours signalboxHours)
        {
            SignalboxHoursAdd?.Invoke(this, new SignalboxHoursEventArgs { SignalboxHours = signalboxHours });
        }

        /// <summary>
        /// Raises the <see cref="SignalboxHoursModified" /> event.
        /// </summary>
        /// <param name="signalboxHours">The <see cref="SignalboxHours" /> object which has been modified.</param>
        protected virtual void OnContentsModified(SignalboxHours signalboxHours)
        {
            SignalboxHoursModified?.Invoke(this, new SignalboxHoursEventArgs { SignalboxHours = signalboxHours });
        }

        /// <summary>
        /// Returns the number of elements in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return _innerCollection.Count;
            }
        }

        /// <summary>
        /// Is this collection read-only?  Returns false.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The collection of keys to the objects in the collection.
        /// </summary>
        public ICollection<string> Keys
        {
            get
            {
                return _innerCollection.Keys;
            }
        }

        /// <summary>
        /// The members of the collection.
        /// </summary>
        public ICollection<SignalboxHours> Values
        {
            get
            {
                return _innerCollection.Values;
            }
        }

        /// <summary>
        /// Add an item to the collection, consisting of a key and a value.
        /// </summary>
        /// <param name="item">The <see cref="KeyValuePair{TKey, TValue}"/> to add to the collection.</param>
        public void Add(KeyValuePair<string, SignalboxHours> item)
        {
            _innerCollection.Add(item.Key, item.Value);
            if (item.Value != null)
            {
                item.Value.Modified += ContentsModified;
                OnAdd(item.Value);
            }
        }

        private void ContentsModified(object sender, ModifiedEventArgs e)
        {
            if (e != null)
            {
                OnContentsModified(e.ModifiedItem as SignalboxHours);
            }
        }

        /// <summary>
        /// Add an item to the collection.
        /// </summary>
        /// <param name="key">The key to use to retrieve the item.</param>
        /// <param name="value">The <see cref="SignalboxHours" /> object to add.</param>
        public void Add(string key, SignalboxHours value)
        {
            Add(new KeyValuePair<string, SignalboxHours>(key, value));
        }

        /// <summary>
        /// Clear the contents of the collection.
        /// </summary>
        public void Clear()
        {
            lock (_innerCollection)
            {
                foreach (SignalboxHours hours in _innerCollection.Values)
                {
                    if (hours != null)
                    {
                        hours.Modified -= ContentsModified;
                    }
                }
                _innerCollection.Clear();
            }
        }

        /// <summary>
        /// Determine whether the collection contains a given item.
        /// </summary>
        /// <param name="item">The <see cref="KeyValuePair{TKey, TValue}" /> to search for in the collection.</param>
        /// <returns>True if the collection contains the item, false otherwise.</returns>
        public bool Contains(KeyValuePair<string, SignalboxHours> item)
        {
            return _innerCollection.Contains(item);
        }

        /// <summary>
        /// Determine whether the collection contains an item with the given key.
        /// </summary>
        /// <param name="key">The key to search for in the collection.</param>
        /// <returns>True if the collection contains an item with the given key, false otherwise.</returns>
        public bool ContainsKey(string key)
        {
            return _innerCollection.ContainsKey(key);
        }

        /// <summary>
        /// Copy the contents of the collection into an array.
        /// </summary>
        /// <param name="array">The target array to copy the collection contents into.</param>
        /// <param name="arrayIndex">The index in the array at which to start copying the collection contents.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the arrayIndex parameter is less than zero.</exception>
        /// <exception cref="ArgumentException">Thrown if there is not enough space in the portion of the array following the arrayIndex parameter to copy the collection into.</exception>
        public void CopyTo(KeyValuePair<string, SignalboxHours>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array", "The array parameter cannot be null.");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", "The arrayIndex parameter cannot be negative.");
            }
            if (Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException("The destination array does not contain enough elements to store the collection.");
            }

            int i = 0;
            foreach (KeyValuePair<string, SignalboxHours> item in _innerCollection)
            {
                array[arrayIndex + i] = item;
                ++i;
            }
        }

        /// <summary>
        /// Return an enumerator for the collection.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator<KeyValuePair<string, SignalboxHours>> GetEnumerator()
        {
            return _innerCollection.GetEnumerator();
        }

        /// <summary>
        /// Remove the item with the given key from the collection.
        /// </summary>
        /// <param name="key">The key of the item to remove.</param>
        /// <returns>True if an item with the given key was removed from the collection; false if the colelction did not contain an item with the given key.</returns>
        public bool Remove(string key)
        {
            lock(_innerCollection)
            {
                if (_innerCollection.ContainsKey(key))
                {
                    SignalboxHours hours = _innerCollection[key];
                    _innerCollection.Remove(key);
                    hours.Modified -= ContentsModified;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove an item with the same key as this one from the collection.
        /// </summary>
        /// <param name="item">The item specifying the key to remove.</param>
        /// <returns>True if an item with the same key was removed from the collection; false if the collection does not contain an item with the same key.</returns>
        public bool Remove(KeyValuePair<string, SignalboxHours> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Retrieve an item from the collection by key.
        /// </summary>
        /// <param name="key">The key to look up in the collection.</param>
        /// <param name="value">The variable to set with the retrieved item.</param>
        /// <returns>True if an item was retrieved from the collection; false if the collection did not contain an item with the given key.</returns>
        public bool TryGetValue(string key, out SignalboxHours value)
        {
            lock (_innerCollection)
            {
                if (_innerCollection.ContainsKey(key))
                {
                    value = _innerCollection[key];
                    return true;
                }
            }

            value = null;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerCollection.GetEnumerator();
        }
    }
}
