using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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

#pragma warning disable CA1707 // Identifiers should not contain underscores
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainTimeClass_ResolveFootnotesMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            testObject.ResolveFootnotes(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeClass_ResolveFootnotesMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            try
            {
                testObject.ResolveFootnotes(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("allFootnotes", ex.ParamName);
            }
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTimeOfDayParameter_ReturnsMinusOne_IfParameterIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam = null;

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTimeOfDayParameter_ReturnsMinusOne_IfParameterValueIsLaterThanValueOfTimeProperty()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam = _rnd.NextTimeOfDayAfter(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTimeOfDayParameter_ReturnsZero_IfParameterValueIsEqualToTimeProperty()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam = testObject.Time.Copy();

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTimeOfDayParameter_ReturnsOne_IfParameterValueIsBeforeTimeProperty()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam = _rnd.NextTimeOfDayBefore(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTrainTimeParameter_ReturnsMinusOne_IfParameterIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = null;

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTrainTimeParameter_ReturnsMinusOne_IfParameterHasTimePropertyEqualToNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = TrainTimeHelpers.GetTrainTime();
            testParam.Time = null;

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTrainTimeParameter_ReturnsMinusOne_IfParameterHasTimePropertyLaterThanTimePropertyOfThisObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = TrainTimeHelpers.GetTrainTimeAfter(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTrainTimeParameter_ReturnsZero_IfParameterHasTimePropertyEqualToTimePropertyOfThisObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = TrainTimeHelpers.GetTrainTimeAt(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithTrainTimeParameter_ReturnsOne_IfParameterHasTimePropertyBeforeTimePropertyOfThisObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = TrainTimeHelpers.GetTrainTimeBefore(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrainTimeClass_CompareToMethodWithObjectParameter_ThrowsArgumentException_IfParameterTypeIsNotTrainTimeOrTimeOfDay()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            object testParam = new object();

            _ = testObject.CompareTo(testParam);

            Assert.Fail();
        }
        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithObjectParameter_ReturnsMinusOne_IfParameterIsTimeOfDayObjectWithValueLaterThanValueOfTimeProperty()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            object testParam = _rnd.NextTimeOfDayAfter(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithObjectParameter_ReturnsZero_IfParameterIsTimeOfDayObjectWithValueEqualToTimeProperty()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            object testParam = testObject.Time.Copy();

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithObjectParameter_ReturnsOne_IfParameterIsTimeOfDayObjectWithValueBeforeTimeProperty()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            object testParam = _rnd.NextTimeOfDayBefore(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithObjectParameter_ReturnsMinusOne_IfParameterIsTrainTimeObjectWithTimePropertyEqualToNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testTrainTime = TrainTimeHelpers.GetTrainTime();
            testTrainTime.Time = null;
            object testParam = testTrainTime;

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithObjectParameter_ReturnsMinusOne_IfParameterIsTrainTimeObjectWithTimePropertyLaterThanTimePropertyOfThisObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            object testParam = TrainTimeHelpers.GetTrainTimeAfter(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithObjectParameter_ReturnsZero_IfParameterIsTrainTimeObjectWithTimePropertyEqualToTimePropertyOfThisObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            object testParam = TrainTimeHelpers.GetTrainTimeAt(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CompareToMethodWithObjectParameter_ReturnsOne_IfParameterIsTrainTimeObjectWithTimePropertyBeforeTimePropertyOfThisObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            object testParam = TrainTimeHelpers.GetTrainTimeBefore(testObject.Time);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualityOperator_ReturnsTrue_IfBothOperandsAreNull()
        {
            TrainTime op0 = null;
            TrainTime op1 = null;

            bool testOutput = op0 == op1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualityOperator_ReturnsFalse_IfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime op0 = null;
            TrainTime op1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = op0 == op1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualityOperator_ReturnsFalse_IfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1 = null;

            bool testOutput = op0 == op1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualityOperator_ReturnsFalse_IfOperandTimesAreDifferentAndFootnotesAreDifferent()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1;
            do
            {
                op1 = TrainTimeHelpers.GetTrainTimeNotAt(op0.Time);
            } while (op0.FootnoteSymbols == op1.FootnoteSymbols);

            bool testOutput = op0 == op1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualityOperator_ReturnsFalse_IfOperandTimesAreDifferentAndFootnotesAreSame()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1 = TrainTimeHelpers.GetTrainTimeNotAt(op0.Time, 0);
            op1.Footnotes.AddRange(op0.Footnotes.Select(n => n.Copy()));

            bool testOutput = op0 == op1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualityOperator_ReturnsFalse_IfOperandTimesAreSameAndFootnotesAreDifferent()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1;
            do
            {
                op1 = TrainTimeHelpers.GetTrainTimeAt(op0.Time);
            } while (op0.FootnoteSymbols == op1.FootnoteSymbols);

            bool testOutput = op0 == op1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualityOperator_ReturnsTrue_IfOperandTimesAreSameAndFootnotesAreSame()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1 = TrainTimeHelpers.GetTrainTimeAt(op0.Time, 0);
            op1.Footnotes.AddRange(op0.Footnotes.Select(n => n.Copy()));

            bool testOutput = op0 == op1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_InequalityOperator_ReturnsFalse_IfBothOperandsAreNull()
        {
            TrainTime op0 = null;
            TrainTime op1 = null;

            bool testOutput = op0 != op1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_InequalityOperator_ReturnsTrue_IfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime op0 = null;
            TrainTime op1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = op0 != op1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_InequalityOperator_ReturnsTrue_IfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1 = null;

            bool testOutput = op0 != op1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_InequalityOperator_ReturnsTrue_IfOperandTimesAreDifferentAndFootnotesAreDifferent()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1;
            do
            {
                op1 = TrainTimeHelpers.GetTrainTimeNotAt(op0.Time);
            } while (op0.FootnoteSymbols == op1.FootnoteSymbols);

            bool testOutput = op0 != op1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_InequalityOperator_ReturnsTrue_IfOperandTimesAreDifferentAndFootnotesAreSame()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1 = TrainTimeHelpers.GetTrainTimeNotAt(op0.Time, 0);
            op1.Footnotes.AddRange(op0.Footnotes.Select(n => n.Copy()));

            bool testOutput = op0 != op1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_InequalityOperator_ReturnsTrue_IfOperandTimesAreSameAndFootnotesAreDifferent()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1;
            do
            {
                op1 = TrainTimeHelpers.GetTrainTimeAt(op0.Time);
            } while (op0.FootnoteSymbols == op1.FootnoteSymbols);

            bool testOutput = op0 != op1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_InequalityOperator_ReturnsFalse_IfOperandTimesAreSameAndFootnotesAreSame()
        {
            TrainTime op0 = TrainTimeHelpers.GetTrainTime();
            TrainTime op1 = TrainTimeHelpers.GetTrainTimeAt(op0.Time, 0);
            op1.Footnotes.AddRange(op0.Footnotes.Select(n => n.Copy()));

            bool testOutput = op0 != op1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualsMethod_ReturnsTrue_IfParameterIsTheSameObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = testObject;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualsMethod_ReturnsFalse_IfParameterIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = null;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualsMethod_ReturnsFalse_IfParameterTimeAndFootnotesAreDifferentToObjectTimeAndFootnotes()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam;
            do
            {
                testParam = TrainTimeHelpers.GetTrainTimeNotAt(testObject.Time);
            } while (testObject.FootnoteSymbols == testParam.FootnoteSymbols);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualsMethod_ReturnsFalse_IfParameterTimeIsNotEqualToObjectTimeAndParameterFootnotesAreEqualToObjectFootnotes()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = TrainTimeHelpers.GetTrainTimeNotAt(testObject.Time, 0);
            testParam.Footnotes.AddRange(testObject.Footnotes.Select(n => n.Copy()));

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualsMethod_ReturnsFalse_IfParameterTimePropertyEqualsObjectTimePropertyAndParameterFootnotesPropertyDoesNotEqualObjectFootnotesProperty()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam;
            do
            {
                testParam = TrainTimeHelpers.GetTrainTimeAt(testObject.Time);
            } while (testObject.FootnoteSymbols == testParam.FootnoteSymbols);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_EqualsMethod_ReturnsTrue_IfParameterTimeAndFootnotesPropertiesEqualObjectTimeAndFootnotesProperties()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam = TrainTimeHelpers.GetTrainTimeAt(testObject.Time, 0);
            testParam.Footnotes.AddRange(testObject.Footnotes.Select(n => n.Copy()));

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GetHashCodeMethod_ReturnsSameValueWhenCalledTwiceOnSameObject_IfObjectPropertiesHaveNotChanged()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            int testOutput0 = testObject.GetHashCode();
            int testOutput1 = testObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void TrainTimeClass_GetHashCodeMethod_ReturnsDifferentValueWhenCalledTwiceOnSameObject_IfObjectTimePropertyHasChanged()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            int testOutput0 = testObject.GetHashCode();
            testObject.Time = _rnd.NextBoolean() ? _rnd.NextTimeOfDayAfter(testObject.Time) : _rnd.NextTimeOfDayBefore(testObject.Time);
            int testOutput1 = testObject.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void TrainTimeClass_GetHashCodeMethod_ReturnsDifferentValueWhenCalledTwiceOnSameObject_IfObjectFootnotesPropertyHasChanged()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime(_rnd.Next(1, 5));

            int testOutput0 = testObject.GetHashCode();
            testObject.Footnotes.Clear();
            int testOutput1 = testObject.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void TrainTimeClass_GetHashCodeMethod_ReturnsSameValueWhenCalledOnDifferentObjects_IfObjectsHaveSameTimeAndFootnotesProperties()
        {
            TrainTime testObject0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testObject1 = TrainTimeHelpers.GetTrainTimeAt(testObject0.Time, 0);
            testObject1.Footnotes.AddRange(testObject0.Footnotes.Select(n => n.Copy()));

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void TrainTimeClass_GetHashCodeMethod_ReturnsDifferentValueWhenCalledOnDifferentObjects_IfObjectsHaveDifferentTimeProperty()
        {
            TrainTime testObject0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testObject1 = TrainTimeHelpers.GetTrainTimeNotAt(testObject0.Time, 0);
            testObject1.Footnotes.AddRange(testObject0.Footnotes.Select(n => n.Copy()));

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void TrainTimeClass_GetHashCodeMethod_ReturnsDifferentValueWhenCalledOnDifferentObject_IfObjectsHaveDifferentFootnoteProperties()
        {
            TrainTime testObject0 = TrainTimeHelpers.GetTrainTime(_rnd.Next(1, 5));
            TrainTime testObject1;
            do
            {
                testObject1 = TrainTimeHelpers.GetTrainTimeAt(testObject0.Time);
            } while (testObject0.FootnoteSymbols == testObject1.FootnoteSymbols);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
