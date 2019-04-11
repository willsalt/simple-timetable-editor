using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.Data.Collections;

namespace Timetabler.Models
{
    /// <summary>
    /// This model represents the data to be edited by a <see cref="TrainEditForm"/>
    /// </summary>
    public class TrainEditFormModel
    {
        /// <summary>
        /// The train to be edited.
        /// </summary>
        public Train Data { get; set; }

        /// <summary>
        /// A list of locations this train may stop at, for combo-box population.
        /// </summary>
        public LocationCollection ValidLocations { get; set; }

        /// <summary>
        /// A list of train classes this train may belong to, for combo-box population.
        /// </summary>
        public TrainClassCollection ValidClasses { get; set; }

        /// <summary>
        /// A list of footnotes which may be applied to this train.
        /// </summary>
        public List<Note> ValidTrainNotes { get; set; }

        /// <summary>
        /// A list of footnotes which may be applied to this train's timing points.
        /// </summary>
        public List<Note> ValidTimingPointNotes { get; set; }

        /// <summary>
        /// Whether to handle times in 12-hour or 24-hour format.
        /// </summary>
        public ClockType TimeInputMode { get; set; }
    }
}
