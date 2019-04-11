using Timetabler.Data.Display;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// Delegate type for handling <see cref="TrainSegmentModel" />-related events. 
    /// </summary>
    /// <param name="sender">The object raising the event.</param>
    /// <param name="e">The event arguments.</param>
    public delegate void TrainSegmentModelEventHandler(object sender, TrainSegmentModelEventArgs e);
}
