using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// Helper class used when processing train segments.  Consists of an <see cref="ILocationEntry" /> object and its index within the segment.
    /// </summary>
    public class IndexedTrainLocationTimeModel
    {
        /// <summary>
        /// The <see cref="ILocationEntry" /> that this object wraps.
        /// </summary>
        public ILocationEntry Entry { get; set; }

        /// <summary>
        /// A convenience property which casts the <see cref="Entry" /> property to <see cref="TrainLocationTimeModel" /> or is null if the cast is not possible.
        /// </summary>
        public TrainLocationTimeModel Model { get => Entry as TrainLocationTimeModel; }

        /// <summary>
        /// The ordinal index of the entry within its segment.
        /// </summary>
        public int Index { get; set; }
    }
}
