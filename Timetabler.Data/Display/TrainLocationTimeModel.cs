namespace Timetabler.Data.Display
{
    /// <summary>
    /// This class represents a cell displayed on a timetable, in a location row.
    /// </summary>
    public class TrainLocationTimeModel : GenericTimeModel, ILocationEntry
    {
        /// <summary>
        /// The ID of the row this applies to.
        /// </summary>
        public string LocationKey { get; set; }

        /// <summary>
        /// The ID of the location
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Whether or not the time to display is a passing time or a stopping time (this affects the font used for display).
        /// </summary>
        public bool IsPassingTime { get; set; }

        /// <summary>
        /// The hours part of the time, formatted as text for display.
        /// </summary>
        public string DisplayedTextHours { get; set; }

        /// <summary>
        /// The footnote symbols, formatted for display.
        /// </summary>
        public string DisplayedTextFootnote { get; set; }

        /// <summary>
        /// The minutes part of the time, formatted as text for display.
        /// </summary>
        public string DisplayedTextMinutes { get; set; }

        /// <summary>
        /// Create a deep copy of this object.
        /// </summary>
        /// <returns>A <see cref="TrainLocationTimeModel"/> instance that is a deep copy of this instance.</returns>
        public new TrainLocationTimeModel Copy()
        {
            return new TrainLocationTimeModel
            {
                ActualTime = ActualTime != null ? ActualTime.Copy() : null,
                DisplayedText = DisplayedText,
                DisplayedTextFootnote = DisplayedTextFootnote,
                DisplayedTextHours = DisplayedTextHours,
                DisplayedTextMinutes = DisplayedTextMinutes,
                EntryType = EntryType,
                LocationKey = LocationKey,
                LocationId = LocationId,
                IsPassingTime = IsPassingTime,
            };
        }

        ILocationEntry ILocationEntry.Copy()
        {
            return Copy();
        }
    }
}
