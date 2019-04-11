using System;
using System.Collections;
using System.Collections.Generic;
using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// A collection of trains.
    /// </summary>
    public class TrainCollection : BaseCollection<Train>
    {
        /// <summary>
        /// Event handler delegate type for <see cref="Train"/>-related events.
        /// </summary>
        /// <param name="sender">The object which raised this event.</param>
        /// <param name="e">The arguments to this event.</param>
        public delegate void TrainEventHandler(object sender, TrainEventArgs e);

        /// <summary>
        /// Event raised when a train is added to the collection.
        /// </summary>
        public event TrainEventHandler TrainAdd;

        /// <summary>
        /// Event raised when a train is removed from the collection.
        /// </summary>
        public event TrainEventHandler TrainRemove;

        /// <summary>
        /// Raise the <see cref="TrainAdd"/> event.
        /// </summary>
        /// <param name="item">The train which has been added to the collection.</param>
        /// <param name="idx">The index at which the train was added to the collection.</param>
        protected override void OnAdd(Train item, int? idx)
        {
            TrainAdd?.Invoke(this, new TrainEventArgs { Train = item });
        }

        /// <summary>
        /// Raises the <see cref="TrainRemove"/> event.
        /// </summary>
        /// <param name="item">The <see cref="Train"/> which has been removed from the collection.</param>
        /// <param name="idx">Former index of the <see cref="Train"/> which has been removed from the collection.</param>
        protected override void OnRemove(Train item, int idx)
        {
            TrainRemove?.Invoke(this, new TrainEventArgs { Train = item });
        }

        /// <summary>
        /// Placeholder for raising the ContentsModified event, when it is properly implemented.
        /// </summary>
        /// <param name="item">The <see cref="Train"/> which has been modified.</param>
        protected override void OnContentsModified(Train item)
        {

        }
    }
}
