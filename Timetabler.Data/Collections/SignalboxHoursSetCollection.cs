using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// A collection class for <see cref="SignalboxHoursSet" /> objects.
    /// </summary>
    public class SignalboxHoursSetCollection : BaseCollection<SignalboxHoursSet>
    {
        /// <summary>
        /// Delegate type for <see cref="SignalboxHoursSet" />-related events.
        /// </summary>
        /// <param name="sender">The object raising the event.</param>
        /// <param name="eventArgs">The event arguments.</param>
        public delegate void SignalboxHoursSetEventHandler(object sender, SignalboxHoursSetEventArgs eventArgs);

        /// <summary>
        /// Event raised when an object is added to the collection.
        /// </summary>
        public event SignalboxHoursSetEventHandler SignalboxHoursSetAdd;

        /// <summary>
        /// Event raised when an object is removed from the collection.
        /// </summary>
        public event SignalboxHoursSetEventHandler SignalboxHoursSetRemove;

        /// <summary>
        /// Event raised when a member of the collection is modified.
        /// </summary>
        public event SignalboxHoursSetEventHandler SignalboxHoursSetModified;

        /// <summary>
        /// Raises the <see cref="SignalboxHoursSetAdd" /> event.
        /// </summary>
        /// <param name="item">The <see cref="SignalboxHoursSet"/> which has been added to the collection.</param>
        /// <param name="idx">The index of the item within the collection.</param>
        protected override void OnAdd(SignalboxHoursSet item, int? idx)
        {
            SignalboxHoursSetAdd?.Invoke(this, new SignalboxHoursSetEventArgs { HoursSet = item });
        }

        /// <summary>
        /// Raises the <see cref="SignalboxHoursSetRemove" /> event.
        /// </summary>
        /// <param name="item">The <see cref="SignalboxHoursSet" /> which has been removed from the collection.</param>
        /// <param name="idx">Former index of the <see cref="SignalboxHoursSet"/> which has been removed from the collection.</param>
        protected override void OnRemove(SignalboxHoursSet item, int idx)
        {
            SignalboxHoursSetRemove?.Invoke(this, new SignalboxHoursSetEventArgs { HoursSet = item });
        }

        /// <summary>
        /// Raises the <see cref="SignalboxHoursSetModified" /> event.
        /// </summary>
        /// <param name="item">The <see cref="SignalboxHoursSet" /> which has been modified.</param>
        protected override void OnContentsModified(SignalboxHoursSet item)
        {
            SignalboxHoursSetModified?.Invoke(this, new SignalboxHoursSetEventArgs { HoursSet = item });
        }
    }
}
