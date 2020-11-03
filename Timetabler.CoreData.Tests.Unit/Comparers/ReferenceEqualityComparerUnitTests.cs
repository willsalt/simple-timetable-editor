using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData.Comparers;

namespace Timetabler.CoreData.Tests.Unit.Comparers
{
    [TestClass]
    public class ReferenceEqualityComparerUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ReferenceEqualityComparerClass_EqualsMethod_ReturnsTrue_IfTheSameTimeOfDayObjectIsPassedToBothParameters()
        {
            TimeOfDay testParam = _rnd.NextTimeOfDay();
            ReferenceEqualityComparer testObject = ReferenceEqualityComparer.Default;

            bool testOutput = testObject.Equals(testParam, testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void ReferenceEqualityComparerClass_EqualsMethod_ReturnsFalse_IfTwoDifferentButEqualTimeOfDayObjectsArePassedAsParameters()
        {
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();
            TimeOfDay testParam1 = new TimeOfDay(testParam0.AbsoluteSeconds);
            ReferenceEqualityComparer testObject = ReferenceEqualityComparer.Default;

            bool testOutput = testObject.Equals(testParam0, testParam1);

            Assert.IsFalse(testOutput);
            // Just to double-check that the parameters do compare equal!
            Assert.AreEqual(testParam0, testParam1);
        }

        [TestMethod]
        public void ReferenceEqualityComparerClass_GetHashCodeMethod_ReturnsSameResultAsRuntimeHelpersGetHashCodeMethod()
        {
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();
            ReferenceEqualityComparer testObject = ReferenceEqualityComparer.Default;
            int expectedOutput = RuntimeHelpers.GetHashCode(testParam0);

            int testOutput = testObject.GetHashCode(testParam0);

            Assert.AreEqual(expectedOutput, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
