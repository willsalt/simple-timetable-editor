using System;
using Timetabler.Data.Collections;

namespace Timetabler.Data.Events
{
    /// <summary>
    /// The <see cref="EventArgs"/> subclass for events raised by the <see cref="NoteCollection"/> class.
    /// </summary>
    public class NoteEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="Note"/> which triggered the raising of the event.
        /// </summary>
        public Note Note { get; set; }
    }
}
