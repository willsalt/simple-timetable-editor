using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// A collection of trains.
    /// </summary>
    public class TrainCollection : BaseCollection<Train>
    {
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
