using System;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.CoreData.Events
{
    /// <summary>
    /// The <see cref="EventArgs" /> subclass used for <see cref="IWatchableItem.Modified" /> events.
    /// </summary>
    public class ModifiedEventArgs : EventArgs
    {
        /// <summary>
        /// The object which has been modified.
        /// </summary>
        public IWatchableItem ModifiedItem { get; set; }

        /// <summary>
        /// The name of the field which has been modified.
        /// </summary>
        public string ModifiedField { get; set; }
    }
}
