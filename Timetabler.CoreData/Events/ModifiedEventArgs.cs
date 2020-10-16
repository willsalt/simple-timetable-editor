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
        public IWatchableItem ModifiedItem { get; private set; }

        /// <summary>
        /// The name of the field which has been modified.
        /// </summary>
        public string ModifiedField { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">The object which has been modified.</param>
        /// <param name="field">The name of the field which has been modified.</param>
        public ModifiedEventArgs(IWatchableItem item, string field)
        {
            ModifiedItem = item;
            ModifiedField = field;
        }
    }
}
