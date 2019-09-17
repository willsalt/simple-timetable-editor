using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TrainTimeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void TrainTimeClassFootnoteSymbolsPropertyHasCorrectValueIfThereAreFootnotes()
        {
            int footnoteCount = _rnd.Next(4) + 1;
            TrainTime testObject = TrainTimeHelpers.GetTrainTime(footnoteCount);
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
            TrainTime testObject = TrainTimeHelpers.GetTrainTime(0);

            string testOutput = testObject.FootnoteSymbols;

            Assert.AreEqual("  ", testOutput);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsDifferentObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectIfTimePropertyIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            testObject.Time = null;

            TrainTime testOutput = testObject.Copy();

            Assert.IsNull(testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectWithTimePropertyThatIsDifferentObjectIfTimePropertyIsNotNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreNotSame(testObject.Time, testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectWithTimePropertyWithCorrectValueIfTimePropertyIsNotNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Time, testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectWithCorrectNumberOfFootnotes()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreEqual(testOutput.Footnotes.Count, testObject.Footnotes.Count);
        }

        [TestMethod]
        public void TrainTimeClassCopyMethodReturnsObjectWithFootnotesPropertyWithSameContents()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.Footnotes.Count; ++i)
            {
                Assert.AreSame(testObject.Footnotes[i], testOutput.Footnotes[i]);
            }
        }

        [TestMethod]
        public void TrainTimeClassCopyAndReflectMethodReturnsDifferentObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainTimeClassCopyAndReflectMethodReturnsObjectIfTimePropertyIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            testObject.Time = null;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.IsNull(testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyAndReflectMethodReturnsObjectWithTimePropertyThatIsDifferentObjectIfTimePropertyIsNotNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.AreNotSame(testObject.Time, testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyAndReflectMethodReturnsObjectWithTimePropertyWithExpectedValueIfTimePropertyIsNotNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.AreEqual(testObject.Time.CopyAndReflect(testParam0), testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClassCopyAndReflectMethodReturnsObjectWithCorrectNumberOfFootnotes()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.AreEqual(testOutput.Footnotes.Count, testObject.Footnotes.Count);
        }

        [TestMethod]
        public void TrainTimeClassCopyAndReflectMethodReturnsObjectWithFootnotesPropertyWithSameContents()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            for (int i = 0; i < testOutput.Footnotes.Count; ++i)
            {
                Assert.AreSame(testObject.Footnotes[i], testOutput.Footnotes[i]);
            }
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsTrueIfTimePropertyOfFirstOperandIsAfterTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeBefore(testParam0.Time);

            bool testOutput = testParam0 > testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsTrueIfTimePropertyOfFirstOperandIsPopulatedAndTimePropertyOfSecondOperandIsNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 > testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsTrueIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = null;

            bool testOutput = testParam0 > testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsFalseIfTimePropertyOfFirstOperandIsBeforeTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAfter(testParam0.Time);

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsFalseIfTimePropertyOfFirstOperandIsEqualToTimePropertOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAt(testParam0.Time);

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsFalseIfTimePropertyOfFirstOperandIsNullAndTimePropertOfSecondOperandIsNotNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsFalseIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsFalseIfTimePropertiesOfBothOperandsAreNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOperatorReturnsFalseIfBothOperandsAreNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsTrueIfTimePropertyOfFirstOperandIsBeforeTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAfter(testParam0.Time);

            bool testOutput = testParam0 < testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsTrueIfTimePropertyOfFirstOperandIsNotPopulatedAndTimePropertyOfSecondOperandIsPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsTrueIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 < testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsFalseIfTimePropertyOfFirstOperandIsAfterTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeBefore(testParam0.Time);

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsFalseIfTimePropertyOfFirstOperandIsEqualToTimePropertOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAt(testParam0.Time);

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsFalseIfTimePropertyOfFirstOperandIsNotNullAndTimePropertOfSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsFalseIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime(); ;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsFalseIfTimePropertiesOfBothOperandsAreNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOperatorReturnsFalseIfBothOperandsAreNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsTrueIfTimePropertyOfFirstOperandIsAfterTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeBefore(testParam0.Time);

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsFalseIfTimePropertyOfFirstOperandIsPopulatedAndTimePropertyOfSecondOperandIsNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 >= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsFalseIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = null;

            bool testOutput = testParam0 >= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsFalseIfTimePropertyOfFirstOperandIsBeforeTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAfter(testParam0.Time);

            bool testOutput = testParam0 >= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsTrueIfTimePropertyOfFirstOperandIsEqualToTimePropertOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAt(testParam0.Time);

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsFalseIfTimePropertyOfFirstOperandIsNullAndTimePropertOfSecondOperandIsNotNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 >= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsFalseIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 >= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsTrueIfTimePropertiesOfBothOperandsAreNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassGreaterThanOrEqualToOperatorReturnsTrueIfBothOperandsAreNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsTrueIfTimePropertyOfFirstOperandIsBeforeTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAfter(testParam0.Time);

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsTrueIfTimePropertyOfFirstOperandIsNotPopulatedAndTimePropertyOfSecondOperandIsPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsTrueIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsFalseIfTimePropertyOfFirstOperandIsAfterTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeBefore(testParam0.Time);

            bool testOutput = testParam0 <= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsTrueIfTimePropertyOfFirstOperandIsEqualToTimePropertOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAt(testParam0.Time);

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsFalseIfTimePropertyOfFirstOperandIsNotNullAndTimePropertOfSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsFalseIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime(); ;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsTrueIfTimePropertiesOfBothOperandsAreNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClassLessThanOrEqualToOperatorReturnsTrueIfBothOperandsAreNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }
    }
}
