using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for converting a <see cref="Note"/> instance into serializable form.
    /// </summary>
    public static class NoteExtensions
    {
        /// <summary>
        /// Convert a <see cref="Note"/> instance into a <see cref="NoteModel"/> instance.
        /// </summary>
        /// <param name="note">The object to be converted.</param>
        /// <returns>A <see cref="NoteModel"/> instance containing the same data as the parameter.</returns>
        public static NoteModel ToNoteModel(this Note note)
        {
            return new NoteModel
            {
                AppliesToTimings = note.AppliesToTimings,
                AppliesToTrains = note.AppliesToTrains,
                DefinedInGlossary = note.DefinedInGlossary,
                DefinedOnPages = note.DefinedOnPages,
                Definition = note.Definition,
                Id = note.Id,
                Symbol = note.Symbol,
            };
        }
    }
}
