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

        [TestMethod]
        public void StripArrivalDepartureSuffixReturnsFirstArgumentIfFirstArgumentDoesNotEndInDashDOrDashA()
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
        public void StripArrivalDepartureSuffixReturnsFirstArgumentWithoutLastThreeCharactersIfFirstArgumentEndsInArrivalSuffix()
        {
            string expectedResult = _rnd.NextString(_rnd.Next(MaxTestStringLength));
            string testString = expectedResult + LocationIdSuffixes.Arrival;

            string result = testString.StripArrivalDepartureSuffix();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void StripArrivalDepartureSuffixReturnsFirstArgumentWithoutLastThreeCharactersIfFirstArgumentEndsInDepartureSuffix()
        {
            string expectedResult = _rnd.NextString(_rnd.Next(MaxTestStringLength));
            string testString = expectedResult + LocationIdSuffixes.Departure;

            string result = testString.StripArrivalDepartureSuffix();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
