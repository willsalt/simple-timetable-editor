using Timetabler.CoreData.Interfaces;

namespace Timetabler.CoreData.Events
{
    /// <summary>
    /// The event handler type for the <see cref="IWatchableItem.Modified" /> event.
    /// </summary>
    /// <param name="sender">The object which emitted the event.</param>
    /// <param name="e">The event arguments.</param>
    public delegate void ModifiedEventHandler(object sender, ModifiedEventArgs e);
}
