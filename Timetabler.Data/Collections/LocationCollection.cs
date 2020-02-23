using System;
using System.Collections.Generic;
using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// Collection class for <see cref="Location"/> objects.
    /// </summary>
    public class LocationCollection : BaseCollection<Location>
    {
        /// <summary>
        /// Delegate type for event handlers for location-related events.
        /// </summary>
        /// <param name="sender">The collection that has raised the event.</param>
        /// <param name="e">The arguments to the event.</param>
        public delegate void LocationEventHandler(object sender, LocationEventArgs e);

        /// <summary>
        /// Event raised when a <see cref="Location"/> is added to the collection.
        /// </summary>
        public event LocationEventHandler LocationAdd;

        /// <summary>
        /// Event raised when a <see cref="Location"/> is removed from the collection.
        /// </summary>
        public event LocationEventHandler LocationRemove;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocationCollection()
        {

        }

        /// <summary>
        /// Constructor which sets the collection's initial contents.
        /// </summary>
        /// <param name="contents"></param>
        public LocationCollection(IEnumerable<Location> contents)
        {
            InnerCollection.AddRange(contents);
        }

        /// <summary>
        /// Raises the <see cref="LocationAdd"/> event.
        /// </summary>
        /// <param name="item">The <see cref="Location"/> which has been added to the collection.</param>
        /// <param name="idx">The index at which the item was added to the collection.</param>
        protected override void OnAdd(Location item, int? idx)
        {
            LocationAdd?.Invoke(this, new LocationEventArgs { Location = item });
        }

        /// <summary>
        /// Raises the <see cref="LocationRemove"/> event.
        /// </summary>
        /// <param name="item">The <see cref="Location"/> which has been removed from the collection.</param>
        /// <param name="idx">The former index of the <see cref="Location"/> which has been removed from the collection.</param>
        protected override void OnRemove(Location item, int idx)
        {
            LocationRemove?.Invoke(this, new LocationEventArgs { Location = item });
        }

        /// <summary>
        /// Sort the contents of the collection using the provided comparer.
        /// </summary>
        /// <param name="locationComparer">The <see cref="LocationComparer"/> to use to order the collection contents.</param>
        public void Sort(LocationComparer locationComparer)
        {
            InnerCollection.Sort(locationComparer);
        }

        /// <summary>
        /// Placeholder.  Intended to raise the LocationModified event when that is implemented.
        /// </summary>
        /// <param name="item">The <see cref="Location" /> which has been modified.</param>
        protected override void OnContentsModified(Location item)
        {
            
        }
    }
}
