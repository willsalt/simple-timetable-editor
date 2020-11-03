using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class StatusUpdateEventArgsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void StatusUpdateEventArgsClass_Constructor_SetsInProgressPropertyToValueOfFirstParameter()
        {
            bool testParam0 = _rnd.NextBoolean();
            double testParam1 = _rnd.NextDouble();
            string testParam2 = _rnd.NextString(_rnd.Next(50));

            StatusUpdateEventArgs testOutput = new StatusUpdateEventArgs(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.InProgress);
        }

        [TestMethod]
        public void StatusUpdateEventArgsClass_Constructor_SetsProgressPropertyToValueOfSecondParameter()
        {
            bool testParam0 = _rnd.NextBoolean();
            double testParam1 = _rnd.NextDouble();
            string testParam2 = _rnd.NextString(_rnd.Next(50));

            StatusUpdateEventArgs testOutput = new StatusUpdateEventArgs(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.Progress);
        }

        [TestMethod]
        public void StatusUpdateEventArgsClass_Constructor_SetsStatusPropertyToValueOfThirdParameter()
        {
            bool testParam0 = _rnd.NextBoolean();
            double testParam1 = _rnd.NextDouble();
            string testParam2 = _rnd.NextString(_rnd.Next(50));

            StatusUpdateEventArgs testOutput = new StatusUpdateEventArgs(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.Status);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
