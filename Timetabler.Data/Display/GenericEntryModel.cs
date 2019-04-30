using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// An item of data that appears on a timetable.
    /// </summary>
    public class GenericEntryModel
    {
        private string _displayedText;

        /// <summary>
        /// The data to display.
        /// </summary>
        public string DisplayedText
        {
            get
            {
                return _displayedText;
            }
            set
            {
                _displayedText = value;
                DisplayAdapter?.DisplayedTextChanged(value);
            }
        }

        private ILocationEntryDisplayAdapter _displayAdapter;

        /// <summary>
        /// An adapter class which will be called when the <see cref="DisplayedText"/> property changes.
        /// </summary>
        public ILocationEntryDisplayAdapter DisplayAdapter
        {
            get
            {
                return _displayAdapter;
            }
            set
            {
                _displayAdapter = value;
                _displayAdapter?.DisplayedTextChanged(_displayedText);
            }
        }

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
