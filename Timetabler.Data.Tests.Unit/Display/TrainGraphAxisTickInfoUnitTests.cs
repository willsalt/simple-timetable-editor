using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TrainGraphAxisTickInfoUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainGraphAxisTickInfoClass_Constructor_SetsLabelPropertyToValueOfFirstParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(50));
            double testParam1 = _rnd.NextDouble() * 50;

            TrainGraphAxisTickInfo testOutput = new TrainGraphAxisTickInfo(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Label);
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoClass_Constructor_SetsCoordinatePropertyToValueOfSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(50));
            double testParam1 = _rnd.NextDouble() * 50;

            TrainGraphAxisTickInfo testOutput = new TrainGraphAxisTickInfo(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Coordinate);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
