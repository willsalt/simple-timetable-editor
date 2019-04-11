using Timetabler.CoreData.Events;

namespace Timetabler.CoreData.Interfaces
{
    /// <summary>
    /// An interface describing an object which can raise an event if its properties' values are modified.
    /// </summary>
    public interface IWatchableItem
    {
        /// <summary>
        /// The event raised when any of the object's watchable properties are modified.
        /// </summary>
        event ModifiedEventHandler Modified;
    }
}
