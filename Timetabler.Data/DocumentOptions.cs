namespace Timetabler.Data
{
    /// <summary>
    /// Timetable-level configurable options.
    /// </summary>
    public class DocumentOptions
    {
        private ClockType _clockType;

        /// <summary>
        /// Whether this timetable uses the 12-hour or 24-hour clock.
        /// </summary>
        public ClockType ClockType
        {
            get
            {
                return _clockType;
            }
            set
            {
                _clockType = value;
                UpdateFormattingStrings();
            }
        }

        /// <summary>
        /// Whether or not to display train labels on graphs.
        /// </summary>
        public bool DisplayTrainLabelsOnGraphs { get; set; }

        /// <summary>
        /// The correct formatting strings to use for time output, given the current value of the <see cref="ClockType" /> property.  Note that subsequent calls to the get method of this property
        /// may return the same object.  That object's properties are tied to the this object's <see cref="ClockType" /> property and will change if the <see cref="ClockType" /> property 
        /// of this object is changed.
        /// </summary>
        public TimeDisplayFormattingStrings FormattingStrings { get; } = new TimeDisplayFormattingStrings();

        /// <summary>
        /// Produce a shallow copy of this instance
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        public DocumentOptions Copy()
        {
            return new DocumentOptions { ClockType = ClockType, DisplayTrainLabelsOnGraphs = DisplayTrainLabelsOnGraphs };
        }

        /// <summary>
        /// Copies the properties of this object into another <see cref="DocumentOptions" /> object.  This is a shallow copy.
        /// </summary>
        /// <param name="options">The object whose properties will be overwritten with the values of this object's properties.</param>
        public void CopyTo(DocumentOptions options)
        {
            if (options == null)
            {
                return;
            }

            // This test avoids changing all the formatting strings if we don't actually have to.
            if (options.ClockType != ClockType)
            {
                options.ClockType = ClockType;
            }
            options.DisplayTrainLabelsOnGraphs = DisplayTrainLabelsOnGraphs;
        }

        /// <summary>
        /// Update the <see cref="FormattingStrings" /> object's properties when the value of the <see cref="ClockType" /> property has changed.
        /// </summary>
        private void UpdateFormattingStrings()
        {
            const string formatPlaceholder = "{0}";
            switch (_clockType)
            {
                case ClockType.TwelveHourClock:
                default:
                    FormattingStrings.Complete = "h" + formatPlaceholder + "mmf";
                    FormattingStrings.TimeWithoutFootnotes = "h mmf";
                    FormattingStrings.Hours = "h";
                    FormattingStrings.Minutes = "mmf";
                    break;
                case ClockType.TwentyFourHourClock:
                    FormattingStrings.Complete = "HH" + formatPlaceholder + "mmf";
                    FormattingStrings.TimeWithoutFootnotes = "HH mmf";
                    FormattingStrings.Hours = "HH";
                    FormattingStrings.Minutes = "mmf";
                    break;
            }
        }
    }
}
