using System.Collections.Generic;
using Timetabler.Data;

namespace Timetabler.Models
{
    /// <summary>
    /// Model class for the NoteListEditForm dialog
    /// </summary>
    public class NoteListEditFormModel
    {
        /// <summary>
        /// The footnotes currently in the document.
        /// </summary>
        public Dictionary<string, Note> Data { get; set; } = new Dictionary<string, Note>();

        /// <summary>
        /// A flag to indicate whether or not the details of existing notes have been changed whilst the dialog box was open.
        /// If the dialog box is closed using the "OK" button, the value of this flag is used to decide whether to refresh the contents of the train grids.
        /// </summary>
        public bool ExistingNoteChanged { get; set; } = false;
    }
}
