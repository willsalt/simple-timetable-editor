namespace Timetabler.Data
{
    /// <summary>
    /// This class represents a set of formatting strings for converting a time of day to a displayable string.
    /// </summary>
    public class TimeDisplayFormattingStrings
    {
        /// <summary>
        /// The formatting string to display the complete time, including a placeholder for any footnote symbols if appropriate.
        /// </summary>
        public string Complete { get; set; }

        /// <summary>
        /// The formatting string to display the complete time, without any footnotes.
        /// </summary>
        public string TimeWithoutFootnotes { get; set; }

        /// <summary>
        /// The formatting string to display the hours part of the time.
        /// </summary>
        public string Hours { get; set; }

        /// <summary>
        /// The formatting string to display the minutes part of the time.
        /// </summary>
        public string Minutes { get; set; }

        /// <summary>
        /// The formatting string to display a time as a tooltip
        /// </summary>
        public string Tooltip { get; set; }
    }
}
