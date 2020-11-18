using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class TimeOfDayExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TimeOfDay GetTestObject() => _rnd.NextTimeOfDay();

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimeOfDayExtensions_ToTimeOfDayModelMethod_ReturnsNull_IfParameterIsNull()
        {
            TimeOfDay testParam = null;

            TimeOfDayModel testOutput = testParam.ToTimeOfDayModel();

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TimeOfDayExtensions_ToTimeOfDayModelMethod_ReturnsObjectWithCorrectTimeProperty_IfParameterIsNotNull()
        {
            TimeOfDay testParam = GetTestObject();

            TimeOfDayModel testOutput = testParam.ToTimeOfDayModel();

            string expectedValue = testParam.Hours24.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                testParam.Minutes.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                testParam.Seconds.ToString("d2", CultureInfo.InvariantCulture);
            Assert.AreEqual(expectedValue, testOutput.Time);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
