namespace Timetabler.Data.Display.Interfaces
{
    /// <summary>
    /// An entry in a timetable that relates to a row that is specific to a location.
    /// </summary>
    public interface ILocationEntry
    {
        /// <summary>
        /// The ID of the row (the ID of the location plus any suffix indicating what type of row this is).
        /// </summary>
        string LocationKey { get; set; }

        /// <summary>
        /// The ID of the location.
        /// </summary>
        string LocationId { get; set; }

        /// <summary>
        /// The text to display in the row.
        /// </summary>
        string DisplayedText { get; set; }

        /// <summary>
        /// A class which may be responsible for publishing changes to the displayed appearance of this location entry.
        /// </summary>
        ILocationEntryDisplayAdapter DisplayAdapter { get; set; }

        /// <summary>
        /// The type of entry this is (ie time, routing code, footnote, arrow etc)
        /// </summary>
        TrainLocationTimeEntryType EntryType { get; set; }

        /// <summary>
        /// Create a deep copy of this entry.
        /// </summary>
        /// <returns>An <see cref="ILocationEntry" /> instance which is a deep copy of this instance.</returns>
        ILocationEntry Copy();
    }
}
