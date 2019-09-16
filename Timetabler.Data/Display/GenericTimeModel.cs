using Timetabler.CoreData;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// This class represents a cell displayed on a timetable.
    /// </summary>
    public class GenericTimeModel : GenericEntryModel
    {
        /// <summary>
        /// The time, if this is a time entry.
        /// </summary>
        public TimeOfDay ActualTime { get; set; }

        /// <summary>
        /// Return a deep copy of this object.
        /// </summary>
        /// <returns>A <see cref="GenericTimeModel"/> that is a copy of this instance.</returns>
        public new GenericTimeModel Copy()
        {
            return new GenericTimeModel
            {
                ActualTime = ActualTime != null ? ActualTime.Copy() : null,
                DisplayedText = DisplayedText,
                EntryType = EntryType,
            };
        }
    }
}
