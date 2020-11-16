using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Comparers
{
    [TestClass]
    public class VertexInformationTimeBasedComparerUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static ArrivalDepartureOptions GetArrivalDepartureOptions()
        {
            return (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
        }

        private static VertexInformation GetVertexInformation(TimeOfDay time)
        {
            return new VertexInformation(new TrainDrawingInfo { Train = new Train() }, time, GetArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble());
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsMinusOne_IfTimePropertyOfFirstParameterIsBeforeTimePropertyOfSecondParameter()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDayBefore(86398)); // make sure there are a couple of seconds left in the day
            VertexInformation testParam1 = GetVertexInformation(_rnd.NextTimeOfDayAfter(testParam0.Time));
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsZero_IfTImePropertyOfFirstParameterIsEqualToTimePropertyOfSecondParameter()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformation testParam1 = GetVertexInformation(testParam0.Time.Copy());
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsZero_IfTImePropertyOfFirstParameterIsSameAsTimePropertyOfSecondParameter()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformation testParam1 = GetVertexInformation(testParam0.Time);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsOne_IfTimePropertyOfFirstParameterIsAfterTimePropertyOfSecondParameter()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDayAfter(1));
            VertexInformation testParam1 = GetVertexInformation(_rnd.NextTimeOfDayBefore(testParam0.Time));
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsMinusOne_IfFirstParameterIsNullAndSecondParameterIsNotNullAndHasNonNullTimeProperty()
        {
            VertexInformation testParam0 = null;
            VertexInformation testParam1 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsMinusOne_IfFirstParameterHasNullTimePropertyAndSecondParameterIsNotNullAndHasNonNullTimeProperty()
        {
            VertexInformation testParam0 = GetVertexInformation(null);
            VertexInformation testParam1 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsOne_IfFirstParameterIsNotNullAndHasNonNullTimePropertyAndSecondParameterIsNull()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformation testParam1 = null;
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsOne_IfFirstParameterIsNotNullAndHasNonNullTimePropertyAndSecondParameterHasNullTimeProperty()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformation testParam1 = GetVertexInformation(null);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsZero_IfBothParametersAreNull()
        {
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(null, null);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsZero_IfFirstParameterIsNullAndSecondParameterHasNullTimeProperty()
        {
            VertexInformation testParam = GetVertexInformation(null);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(null, testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsZero_IfFirstParameterHasNullTimePropertyAndSecondParameterIsNull()
        {
            VertexInformation testParam = GetVertexInformation(null);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam, null);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClass_CompareMethod_ReturnsZero_IfBothParametersHaveNullTimeProperty()
        {
            VertexInformation testParam0 = GetVertexInformation(null);
            VertexInformation testParam1 = GetVertexInformation(null);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
