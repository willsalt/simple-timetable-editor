namespace Timetabler.CoreData
{
    /// <summary>
    /// Standard "magic strings" used to distinguish different timetable rows for the same location.
    /// </summary>
    public static class LocationIdSuffixes
    {
        /// <summary>
        /// "Path" rows.
        /// </summary>
        public const string Path = "-0p";

        /// <summary>
        /// "Arrival" rows.
        /// </summary>
        public const string Arrival = "-2a";

        /// <summary>
        /// "Platform" rows.
        /// </summary>
        public const string Platform = "-4t";

        /// <summary>
        /// "Departure" rows.
        /// </summary>
        public const string Departure = "-6d";

        /// <summary>
        /// "Line" rows.
        /// </summary>
        public const string Line = "-8l";
    }
}
