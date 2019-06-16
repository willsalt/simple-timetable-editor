using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData.Comparers;
using Timetabler.Data;

namespace Timetabler.CoreData.Tests.Unit.Comparers
{
    [TestClass]
    public class ReferenceEqualityComparerUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void ReferenceEqualityComparerClassEqualsMethodReturnsTrueWhenTheSameTimeOfDayObjectIsPassedToBothParameters()
        {
            TimeOfDay testParam = _rnd.NextTimeOfDay();
            ReferenceEqualityComparer testObject = ReferenceEqualityComparer.Default;

            bool testOutput = testObject.Equals(testParam, testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void ReferenceEqualityComparerClassEqualsMethodReturnsFalseWhenTwoDifferentButEqualTimeOfDayObjectsArePassedAsParameters()
        {
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();
            TimeOfDay testParam1 = new TimeOfDay(testParam0.AbsoluteSeconds);
            ReferenceEqualityComparer testObject = ReferenceEqualityComparer.Default;

            bool testOutput = testObject.Equals(testParam0, testParam1);

            Assert.IsFalse(testOutput);
            // Just to double-check that the parameters do compare equal!
            Assert.AreEqual(testParam0, testParam1);
        }
    }
}
