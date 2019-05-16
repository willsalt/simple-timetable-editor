using System;
using Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class NoteHelpers
    {
        private static Random _rnd = new Random();

        public static Note GetNote()
        {
            return new Note
            {
                Id = _rnd.NextHexString(8),
                AppliesToTimings = _rnd.NextBoolean(),
                AppliesToTrains = _rnd.NextBoolean(),
                DefinedInGlossary = _rnd.NextBoolean(),
                DefinedOnPages = _rnd.NextBoolean(),
                Definition = _rnd.NextString(_rnd.Next(100) + 1),
                Symbol = _rnd.NextString(1),
            };
        }
    }
}
