using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.CoreData.Helpers;

namespace Timetabler.CoreData.Tests.Unit.Helpers
{
    [TestClass]
    public class StringHelperUnitTests
    {
        private Random _random;

        private const int MaxTestStringLength = 1024;

        public StringHelperUnitTests()
        {
            _random = new Random();
        }

        [TestMethod]
        public void StripArrivalDepartureSuffixReturnsFirstArgumentIfFirstArgumentDoesNotEndInDashDOrDashA()
        {
            string testString;
            do
            {
                testString = _random.NextString(_random.Next(MaxTestStringLength));
            } while (testString.EndsWith("-a") || testString.EndsWith("-d"));

            string result = testString.StripArrivalDepartureSuffix();

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void StripArrivalDepartureSuffixReturnsFirstArgumentWithoutLastThreeCharactersIfFirstArgumentEndsInArrivalSuffix()
        {
            string expectedResult = _random.NextString(_random.Next(MaxTestStringLength));
            string testString = expectedResult + LocationIdSuffixes.Arrival;

            string result = testString.StripArrivalDepartureSuffix();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void StripArrivalDepartureSuffixReturnsFirstArgumentWithoutLastThreeCharactersIfFirstArgumentEndsInDepartureSuffix()
        {
            string expectedResult = _random.NextString(_random.Next(MaxTestStringLength));
            string testString = expectedResult + LocationIdSuffixes.Departure;

            string result = testString.StripArrivalDepartureSuffix();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
