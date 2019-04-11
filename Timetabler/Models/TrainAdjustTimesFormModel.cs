using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<Location> ValidLocations { get; set; }

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
    }
}
