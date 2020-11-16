using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class NoteHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static Note GetNote() => new Note
        {
            Id = _rnd.NextHexString(8),
            AppliesToTimings = _rnd.NextBoolean(),
            AppliesToTrains = _rnd.NextBoolean(),
            DefinedInGlossary = _rnd.NextBoolean(),
            DefinedOnPages = _rnd.NextBoolean(),
            Definition = _rnd.NextString(_rnd.Next(100) + 1),
            Symbol = _rnd.NextString(1),
        };

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
