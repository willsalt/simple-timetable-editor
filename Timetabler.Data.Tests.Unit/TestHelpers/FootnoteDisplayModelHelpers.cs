using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class FootnoteDisplayModelHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

        public static FootnoteDisplayModel GetFootnoteDisplayModel()
        {
            return new FootnoteDisplayModel
            {
                NoteId = _rnd.NextHexString(8),
                Definition = _rnd.NextString(_rnd.Next(50)),
                DisplayOnPage = _rnd.NextBoolean(),
                Symbol = _rnd.NextString(1),
            };
        }

        public static void FullEqualityTest(FootnoteDisplayModel a, FootnoteDisplayModel b)
        {
            if (a is null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            if (b is null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            Assert.AreEqual(a.NoteId, b.NoteId);
            Assert.AreEqual(a.Symbol, b.Symbol);
            Assert.AreEqual(a.Definition, b.Definition);
            Assert.AreEqual(a.DisplayOnPage, b.DisplayOnPage);
        }
    }
}
