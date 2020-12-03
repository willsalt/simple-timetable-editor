using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Extensions;

namespace Timetabler.Data.Tests.Unit.Extensions
{
    [TestClass]
    public class HalfOfDayExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static DocumentExportOptions GetExportOptions() => new DocumentExportOptions
        {
            MorningLabel = _rnd.NextString(_rnd.Next(8)),
            MiddayLabel = _rnd.NextString(_rnd.Next(8)),
            AfternoonLabel = _rnd.NextString(_rnd.Next(8)),
        };

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsAmAndSecondParameterIsNull()
        {
            HalfOfDay testParam0 = HalfOfDay.AM;
            DocumentExportOptions testParam1 = null;
            string expectedResult = testParam0.ToNameString();

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsPmAndSecondParameterIsNull()
        {
            HalfOfDay testParam0 = HalfOfDay.PM;
            DocumentExportOptions testParam1 = null;
            string expectedResult = testParam0.ToNameString();

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsNoonAndSecondParameterIsNull()
        {
            HalfOfDay testParam0 = HalfOfDay.Noon;
            DocumentExportOptions testParam1 = null;
            string expectedResult = testParam0.ToNameString();

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsAmAndSecondParameterIsNotNull()
        {
            HalfOfDay testParam0 = HalfOfDay.AM;
            DocumentExportOptions testParam1 = GetExportOptions();
            string expectedResult = testParam1.MorningLabel;

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsPmAndSecondParameterIsNotNull()
        {
            HalfOfDay testParam0 = HalfOfDay.PM;
            DocumentExportOptions testParam1 = GetExportOptions();
            string expectedResult = testParam1.AfternoonLabel;

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsNoonAndSecondParameterIsNotNull()
        {
            HalfOfDay testParam0 = HalfOfDay.Noon;
            DocumentExportOptions testParam1 = GetExportOptions();
            string expectedResult = testParam1.MiddayLabel;

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithNullableOfHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterIsNullAndSecondParameterIsNull()
        {
            HalfOfDay? testParam0 = null;
            DocumentExportOptions testParam1 = null;
            string expectedResult = "";

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithNullableOfHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsAmAndSecondParameterIsNull()
        {
            HalfOfDay? testParam0 = HalfOfDay.AM;
            DocumentExportOptions testParam1 = null;
            string expectedResult = testParam0.ToNameString();

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithNullableOfHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsPmAndSecondParameterIsNull()
        {
            HalfOfDay? testParam0 = HalfOfDay.PM;
            DocumentExportOptions testParam1 = null;
            string expectedResult = testParam0.ToNameString();

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithNullableOfHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsNoonAndSecondParameterIsNull()
        {
            HalfOfDay? testParam0 = HalfOfDay.Noon;
            DocumentExportOptions testParam1 = null;
            string expectedResult = testParam0.ToNameString();

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithNullableOfHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterIsNullAndSecondParameterIsNotNull()
        {
            HalfOfDay? testParam0 = null;
            DocumentExportOptions testParam1 = GetExportOptions();
            string expectedResult = "";

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithNullableOfHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsAmAndSecondParameterIsNotNull()
        {
            HalfOfDay? testParam0 = HalfOfDay.AM;
            DocumentExportOptions testParam1 = GetExportOptions();
            string expectedResult = testParam1.MorningLabel;

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithNullableOfHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsPmAndSecondParameterIsNotNull()
        {
            HalfOfDay? testParam0 = HalfOfDay.PM;
            DocumentExportOptions testParam1 = GetExportOptions();
            string expectedResult = testParam1.AfternoonLabel;

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void HalfOfDayExtensionsClass_ToCustomStringMethodWithNullableOfHalfOfDayParameter_ReturnsExpectedResult_IfFirstParameterEqualsNoonAndSecondParameterIsNotNull()
        {
            HalfOfDay? testParam0 = HalfOfDay.Noon;
            DocumentExportOptions testParam1 = GetExportOptions();
            string expectedResult = testParam1.MiddayLabel;

            string testOutput = testParam0.ToCustomName(testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
