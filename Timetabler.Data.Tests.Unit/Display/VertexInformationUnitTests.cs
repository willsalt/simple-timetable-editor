using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class VertexInformationUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void VertexInformationClass_Constructor_SetsTrainDrawingInfoPropertyToValueOfFirstParameter()
        {
            TrainDrawingInfo testParam0 = new TrainDrawingInfo { Train = new Train() };
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreSame(testParam0, testOutput.TrainDrawingInfo);
        }

        [TestMethod]
        public void VertexInformationClass_Constructor_SetsTrainPropertyToValueOfTrainPropertyOfFirstParameter()
        {
            TrainDrawingInfo testParam0 = new TrainDrawingInfo { Train = new Train() };
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreSame(testParam0.Train, testOutput.Train);
        }

        [TestMethod]
        public void VertexInformationClass_Constructor_SetsTimePropertyToValueOfSecondParameter()
        {
            TrainDrawingInfo testParam0 = new TrainDrawingInfo { Train = new Train() };
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam1, testOutput.Time);
        }

        [TestMethod]
        public void VertexInformationClass_Constructor_SetsArrivalDeparturePropertyToValueOfThirdParameter()
        {
            TrainDrawingInfo testParam0 = new TrainDrawingInfo { Train = new Train() };
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam2, testOutput.ArrivalDeparture);
        }

        [TestMethod]
        public void VertexInformationClass_Constructor_SetsXPropertyToValueOfFourthParameter()
        {
            TrainDrawingInfo testParam0 = new TrainDrawingInfo { Train = new Train() };
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam3, testOutput.X);
        }

        [TestMethod]
        public void VertexInformationClass_Constructor_SetsYPropertyToValueOfFifthParameter()
        {
            TrainDrawingInfo testParam0 = new TrainDrawingInfo { Train = new Train() };
            TimeOfDay testParam1 = new TimeOfDay(_rnd.Next(86400));
            ArrivalDepartureOptions testParam2 = (ArrivalDepartureOptions)(_rnd.Next(3) + 1);
            double testParam3 = _rnd.NextDouble();
            double testParam4 = _rnd.NextDouble();

            VertexInformation testOutput = new VertexInformation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam4, testOutput.Y);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
