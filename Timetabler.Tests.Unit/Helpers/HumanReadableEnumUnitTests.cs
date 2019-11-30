using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Helpers;

namespace Timetabler.Tests.Unit.Helpers
{
    [TestClass]
    public class HumanReadableEnumUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void HumanReadableEnumClass_ToStringMethod_ReturnsNameProperty()
        {
            string testValue = _rnd.NextString(_rnd.Next(48));
            HumanReadableEnum<ClockType> testObject = new HumanReadableEnum<ClockType> { Value = ClockType.TwelveHourClock, Name = testValue };

            string testOutput = testObject.ToString();

            Assert.AreEqual(testValue, testOutput);
        }
    }
}
