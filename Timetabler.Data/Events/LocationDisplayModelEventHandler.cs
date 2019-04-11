using Timetabler.Data.Display;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// Delegate type for handling <see cref="LocationDisplayModel" />-related events. 
    /// </summary>
    /// <param name="sender">The object which raised the event.</param>
    /// <param name="e">The event arguments.</param>
    public delegate void LocationDisplayModelEventHandler(object sender, LocationDisplayModelEventArgs e);
}
