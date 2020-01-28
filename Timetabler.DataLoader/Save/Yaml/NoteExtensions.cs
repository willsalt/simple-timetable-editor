using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class NoteExtensions
    {
        public static NoteModel ToYamlNoteModel(this Note note)
        {
            if (note is null)
            {
                throw new NullReferenceException();
            }

            return new NoteModel
            {
                Id = note.Id,
                Symbol = note.Symbol,
                AppliesToTimings = note.AppliesToTimings,
                AppliesToTrains = note.AppliesToTrains,
                DefinedInGlossary = note.DefinedInGlossary,
                DefinedOnPages = note.DefinedOnPages,
                Definition = note.Definition,
            };
        }
    }
}
