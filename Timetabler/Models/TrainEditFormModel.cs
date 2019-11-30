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
        public LocationCollection ValidLocations { get; private set; }

        /// <summary>
        /// A list of train classes this train may belong to, for combo-box population.
        /// </summary>
        public TrainClassCollection ValidClasses { get; private set; }

        /// <summary>
        /// A list of footnotes which may be applied to this train.
        /// </summary>
        public List<Note> ValidTrainNotes { get; private set; }

        /// <summary>
        /// A list of footnotes which may be applied to this train's timing points.
        /// </summary>
        public List<Note> ValidTimingPointNotes { get; private set; }

        /// <summary>
        /// Document Options - so that we know what time input mode to use.
        /// </summary>
        public DocumentOptions DocumentOptions { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="locations">Valid locations for timing points.</param>
        /// <param name="classes">Valid train classes.</param>
        /// <param name="trainNotes">Valid footnotes that may appear in train headers.</param>
        /// <param name="timingPointNotes">Valid footnotes that may appear in timing points.</param>
        public TrainEditFormModel(LocationCollection locations, TrainClassCollection classes, IEnumerable<Note> trainNotes, IEnumerable<Note> timingPointNotes)
        {
            ValidLocations = locations;
            ValidClasses = classes;
            ValidTrainNotes = new List<Note>();
            ValidTimingPointNotes = new List<Note>();
            if (trainNotes != null)
            {
                ValidTrainNotes.AddRange(trainNotes);
            }
            if (timingPointNotes != null)
            {
                ValidTimingPointNotes.AddRange(timingPointNotes);
            }
        }
    }
}
