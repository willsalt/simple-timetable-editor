namespace Timetabler.Data.Display
{
    /// <summary>
    /// The possible types of entry cell in a timetable, such as a time, a continuation arrow, an ellipsis, text, and so on.
    /// </summary>
    public enum TrainLocationTimeEntryType
    {
        /// <summary>
        /// A timing point.
        /// </summary>
        Time,

        /// <summary>
        /// A routing code.
        /// </summary>
        RoutingCode,
    }
}
