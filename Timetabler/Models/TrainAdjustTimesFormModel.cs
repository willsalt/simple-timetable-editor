using System.Collections.Generic;
using Timetabler.CoreData;
using Timetabler.Data;

namespace Timetabler.Models
{
    /// <summary>
    /// The data model for the TrainAdjustTimesForm form.
    /// </summary>
    public class TrainAdjustTimesFormModel
    {
        /// <summary>
        /// Whether the time offset should be added or subtracted.
        /// </summary>
        public AddSubtract AddSubtract { get; set; }

        /// <summary>
        /// List of valid locations for the locations combobox.
        /// </summary>
        public List<Location> ValidLocations { get; private set; }

        /// <summary>
        /// The selected location in the locations combobox.
        /// </summary>
        public Location SelectedLocation { get; set; }

        /// <summary>
        /// Whether or not the time offset should be added from the arrival time or the departure time of the selected location.
        /// </summary>
        public ArrivalDepartureOptions ArriveDepart { get; set; }

        /// <summary>
        /// The time offset to add or subtract, in minutes.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="validLocations">The locations that this train stops at or passes.</param>
        public TrainAdjustTimesFormModel(IEnumerable<Location> validLocations)
        {
            ValidLocations = new List<Location>();
            ValidLocations.AddRange(validLocations);
        }
    }
}
