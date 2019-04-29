using System.Collections.Generic;
using Timetabler.Data;

namespace Timetabler.Models
{
    public class NoteListEditFormModel
    {
        public Dictionary<string, Note> Data { get; set; } = new Dictionary<string, Note>();

        public bool ExistingNoteChanged { get; set; } = false;
    }
}
