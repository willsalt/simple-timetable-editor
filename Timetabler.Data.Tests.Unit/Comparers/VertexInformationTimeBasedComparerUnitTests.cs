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

        private static ArrivalDepartureOptions GetArrivalDepartureOptions()
        {
            return (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
        }

        private static VertexInformation GetVertexInformation(TimeOfDay time)
        {
            return new VertexInformation(new TrainDrawingInfo { Train = new Train() }, time, GetArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble());
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsMinusOneIfTimePropertyOfFirstParameterIsBeforeTimePropertyOfSecondParameter()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDayBefore(86398)); // make sure there are a couple of seconds left in the day
            VertexInformation testParam1 = GetVertexInformation(_rnd.NextTimeOfDayAfter(testParam0.Time));
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsZeroIfTImePropertyOfFirstParameterIsEqualToTimePropertyOfSecondParameter()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformation testParam1 = GetVertexInformation(testParam0.Time.Copy());
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsZeroIfTImePropertyOfFirstParameterIsSameAsTimePropertyOfSecondParameter()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformation testParam1 = GetVertexInformation(testParam0.Time);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsOneIfTimePropertyOfFirstParameterIsAfterTimePropertyOfSecondParameter()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDayAfter(1));
            VertexInformation testParam1 = GetVertexInformation(_rnd.NextTimeOfDayBefore(testParam0.Time));
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsMinusOneIfFirstParameterIsNullAndSecondParameterIsNotNullAndHasNonNullTimeProperty()
        {
            VertexInformation testParam0 = null;
            VertexInformation testParam1 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsMinusOneIfFirstParameterHasNullTimePropertyAndSecondParameterIsNotNullAndHasNonNullTimeProperty()
        {
            VertexInformation testParam0 = GetVertexInformation(null);
            VertexInformation testParam1 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsOneIfFirstParameterIsNotNullAndHasNonNullTimePropertyAndSecondParameterIsNull()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformation testParam1 = null;
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsOneIfFirstParameterIsNotNullAndHasNonNullTimePropertyAndSecondParameterHasNullTimeProperty()
        {
            VertexInformation testParam0 = GetVertexInformation(_rnd.NextTimeOfDay());
            VertexInformation testParam1 = GetVertexInformation(null);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsZeroIfBothParametersAreNull()
        {
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(null, null);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsZeroIfFirstParameterIsNullAndSecondParameterHasNullTimeProperty()
        {
            VertexInformation testParam = GetVertexInformation(null);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(null, testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsZeroIfFirstParameterHasNullTimePropertyAndSecondParameterIsNull()
        {
            VertexInformation testParam = GetVertexInformation(null);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam, null);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void VertexInformationTimeBasedComparerClassCompareMethodReturnsZeroIfBothParametersHaveNullTimeProperty()
        {
            VertexInformation testParam0 = GetVertexInformation(null);
            VertexInformation testParam1 = GetVertexInformation(null);
            VertexInformationTimeBasedComparer testObject = new VertexInformationTimeBasedComparer();

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }
    }
}
