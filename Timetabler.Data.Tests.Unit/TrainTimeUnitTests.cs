using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TrainTimeUnitTests
    {
        [TestMethod]
        public void TrainTimeClassFootnoteSymbolsPropertyHasCorrectValueIfThereAreFootnotes()
        {
            Random rnd = new Random();
            TrainTime testObject = new TrainTime();
            int footnoteCount = rnd.Next(4) + 1;
            for (int i = 0; i < footnoteCount; ++i)
            {
                testObject.Footnotes.Add(new Note { Symbol = rnd.NextString(1) });
            }

            string testOutput = testObject.FootnoteSymbols;

            Assert.AreEqual(footnoteCount, testOutput.Length);
            for (int i = 0; i < testOutput.Length; ++i)
            {
                Assert.AreEqual(testObject.Footnotes[i].Symbol, testOutput.Substring(i, 1));
            }
        }

        [TestMethod]
        public void TrainTimeClassFootnoteSymbolsPropertyEqualsTwoSpacesIfThereAreNoFootnotes()
        {

            Random rnd = new Random();
            TrainTime testObject = new TrainTime();

            string testOutput = testObject.FootnoteSymbols;

            Assert.AreEqual("  ", testOutput);
        }
    }
}
