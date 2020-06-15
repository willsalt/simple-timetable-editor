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
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsZeroWhenBothParametersAreNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = null;
            GenericTimeModel testParam1 = null;

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsZero_IfFirstParameterIsNullAndSecondParameterIsObjectWithActualTimePropertyEqualToNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = null;
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = null };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsZero_IfFirstParameterIsObjectWithActualTimePropertyEqualToNullAndSecondParameterIsNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = null };
            GenericTimeModel testParam1 = null;

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsZero_IfBothParametersAreObjectsWithActualTimePropertyEqualToNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = null };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = null };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsMinusOne_IfFirstParameterIsNullAndSecondParameterIsValidObject()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = null;
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsMinusOne_IfFirstParameterHasNullActualTimePropertyAndSecondParameterIsValidObject()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = null };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsOne_IfFirstParameterIsValidObjectAndSecondParameterIsNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };
            GenericTimeModel testParam1 = null;

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsOne_IfFirstParameterIsValidObjectAndSecondParameterHasNullActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = null };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsZero_IfFirstParameterActualTimePropertyIsEqualToSecondParameterActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = testParam0.ActualTime.Copy() };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsZero_IfFirstParameterActualTimePropertyIsSameAsSecondParameterActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay() };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = testParam0.ActualTime };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsMinusOne_IfFirstParameterActualTimePropertyIsBeforeSecondParameterActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDayBefore(86398) };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDayAfter(testParam0.ActualTime) };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClass_CompareMethod_ReturnsOne_IfFirstParameterActualTimePropertyIsAfterSecondParameterActualTimeProperty()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDayAfter(2) };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDayBefore(testParam0.ActualTime) };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
