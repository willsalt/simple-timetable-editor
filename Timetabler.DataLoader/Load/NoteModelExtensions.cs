using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for the <see cref="NoteModel" /> class.
    /// </summary>
    public static class NoteModelExtensions
    {
        /// <summary>
        /// Converts a <see cref="NoteModel" /> instance into a <see cref="Note" /> instance.
        /// </summary>
        /// <param name="model">The instance to be converted.</param>
        /// <returns>A <see cref="Note" /> instance that is equivalent to the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c></exception>
        public static Note ToNote(this NoteModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }
            if (string.IsNullOrWhiteSpace(model.Id))
            {
                throw new ArgumentException("ID missing");
            }

            return new Note
            {
                Id = model.Id,
                Symbol = model.Symbol,
                Definition = model.Definition,
                AppliesToTrains = model.AppliesToTrains ?? false,
                AppliesToTimings = model.AppliesToTimings ?? false,
                DefinedInGlossary = model.DefinedInGlossary ?? false,
                DefinedOnPages = model.DefinedOnPages ?? false,
            };
        }
    }
}
