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

#pragma warning disable CA5394 // Do not use insecure randomness

        public static FootnoteDisplayModel GetFootnoteDisplayModel()
        {
            return new FootnoteDisplayModel(_rnd.NextHexString(8), _rnd.NextString(_rnd.Next(50)), _rnd.NextString(1), _rnd.NextBoolean());
        }

#pragma warning restore CA5394 // Do not use insecure randomness

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
