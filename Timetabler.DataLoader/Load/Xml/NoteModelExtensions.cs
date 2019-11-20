using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Extension methods for loading a NoteModel into a Note.
    /// </summary>
    public static class NoteModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="NoteModel"/> object to a <see cref="Note"/> object.
        /// </summary>
        /// <param name="model">The object to convert.</param>
        /// <returns>A Note instance.</returns>
        public static Note ToNote(this NoteModel model)
        {
            return new Note
            {
                Id = model.Id,
                Symbol = model.Symbol,
                Definition = model.Definition,
                AppliesToTrains = model.AppliesToTrains,
                AppliesToTimings = model.AppliesToTimings,
                DefinedInGlossary = model.DefinedInGlossary,
                DefinedOnPages = model.DefinedOnPages,
            };
        }
    }
}
