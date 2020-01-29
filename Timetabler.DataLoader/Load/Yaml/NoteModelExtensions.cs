using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class NoteModelExtensions
    {
        public static Note ToNote(this NoteModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
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
