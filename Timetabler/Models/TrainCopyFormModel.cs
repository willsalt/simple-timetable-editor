using System;
using Timetabler.Data;

namespace Timetabler.Models
{
    /// <summary>
    /// Model class for <see cref="TrainCopyForm" />.
    /// </summary>
    public class TrainCopyFormModel
    {
        /// <summary>
        /// The ID of the train that this form relates to.
        /// </summary>
        public string TrainId { get; set; }

        /// <summary>
        /// The diagram or headcode of the train that this form relates to.
        /// </summary>
        public string TrainName { get; set; }

        /// <summary>
        /// Whether time offsets should be added or subtracted.
        /// </summary>
        public AddSubtract AddSubtract { get; set; }

        /// <summary>
        /// The size of the time offset.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Whether or not to clear or preserve the inline note field on copy.
        /// </summary>
        public bool ClearInlineNotes { get; set; }

        /// <summary>
        /// Create an instance of this class that applies to a particular <see cref="Train" /> instance.
        /// </summary>
        /// <param name="train">The train to derive a <see cref="TrainCopyFormModel" /> instance from.</param>
        /// <returns>A <see cref="TrainCopyForm" /> with <see cref="TrainId" /> and <see cref="TrainName" /> properties matching the properties of the passed-in train.</returns>
        public static TrainCopyFormModel FromTrain(Train train)
        {
            if (train is null)
            {
                throw new ArgumentNullException(nameof(train));
            }

            return new TrainCopyFormModel
            {
                TrainId = train.Id,
                TrainName = train.Headcode,
                AddSubtract = AddSubtract.Add,
                Offset = 0
            };
        }
    }
}
