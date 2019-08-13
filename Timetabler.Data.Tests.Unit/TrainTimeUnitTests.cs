using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TrainTimeUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        private TrainTime GetTrainTime(int? footnoteCount = null)
        {
            TrainTime obj = new TrainTime { Time = _rnd.NextTimeOfDay() };
            if (!footnoteCount.HasValue)
            {
                footnoteCount = _rnd.Next(4) + 1;
            }
            for (int i = 0; i < footnoteCount; ++i)
            {
                obj.Footnotes.Add(new Note { Symbol = _rnd.NextString(1) });
            }
            return obj;
        }

        [TestMethod]
        public void TrainTimeClassFootnoteSymbolsPropertyHasCorrectValueIfThereAreFootnotes()
        {
            int footnoteCount = _rnd.Next(4) + 1;
            TrainTime testObject = GetTrainTime(footnoteCount);
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
            TrainTime testObject = GetTrainTime(0);

            string testOutput = testObject.FootnoteSymbols;

            Assert.AreEqual("  ", testOutput);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsDifferentObject()
        {
            TrainTime testObject = GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectIfTimePropertyIsNull()
        {
            TrainTime testObject = GetTrainTime();
            testObject.Time = null;

            TrainTime testOutput = testObject.Copy();

            Assert.IsNull(testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectWithTimePropertyThatIsDifferentObjectIfTimePropertyIsNotNull()
        {
            TrainTime testObject = GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreNotSame(testObject.Time, testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectWithTimePropertyWithCorrectValueIfTimePropertyIsNotNull()
        {
            TrainTime testObject = GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Time, testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectWithCorrectNumberOfFootnotes()
        {
            TrainTime testObject = GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreEqual(testOutput.Footnotes.Count, testObject.Footnotes.Count);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectWithFootnotesPropertyWithSameContents()
        {
            TrainTime testObject = GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.Footnotes.Count; ++i)
            {
                Assert.AreSame(testObject.Footnotes[i], testOutput.Footnotes[i]);
            }
        }
    }
}
