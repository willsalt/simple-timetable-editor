using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;
using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// Collection class for <see cref="LocationDisplayModel"/>. 
    /// </summary>
    public class LocationDisplayModelCollection : BaseCollection<LocationDisplayModel>
    {
        /// <summary>
        /// Event raised when a new element is added to the collection.
        /// </summary>
        public event LocationDisplayModelEventHandler LocationDisplayModelAdd;

        /// <summary>
        /// Event raised when an element is removed from the collection.
        /// </summary>
        public event LocationDisplayModelEventHandler LocationDisplayModelRemove;

        /// <summary>
        /// Event raised when the collection's contents are sorted.
        /// </summary>
        public event LocationDisplayModelCollectionEventHandler LocationDisplayModelCollectionSorted;

        /// <summary>
        /// Raises the <see cref="LocationDisplayModelAdd"/> event. 
        /// </summary>
        /// <param name="item">The element which has been added to the collection.</param>
        /// <param name="idx">The index within the collection of the new item.</param>
        protected override void OnAdd(LocationDisplayModel item, int? idx)
        {
            LocationDisplayModelAdd?.Invoke(this, new LocationDisplayModelEventArgs { Model = item, Index = idx });
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="item">The element which has been modified.</param>
        protected override void OnContentsModified(LocationDisplayModel item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Raises the <see cref="LocationDisplayModelRemove" /> event.
        /// </summary>
        /// <param name="item">The element which has been removed from the collection.</param>
        /// <param name="idx">The former index of the element within the collection.</param>
        protected override void OnRemove(LocationDisplayModel item, int idx)
        {
            LocationDisplayModelRemove?.Invoke(this, new LocationDisplayModelEventArgs { Model = item, Index = idx });
        }

        /// <summary>
        /// Raises the <see cref="LocationDisplayModelCollectionSorted" /> event. 
        /// </summary>
        protected virtual void OnSort()
        {
            LocationDisplayModelCollectionSorted?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Sort the collection using the given <see cref="IComparer{LocationDisplayModel}"/>. 
        /// </summary>
        /// <param name="locationDisplayModelComparer">The comparer to use when carrying out the sort.</param>
        public void Sort(IComparer<LocationDisplayModel> locationDisplayModelComparer)
        {
            lock (_innerCollection)
            {
                _innerCollection.Sort(locationDisplayModelComparer);
                foreach (string id in _innerCollection.Select(l => l.LocationId).Distinct())
                {
                    SetDisplaySeparatorPropertiesOfGroup(id);
                }
                OnSort();
            }
        }

        /// <summary>
        /// Returns the first item found in the collection with the given ID, or null if no item with that ID is a member of the collection.
        /// </summary>
        /// <param name="id">The ID of the item to search for.</param>
        /// <returns>The item with the given ID, or null</returns>
        /// <exception cref="ArgumentNullException">Thrown if the id parameter is null.</exception>
        public LocationDisplayModel Find(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            lock (_innerCollection)
            {
                foreach (LocationDisplayModel item in _innerCollection)
                {
                    if (item.LocationKey == id)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Add an element to a sorted collection, using the given <see cref="IComparer{LocationDisplayModel}" /> to determine the location to insert the element at. 
        /// </summary>
        /// <param name="item">The element to be added to the collection.</param>
        /// <param name="comparer">The comparer to use when determining the location the element should be inserted at.</param>
        public int AddSorted(LocationDisplayModel item, LocationDisplayModelComparer comparer)
        {
            lock (_innerCollection)
            {
                if (_innerCollection.Count == 0)
                {
                    Add(item);
                    return Count - 1;
                }

                if (comparer == null)
                {
                    throw new ArgumentNullException(nameof(comparer));
                }

                _innerCollection.Add(item);
                for (var i = _innerCollection.Count - 1; i > 0; i--)
                {
                    var comparison = comparer.Compare(_innerCollection[i], _innerCollection[i - 1]);
                    if (comparison < 0)
                    {
                        LocationDisplayModel swap = _innerCollection[i];
                        _innerCollection[i] = _innerCollection[i - 1];
                        _innerCollection[i - 1] = swap;
                    }
                    else
                    {
                        SetDisplaySeparatorPropertiesOfGroup(item.LocationId);
                        OnAdd(item, i);
                        return i;
                    }
                }

                SetDisplaySeparatorPropertiesOfGroup(item.LocationId);
                OnAdd(item, 0);
                return 0;
            }
        }

        private void SetDisplaySeparatorPropertiesOfGroup(string locationId)
        {
            List<LocationDisplayModel> subList = new List<LocationDisplayModel>();
            for (int i = 0; i < _innerCollection.Count; ++i)
            {
                if (_innerCollection[i].LocationId == locationId)
                {
                    if ((!_innerCollection[i].ParentDisplaySeparatorAbove) || (!_innerCollection[i].ParentDisplaySeparatorBelow))
                    {
                        return;
                    }
                    _innerCollection[i].DisplaySeparatorAbove = false;
                    _innerCollection[i].DisplaySeparatorBelow = false;
                    subList.Add(_innerCollection[i]);
                }
            }

            if (subList.Count == 0)
            {
                return;
            }

            subList[0].DisplaySeparatorAbove = subList[0].ParentDisplaySeparatorAbove;
            subList[subList.Count - 1].DisplaySeparatorBelow = subList[subList.Count - 1].ParentDisplaySeparatorBelow;
        }

        /// <summary>
        /// Add an item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public override void Add(LocationDisplayModel item)
        {
            base.Add(item);
            if (item != null)
            {
                SetDisplaySeparatorPropertiesOfGroup(item.LocationId);
            }
        }

        /// <summary>
        /// Access members of the collection by index.
        /// </summary>
        /// <param name="index">The index of the item to be accessed.</param>
        /// <returns>The item of the collection with the given index.</returns>
        public override LocationDisplayModel this[int index]
        {
            get => base[index];
            set
            {
                base[index] = value;
                if (value != null)
                {
                    SetDisplaySeparatorPropertiesOfGroup(value.LocationId);
                }
            }
        }

        /// <summary>
        /// Remove the first instance of an item from the collection, if present.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        /// <returns>True if the item was removed from the collection; false if the collection did not contain the item.</returns>
        public override bool Remove(LocationDisplayModel item)
        {
            bool val = base.Remove(item);
            if (item != null)
            {
                SetDisplaySeparatorPropertiesOfGroup(item.LocationId);
            }
            return val;
        }

        /// <summary>
        /// Remove the item at a given index.
        /// </summary>
        /// <param name="idx">The index of the item to remove.</param>
        public override void RemoveAt(int idx)
        {
            if (idx < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            lock (_innerCollection)
            {
                if (idx >= _innerCollection.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(idx));
                }

                LocationDisplayModel item = _innerCollection[idx];
                _innerCollection.RemoveAt(idx);
                item.Modified -= ContentsModified;
                OnRemove(item, idx);
            }
        }
    }
}
