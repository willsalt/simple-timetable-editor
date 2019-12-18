using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// Collection class for <see cref="Signalbox"/> objects.
    /// </summary>
    public class SignalboxCollection : BaseCollection<Signalbox>
    {
        /// <summary>
        /// Event raised when a <see cref="Signalbox"/> is added to the collection.
        /// </summary>
        public event SignalboxEventHandler SignalboxAdd;

        /// <summary>
        /// Event raised when a <see cref="Signalbox"/> is removed from the collection.
        /// </summary>
        public event SignalboxEventHandler SignalboxRemove;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SignalboxCollection()
        {

        }

        /// <summary>
        /// Constructor which sets initial contents of the collection.
        /// </summary>
        /// <param name="contents">The initial contents of the collection.</param>
        public SignalboxCollection(IEnumerable<Signalbox> contents)
        {
            InnerCollection.AddRange(contents);
        }

        /// <summary>
        /// Returns a copy of this collection, containing copies of the contents of this collection.
        /// </summary>
        /// <returns>A deep copy of the collection.</returns>
        public SignalboxCollection Copy()
        {
            return new SignalboxCollection(this.Select(s => s.Copy()));
        }

        /// <summary>
        /// Raises the <see cref="SignalboxAdd"/> event.
        /// </summary>
        /// <param name="item">The <see cref="Signalbox"/> which was added to the collection.</param>
        /// <param name="idx">The index at which the item was added to the collection.</param>
        protected override void OnAdd(Signalbox item, int? idx)
        {
            SignalboxAdd?.Invoke(this, new SignalboxEventArgs { Signalbox = item, Index = idx });
        }

        /// <summary>
        /// Raises the <see cref="SignalboxRemove"/> event.
        /// </summary>
        /// <param name="item">The <see cref="Signalbox"/> which was removed from the collection.</param>
        /// <param name="idx">The former index of the <see cref="Signalbox"/> which was removed from the collection.</param>
        protected override void OnRemove(Signalbox item, int idx)
        {
            SignalboxRemove?.Invoke(this, new SignalboxEventArgs { Signalbox = item });
        }

        /// <summary>
        /// Placeholder for raising the ContentsModified event, when it is properly implemented.
        /// </summary>
        /// <param name="item">The <see cref="Signalbox"/> which has been modified.</param>
        protected override void OnContentsModified(Signalbox item)
        {

        }
    }
}
