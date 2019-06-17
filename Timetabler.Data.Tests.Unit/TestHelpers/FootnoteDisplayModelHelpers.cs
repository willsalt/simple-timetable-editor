using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class FootnoteDisplayModelHelpers
    {
        private static Random _rnd = new Random();

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
            Assert.AreEqual(a.NoteId, b.NoteId);
            Assert.AreEqual(a.Symbol, b.Symbol);
            Assert.AreEqual(a.Definition, b.Definition);
            Assert.AreEqual(a.DisplayOnPage, b.DisplayOnPage);
        }
    }
}
