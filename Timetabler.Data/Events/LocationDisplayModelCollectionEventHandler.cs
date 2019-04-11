using System;
using Timetabler.Data.Collections;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// Delegate type for handling <see cref="LocationDisplayModelCollection" />-related events. 
    /// </summary>
    /// <param name="sender">The object which raised the event.</param>
    /// <param name="e">The event arguments.</param>
    public delegate void LocationDisplayModelCollectionEventHandler(object sender, EventArgs e);
}
