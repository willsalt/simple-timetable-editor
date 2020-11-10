using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="Note" /> class.
    /// </summary>
    public static class NoteExtensions
    {
        /// <summary>
        /// Convert a <see cref="Note" /> object to a <see cref="NoteModel" /> object.
        /// </summary>
        /// <param name="note">The object to be converted.</param>
        /// <returns>A <see cref="NoteModel" /> object containing the same data as the parameter in serialisable form.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
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
