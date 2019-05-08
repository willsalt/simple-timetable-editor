using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class VertexInformationUnitTests
    {
        private static Random _rnd = new Random();

        [TestMethod]
        public void VertexInformationClassConstructorSetsTrainPropertyToValueOfFirstParameter()
        {
            Train testParam0 = new Train();
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            double testParam2 = _rnd.NextDouble();
            double testParam3 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3);

            Assert.AreSame(testParam0, testOutput.Train);
        }

        [TestMethod]
        public void VertexInformationClassConstructorSetsTimePropertyToValueOfSecondParameter()
        {
            Train testParam0 = new Train();
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            double testParam2 = _rnd.NextDouble();
            double testParam3 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam1, testOutput.Time);
        }

        [TestMethod]
        public void VertexInformationClassConstructorSetsXPropertyToValueOfThirdParameter()
        {
            Train testParam0 = new Train();
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            double testParam2 = _rnd.NextDouble();
            double testParam3 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.X);
        }

        [TestMethod]
        public void VertexInformationClassConstructorSetsYPropertyToValueOfFourthParameter()
        {
            Train testParam0 = new Train();
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            double testParam2 = _rnd.NextDouble();
            double testParam3 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam3, testOutput.Y);
        }
    }
}
