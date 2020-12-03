using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Tests.Utility.Helpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TrainTimeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainTimeClass_FootnoteSymbolsProperty_HasCorrectValue_IfThereAreFootnotes()
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
        public void TrainTimeClass_FootnoteSymbolsProperty_EqualsTwoSpaces_IfThereAreNoFootnotes()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime(0);

            string testOutput = testObject.FootnoteSymbols;

            Assert.AreEqual("  ", testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CopyMethod_ReturnsDifferentObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CopyMethod_ReturnsObject_IfTimePropertyIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            testObject.Time = null;

            TrainTime testOutput = testObject.Copy();

            Assert.IsNull(testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClass_CopyMethod_ReturnsObjectWithTimePropertyThatIsDifferentObject_IfTimePropertyIsNotNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreNotSame(testObject.Time, testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClass_CopyMethod_ReturnsObjectWithTimePropertyWithCorrectValue_IfTimePropertyIsNotNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Time, testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClass_CopyMethod_ReturnsObjectWithCorrectNumberOfFootnotes()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            Assert.AreEqual(testOutput.Footnotes.Count, testObject.Footnotes.Count);
        }

        [TestMethod]
        public void TrainTimeClass_CopyMethod_ReturnsObjectWithFootnotesPropertyWithSameContents()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();

            TrainTime testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.Footnotes.Count; ++i)
            {
                Assert.AreSame(testObject.Footnotes[i], testOutput.Footnotes[i]);
            }
        }

        [TestMethod]
        public void TrainTimeClass_CopyAndReflectMethod_ReturnsDifferentObject()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_CopyAndReflectMethod_ReturnsObject_IfTimePropertyIsNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            testObject.Time = null;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.IsNull(testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClass_CopyAndReflectMethod_ReturnsObjectWithTimePropertyThatIsDifferentObject_IfTimePropertyIsNotNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.AreNotSame(testObject.Time, testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClass_CopyAndReflectMethod_ReturnsObjectWithTimePropertyWithExpectedValue_IfTimePropertyIsNotNull()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.AreEqual(testObject.Time.CopyAndReflect(testParam0), testOutput.Time);
        }

        [TestMethod]
        public void TrainTimeClass_CopyAndReflectMethod_ReturnsObjectWithCorrectNumberOfFootnotes()
        {
            TrainTime testObject = TrainTimeHelpers.GetTrainTime();
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            TrainTime testOutput = testObject.CopyAndReflect(testParam0);

            Assert.AreEqual(testOutput.Footnotes.Count, testObject.Footnotes.Count);
        }

        [TestMethod]
        public void TrainTimeClass_CopyAndReflectMethod_ReturnsObjectWithFootnotesPropertyWithSameContents()
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
        public void TrainTimeClass_GreaterThanOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsAfterTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeBefore(testParam0.Time);

            bool testOutput = testParam0 > testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsPopulatedAndTimePropertyOfSecondOperandIsNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 > testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOperator_ReturnsTrue_IfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = null;

            bool testOutput = testParam0 > testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsBeforeTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAfter(testParam0.Time);

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsEqualToTimePropertOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAt(testParam0.Time);

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsNullAndTimePropertOfSecondOperandIsNotNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOperator_ReturnsFalse_IfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOperator_ReturnsFalse_IfTimePropertiesOfBothOperandsAreNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOperator_ReturnsFalse_IfBothOperandsAreNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 > testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsBeforeTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAfter(testParam0.Time);

            bool testOutput = testParam0 < testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsNotPopulatedAndTimePropertyOfSecondOperandIsPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsTrue_IfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 < testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsAfterTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeBefore(testParam0.Time);

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsEqualToTimePropertOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAt(testParam0.Time);

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsNotNullAndTimePropertOfSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsFalse_IfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime(); ;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsFalse_IfTimePropertiesOfBothOperandsAreNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOperator_ReturnsFalse_IfBothOperandsAreNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 < testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsAfterTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeBefore(testParam0.Time);

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsPopulatedAndTimePropertyOfSecondOperandIsNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsTrue_IfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = null;

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsBeforeTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAfter(testParam0.Time);

            bool testOutput = testParam0 >= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsEqualToTimePropertOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAt(testParam0.Time);

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsNullAndTimePropertOfSecondOperandIsNotNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 >= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsFalse_IfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 >= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsTrue_IfTimePropertiesOfBothOperandsAreNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_GreaterThanOrEqualToOperator_ReturnsTrue_IfBothOperandsAreNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 >= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsBeforeTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAfter(testParam0.Time);

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsNotPopulatedAndTimePropertyOfSecondOperandIsPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsTrue_IfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsAfterTimePropertyOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeBefore(testParam0.Time);

            bool testOutput = testParam0 <= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsTrue_IfTimePropertyOfFirstOperandIsEqualToTimePropertOfSecondOperand()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTimeAt(testParam0.Time);

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsFalse_IfTimePropertyOfFirstOperandIsNotNullAndTimePropertOfSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsFalse_IfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime(); ;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsTrue_IfTimePropertiesOfBothOperandsAreNotPopulated()
        {
            TrainTime testParam0 = TrainTimeHelpers.GetTrainTime();
            testParam0.Time = null;
            TrainTime testParam1 = TrainTimeHelpers.GetTrainTime();
            testParam1.Time = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TrainTimeClass_LessThanOrEqualToOperator_ReturnsTrue_IfBothOperandsAreNull()
        {
            TrainTime testParam0 = null;
            TrainTime testParam1 = null;

            bool testOutput = testParam0 <= testParam1;

            Assert.IsTrue(testOutput);
        }

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

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void TrainTimeClass_EqualityOperator_ReturnsTrue_IfBothOperandsAreNull()
        {
            TrainTime op0 = null;
            TrainTime op1 = null;

            bool testOutput = op0 == op1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

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

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void TrainTimeClass_InequalityOperator_ReturnsFalse_IfBothOperandsAreNull()
        {
            TrainTime op0 = null;
            TrainTime op1 = null;

            bool testOutput = op0 != op1;

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

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

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
