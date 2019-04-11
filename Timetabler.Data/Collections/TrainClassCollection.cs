using System;
using System.Collections.Generic;
using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// A collection class for <see cref="TrainClass"/> objects.
    /// </summary>
    public class TrainClassCollection : BaseCollection<TrainClass>
    {
        /// <summary>
        /// Delegate type for event handlers for changes to this collection.
        /// </summary>
        /// <param name="sender">The collection which has raised the event.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void TrainClassEventHandler(object sender, TrainClassEventArgs e);

        /// <summary>
        /// Event raised when an object is added to the collection.
        /// </summary>
        public event TrainClassEventHandler TrainClassAdd;

        /// <summary>
        /// Event raised when an object is removed from the collection.
        /// </summary>
        public event TrainClassEventHandler TrainClassRemove;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainClassCollection()
        {
        }

        /// <summary>
        /// Constructor which sets initial contents of the collection.
        /// </summary>
        /// <param name="contents">The initial contents of the collection.</param>
        public TrainClassCollection(IEnumerable<TrainClass> contents)
        {
            _innerCollection.AddRange(contents);
        }

        /// <summary>
        /// Raises the <see cref="TrainClassAdd"/> event.
        /// </summary>
        /// <param name="item">The <see cref="TrainClass"/> which has been added to the collection.</param>
        /// <param name="idx">The index at which the <see cref="TrainClass"/> was added to the collection.</param>
        protected override void OnAdd(TrainClass item, int? idx)
        {
            TrainClassAdd?.Invoke(this, new TrainClassEventArgs { TrainClass = item });
        }

        /// <summary>
        /// Raises the <see cref="TrainClassRemove"/> event.
        /// </summary>
        /// <param name="item">The <see cref="TrainClass"/> which has been removed from the collection.</param>
        /// <param name="idx">Former index of the <see cref="TrainClass"/> which has been removed from the collection.</param>
        protected override void OnRemove(TrainClass item, int idx)
        {
            TrainClassRemove?.Invoke(this, new TrainClassEventArgs { TrainClass = item });
        }

        /// <summary>
        /// Placeholder for raising the ContentsModified event, when it is properly implemented.
        /// </summary>
        /// <param name="item">The <see cref="TrainClass"/> to be modified.</param>
        protected override void OnContentsModified(TrainClass item)
        {

        }
    }
}
