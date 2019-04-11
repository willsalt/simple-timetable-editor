namespace Timetabler.Data
{
    /// <summary>
    /// Timetable-level configurable options.
    /// </summary>
    public class DocumentOptions
    {
        /// <summary>
        /// Whether this timetable uses the 12-hour or 24-hour clock.
        /// </summary>
        public ClockType ClockType { get; set; }

        /// <summary>
        /// Whether or not to display train labels on graphs.
        /// </summary>
        public bool DisplayTrainLabelsOnGraphs { get; set; }

        /// <summary>
        /// Produce a shallow copy of this instance (at present all properties are value types).
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        public DocumentOptions Copy()
        {
            return new DocumentOptions { ClockType = ClockType, DisplayTrainLabelsOnGraphs = DisplayTrainLabelsOnGraphs };
        }
    }
}
