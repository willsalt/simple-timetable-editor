using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.CoreData;
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
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreSame(testParam0, testOutput.Train);
        }

        [TestMethod]
        public void VertexInformationClassConstructorSetsTimePropertyToValueOfSecondParameter()
        {
            Train testParam0 = new Train();
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam1, testOutput.Time);
        }

        [TestMethod]
        public void VertexInformationClassConstructorSetsArrivalDeparturePropertyToValueOfThirdParameter()
        {
            Train testParam0 = new Train();
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam2, testOutput.ArrivalDeparture);
        }

        [TestMethod]
        public void VertexInformationClassConstructorSetsXPropertyToValueOfFourthParameter()
        {
            Train testParam0 = new Train();
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);
        }

        [TestMethod]
        public void VertexInformationClassConstructorSetsYPropertyToValueOfFifthParameter()
        {
            Train testParam0 = new Train();
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam4, testOutput.Y);
        }
    }
}
