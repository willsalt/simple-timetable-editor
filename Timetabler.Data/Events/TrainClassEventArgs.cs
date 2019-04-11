using System;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// The <see cref="EventArgs"/> class for events relating to a <see cref="TrainClass"/>.
    /// </summary>
    public class TrainClassEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="TrainClass"/> to which the event relates.
        /// </summary>
        public TrainClass TrainClass { get; set; }
    }
}
