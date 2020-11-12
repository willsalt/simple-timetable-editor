using System;
using System.Globalization;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data
{
    /// <summary>
    /// Represents the class of a train - eg, the type of train.
    /// </summary>
    public class TrainClass : IUniqueItem, IWatchableItem
    {
        /// <summary>
        /// The unique ID string of this class.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The code (A, B etc) to display in the header on timetables.
        /// </summary>
        public string TableCode { get; set; }

        /// <summary>
        /// The description of this class (eg Ordinary Passenger).
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Event to be raised when this object is modified.  Not yet implemented.
        /// </summary>
        public event EventHandler<ModifiedEventArgs> Modified;

        /// <summary>
        /// Raises the <see cref="Modified" /> event.
        /// </summary>
        /// <param name="sender">The object which has modified the instance.</param>
        /// <param name="field">The name of the modified property, if only one property has been modified.</param>
        protected void OnModified(object sender, string field)
        {
            Modified?.Invoke(sender, new ModifiedEventArgs(this, field));
        }

        /// <summary>
        /// Create a shallow copy of this instance.
        /// </summary>
        /// <returns>Another instance whose properties have the same values as this.</returns>
        public TrainClass Copy()
        {
            return new TrainClass { Id = Id, TableCode = TableCode, Description = Description };
        }

        /// <summary>
        /// Overwrite all properties of the given instance with the values of those properties in this instance.
        /// </summary>
        /// <param name="tc">The object to be overwritten.</param>
        public void CopyTo(TrainClass tc)
        {
            if (tc == null)
            {
                return;
            }
            tc.Id = Id;
            tc.TableCode = TableCode;
            tc.Description = Description;
        }

        /// <summary>
        /// Convert this object to a string.
        /// </summary>
        /// <returns>A string containing the code and description of this instance.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}: {1}", TableCode, Description);
        }
    }
}
