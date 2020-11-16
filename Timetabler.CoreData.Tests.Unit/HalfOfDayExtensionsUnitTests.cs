using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Providers;

namespace Timetabler.CoreData.Tests.Unit
{
    [TestClass]
    public class HalfOfDayExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToNameStringMethod_ReturnsExpectedResult_IfValueOfFirstParameterIsAm()
        {
            HalfOfDay testParam0 = HalfOfDay.AM;

            string testOutput = testParam0.ToNameString();

            Assert.AreEqual(Resources.HalfOfDay_ToNameString_Am, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToNameStringMethod_ReturnsExpectedResult_IfValueOfFirstParameterIsPm()
        {
            HalfOfDay testParam0 = HalfOfDay.PM;

            string testOutput = testParam0.ToNameString();

            Assert.AreEqual(Resources.HalfOfDay_ToNameString_Pm, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToNameStringMethod_ReturnsExpectedResult_IfValueOfFirstParameterIsNoon()
        {
            HalfOfDay testParam0 = HalfOfDay.Noon;

            string testOutput = testParam0.ToNameString();

            Assert.AreEqual(Resources.HalfOfDay_ToNameString_Noon, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToNameStringMethod_ReturnsExpectedResult_IfValueOfFirstParameterIsNotAValidEnumValue()
        {
            HalfOfDay testParam0 = (HalfOfDay)_rnd.Next(10, int.MaxValue);

            string testOutput = testParam0.ToNameString();

            Assert.AreEqual(Resources.HalfOfDay_ToNameString_Am, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
