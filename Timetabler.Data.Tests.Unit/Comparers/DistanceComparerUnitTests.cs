using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.Data.Comparers;
using Timetabler.Data.Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Unit.Comparers
{
    [TestClass]
    public class DistanceComparerUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DistanceComparerClass_CompareMethod_Returns0_IfParametersAreEqual()
        {
            DistanceComparer testObject = new DistanceComparer();
            Distance testParam0 = _rnd.NextDistance();
            Distance testParam1 = new Distance(testParam0.Mileage, testParam0.Chainage);

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void DistanceComparerClass_CompareMethod_ReturnsMinus1_IfSecondParameterIsGreaterThanFirstParameter()
        {
            DistanceComparer testObject = new DistanceComparer();
            Distance testParam0 = _rnd.NextDistance();
            Distance testParam1 = _rnd.NextDistance(testParam0);

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void DistanceComparerClass_CompareMethod_Returns1_IfFirstParameterIsGreaterThanSecondParameter()
        {
            DistanceComparer testObject = new DistanceComparer();
            Distance testParam1 = _rnd.NextDistance();
            Distance testParam0 = _rnd.NextDistance(testParam1);

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
