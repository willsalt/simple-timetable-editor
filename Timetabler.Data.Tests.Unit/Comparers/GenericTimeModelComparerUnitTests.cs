using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Comparers
{
    [TestClass]
    public class GenericTimeModelComparerUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenBothParametersAreNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = null;
            GenericTimeModel testParam1 = null;

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenFirstParameterIsNullAndSecondParameterIsObjectWithActualTimePropertyEqualToNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = null;
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = null };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenFirstParameterIsObjectWithActualTimePropertyEqualToNullAndSecondParameterIsNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = null };
            GenericTimeModel testParam1 = null;

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenBothParametersAreObjectsWithActualTimePropertyEqualToNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = null };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = null };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsMinusOneWhenFirstParameterIsNullAndSecondParameterIsValidObject()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = null;
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsMinusOneWhenFirstParameterHasNullActualTimePropertyAndSecondParameterIsValidObject()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = null };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsOneWhenFirstParameterIsValidObjectAndSecondParameterIsNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };
            GenericTimeModel testParam1 = null;

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsOneWhenFirstParameterIsValidObjectAndSecondParameterHasNullActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = null };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenFirstParameterActualTimePropertyIsEqualToSecondParameterActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = testParam0.ActualTime.Copy() };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenFirstParameterActualTimePropertyIsSameAsSecondParameterActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = testParam0.ActualTime };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsMinusOneWhenFirstParameterActualTimePropertyIsBeforeSecondParameterActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDayBefore(86398) };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDayAfter(testParam0.ActualTime) };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsOneWhenFirstParameterActualTimePropertyIsAfterSecondParameterActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDayAfter(2) };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDayBefore(testParam0.ActualTime) };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }
    }
}
