using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;
using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// Collection class for <see cref="TrainSegmentModel" />.
    /// </summary>
    public class TrainSegmentModelCollection : BaseCollection<TrainSegmentModel>
    {
        /// <summary>
        /// Event raised when a <see cref="TrainSegmentModel"/> is removed from the collection. 
        /// </summary>
        public event TrainSegmentModelEventHandler TrainSegmentModelRemove;

        /// <summary>
        /// Event raised when a <see cref="TrainSegmentModel"/> is added to the collection. 
        /// </summary>
        public event TrainSegmentModelEventHandler TrainSegmentModelAdd;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainSegmentModelCollection()
        {

        }

        /// <summary>
        /// Constructor which sets initial contents of the collection.
        /// </summary>
        /// <param name="data">The initial contents of the collection.</param>
        /// <remarks>No <see cref="TrainSegmentModelAdd"/> events are raised when setting the initial contents of the collection.</remarks>
        public TrainSegmentModelCollection(IEnumerable<TrainSegmentModel> data)
        {
            _innerCollection.AddRange(data);
        }

        /// <summary>
        /// Create a deep copy of this collection.
        /// </summary>
        /// <returns>A deep copy of the collection.</returns>
        public TrainSegmentModelCollection Copy()
        {
            return new TrainSegmentModelCollection(_innerCollection.Select(s => s.Copy()));
        }

        /// <summary>
        /// Raises the <see cref="TrainSegmentModelAdd"/> event. 
        /// </summary>
        /// <param name="item">The <see cref="TrainSegmentModel"/> added to the collection.</param>
        /// <param name="idx">The position at which the item has been added to the collection.</param>
        protected override void OnAdd(TrainSegmentModel item, int? idx)
        {
            TrainSegmentModelAdd?.Invoke(this, new TrainSegmentModelEventArgs { Index = idx ?? -1, Model = item });   
        }

        /// <summary>
        /// Currently not implemented.
        /// </summary>
        /// <param name="item"></param>
        protected override void OnContentsModified(TrainSegmentModel item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Raises the <see cref="TrainSegmentModelRemove"/> event. 
        /// </summary>
        /// <param name="item">The <see cref="TrainSegmentModel"/> object that has been removed from the collection.</param>
        /// <param name="index">The former index of the <see cref="TrainSegmentModel"/> before it was removed from the collection.</param>
        protected override void OnRemove(TrainSegmentModel item, int index)
        {
            TrainSegmentModelRemove?.Invoke(this, new TrainSegmentModelEventArgs { Index = index, Model = item });
        }

        /// <summary>
        /// Add a <see cref="TrainSegmentModel"/> to a sorted collection, maintaining the sort order. 
        /// </summary>
        /// <param name="item">The <see cref="TrainSegmentModel"/> to add.</param>
        /// <param name="comparer">The <see cref="TrainSegmentModelComparer"/> to use to determine the sort order.</param>
        /// <remarks>
        /// This method assumes that the collection is already sorted in the order that the passed comparer would recognise.  If not, you may get inconsistent results.  The 
        /// comparer does not need to be provided if the collection is empty.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if the <see cref="TrainSegmentModelComparer"/> parameter is null and the collection is not empty.</exception>
        public void AddSorted(TrainSegmentModel item, TrainSegmentModelComparer comparer)
        {
            lock (_innerCollection)
            {
                // Degenerate case with no sorting required.
                if (_innerCollection.Count == 0)
                {
                    Add(item);
                    return;
                }

                if (comparer == null)
                {
                    throw new ArgumentNullException(nameof(comparer));
                }

                List<TrainSegmentModel> newAdditions = new List<TrainSegmentModel>();
                _innerCollection.Add(item);
                bool eventRaised = false;
                for (var i = _innerCollection.Count - 1; i > 0; i--)
                {
                    var comparison = comparer.Compare(_innerCollection[i], _innerCollection[i - 1]);
                    if (comparison.Item2 != null)
                    {
                        newAdditions.Add(comparison.Item2);
                    }
                    if (comparison.Item1 < 0)
                    {
                        TrainSegmentModel swap = _innerCollection[i];
                        _innerCollection[i] = _innerCollection[i - 1];
                        _innerCollection[i - 1] = swap;
                    }
                    else
                    {
                        OnAdd(item, i);
                        eventRaised = true;
                        break;
                    }
                }

                if (!eventRaised)
                {
                    OnAdd(item, 0);
                }

                foreach (var splitSegment in newAdditions)
                {
                    AddSorted(splitSegment, comparer);
                }
            }
        }
    }
}
