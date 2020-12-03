using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Utility.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class NoteHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static Note GetNote(bool definitelyAppliesToTrains = false) => new Note
        {
            Id = _rnd.NextHexString(8),
            AppliesToTimings = _rnd.NextBoolean(),
            AppliesToTrains = definitelyAppliesToTrains ? true : _rnd.NextBoolean(),
            DefinedInGlossary = _rnd.NextBoolean(),
            DefinedOnPages = _rnd.NextBoolean(),
            Definition = _rnd.NextString(_rnd.Next(100) + 1),
            Symbol = _rnd.NextString(1),
        };

        public static IEnumerable<Note> GetNoteList(bool definitelyAppliesToTrains = false)
        {
            int count = _rnd.Next(10);
            for (int i = 0; i < count; ++i)
            {
                yield return GetNote(definitelyAppliesToTrains);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
