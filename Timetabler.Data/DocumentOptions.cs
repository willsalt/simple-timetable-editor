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

        private TimeDisplayFormattingStrings _formattingStrings = new TimeDisplayFormattingStrings();

        public TimeDisplayFormattingStrings FormattingStrings
        {
            get { return _formattingStrings; }
        }

        /// <summary>
        /// Produce a shallow copy of this instance
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        public DocumentOptions Copy()
        {
            return new DocumentOptions { ClockType = ClockType, DisplayTrainLabelsOnGraphs = DisplayTrainLabelsOnGraphs };
        }

        public void CopyTo(DocumentOptions options)
        {
            if (options == null)
            {
                return;
            }
            options.ClockType = ClockType;
            options.DisplayTrainLabelsOnGraphs = DisplayTrainLabelsOnGraphs;
        }

        private void UpdateFormattingStrings()
        {
            string formatPlaceholder = "{0}";
            switch (_clockType)
            {
                case ClockType.TwelveHourClock:
                default:
                    _formattingStrings.Complete = "h" + formatPlaceholder + "mmf";
                    _formattingStrings.Hours = "h";
                    _formattingStrings.Minutes = "mmf";
                    break;
                case ClockType.TwentyFourHourClock:
                    _formattingStrings.Complete = "HH" + formatPlaceholder + "mmf";
                    _formattingStrings.Hours = "HH";
                    _formattingStrings.Minutes = "mmf";
                    break;
            }
        }
    }
}
