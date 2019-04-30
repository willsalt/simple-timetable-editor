using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// A timetable entry that relates to a location and contains generic text.
    /// </summary>
    public class LocationEntryModel : GenericEntryModel, ILocationEntry
    {
        /// <summary>
        /// The ID of the row this entry belongs to.
        /// </summary>
        public string LocationKey { get; set; }

        /// <summary>
        /// The ID of the location.
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Create a copy of this instance.
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        public new LocationEntryModel Copy()
        {
            return new LocationEntryModel
            {
                DisplayedText = DisplayedText,
                EntryType = EntryType,
                LocationKey = LocationKey,
                LocationId = LocationId,
            };
        }

        /// <summary>
        /// Create a copy of this instance, typed as <see cref="ILocationEntry" />. 
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        ILocationEntry ILocationEntry.Copy()
        {
            return Copy();
        }
    }
}
