using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData.Helpers;

namespace Timetabler.CoreData.Tests.Unit.Helpers
{
    [TestClass]
    public class StringHelperUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;
        private const int MaxTestStringLength = 1024;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void StringHelperClass_StripArrivalDepartureSuffixMethod_ReturnsNullIfParameterIsNull()
        {
            string testString = null;

            string result = testString.StripArrivalDepartureSuffix();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void StringHelperClass_StripArrivalDepartureSuffixMethod_ReturnsFirstArgumentIfFirstArgumentDoesNotEndInDashDOrDashA()
        {
            string testString;
            do
            {
                testString = _rnd.NextString(_rnd.Next(MaxTestStringLength));
            } while (testString.EndsWith("-a", StringComparison.InvariantCulture) || testString.EndsWith("-d", StringComparison.InvariantCulture));

            string result = testString.StripArrivalDepartureSuffix();

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void StringHelperClass_StripArrivalDepartureSuffixMethod_ReturnsFirstArgumentWithoutLastThreeCharactersIfFirstArgumentEndsInArrivalSuffix()
        {
            string expectedResult = _rnd.NextString(_rnd.Next(MaxTestStringLength));
            string testString = expectedResult + LocationIdSuffixes.Arrival;

            string result = testString.StripArrivalDepartureSuffix();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void StringHelperClass_StripArrivalDepartureSuffixMethod_ReturnsFirstArgumentWithoutLastThreeCharactersIfFirstArgumentEndsInDepartureSuffix()
        {
            string expectedResult = _rnd.NextString(_rnd.Next(MaxTestStringLength));
            string testString = expectedResult + LocationIdSuffixes.Departure;

            string result = testString.StripArrivalDepartureSuffix();

            Assert.AreEqual(expectedResult, result);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
