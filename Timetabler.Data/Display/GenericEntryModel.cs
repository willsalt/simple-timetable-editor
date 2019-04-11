using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// An item of data that appears on a timetable.
    /// </summary>
    public class GenericEntryModel
    {
        /// <summary>
        /// The data to display.
        /// </summary>
        public string DisplayedText { get; set; }

        /// <summary>
        /// The type of data in the cell (eg time, text, continuation arrow, etc).
        /// </summary>
        public TrainLocationTimeEntryType EntryType { get; set; }

        /// <summary>
        /// Returns a deep copy of this instance.
        /// </summary>
        /// <returns>A <see cref="GenericEntryModel"/> that is a copy of this instance.</returns>
        public virtual GenericEntryModel Copy()
        {
            return new GenericEntryModel
            {
                DisplayedText = DisplayedText,
                EntryType = EntryType,
            };
        }
    }
}
