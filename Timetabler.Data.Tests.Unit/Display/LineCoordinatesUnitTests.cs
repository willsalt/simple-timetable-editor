using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Timetabler.CoreData;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class LineCoordinatesUnitTests
    {
        private static Random _rnd = new Random();

        [TestMethod]
        public void LineCoordinatesClassConstructorSetsVertex1PropertyToValueOfFirstParameter()
        {
            VertexInformation testParam0 = new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), _rnd.NextDouble());
            VertexInformation testParam1 = new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), _rnd.NextDouble());

            LineCoordinates testOutput = new LineCoordinates(testParam0, testParam1);

            Assert.AreSame(testParam0, testOutput.Vertex1);
        }

        [TestMethod]
        public void LineCoordinatesClassConstructorSetsVertex2PropertyToValueOfSecondParameter()
        {
            VertexInformation testParam0 = new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), _rnd.NextDouble());
            VertexInformation testParam1 = new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), _rnd.NextDouble());

            LineCoordinates testOutput = new LineCoordinates(testParam0, testParam1);

            Assert.AreSame(testParam1, testOutput.Vertex2);
        }

        [TestMethod]
        public void LineCoordinatesClassGetIndexOfLongestLineMethodReturnsMinusOneIfParameterIsNull()
        {
            int testOutput = LineCoordinates.GetIndexOfLongestLine(null);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void LineCoordinatesClassGetIndexOfLongestLineMethodReturnsMinusOneIfParameterIsEmptyList()
        {
            int testOutput = LineCoordinates.GetIndexOfLongestLine(new List<LineCoordinates>());

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void LineCoordinatesClassGetIndexOfLongestLineMethodReturnsMinusOneIfEveryItemInParameterIsNull()
        {
            List<LineCoordinates> testInput = new List<LineCoordinates>();
            int count = _rnd.Next(20) + 1;
            for (int i = 0; i < count; ++i)
            {
                testInput.Add(null);
            }

            int testOutput = LineCoordinates.GetIndexOfLongestLine(testInput);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void LineCoordinatesClassGetIndexOfLongestLineMethodReturnsZeroIfParameterContainsOneItem()
        {
            List<LineCoordinates> testInput = new List<LineCoordinates>
            {
                new LineCoordinates(new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), _rnd.NextDouble()),
                    new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), _rnd.NextDouble()))
            };

            int testOutput = LineCoordinates.GetIndexOfLongestLine(testInput);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void LineCoordinatesClassGetIndexOfLongestLineMethodReturnsIndexOfNonNullItemIfParameterOnlyContainsOneNonNullItem()
        {
            List<LineCoordinates> testInput = new List<LineCoordinates>();
            LineCoordinates testItem = new LineCoordinates(new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), 
                    _rnd.NextDouble()),
                new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), _rnd.NextDouble()));
            int count = _rnd.Next(20) + 1;
            int pos = _rnd.Next(count);
            for (int i = 0; i < count; ++i)
            {
                testInput.Add(i == pos ? testItem : null);
            }

            int testOutput = LineCoordinates.GetIndexOfLongestLine(testInput);

            Assert.AreEqual(pos, testOutput);
        }

        [TestMethod]
        public void LineCoordinatesClassGetIndexOfLongestLineMethodReturnsCorrectValueIfThereAreMultipleNonNullItemsInList()
        {
            int count = _rnd.Next(20) + 2;
            double[] lengths = new double[count];
            for (int i = 0; i < count; ++i)
            {
                lengths[i] = _rnd.NextDouble() * 120;
            }
            int answer = lengths.MaxIndex();
            List<LineCoordinates> testInput = new List<LineCoordinates>(count);
            for (int i = 0; i < count; ++i)
            {
                VertexInformation startVertex = new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble() * 200, 
                    _rnd.NextDouble() * 200);
                double theta = _rnd.NextDouble() * Math.PI * 2;
                VertexInformation endVertex = new VertexInformation(new Train(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), 
                    startVertex.X + lengths[i] * Math.Cos(theta), startVertex.Y + lengths[i] * Math.Sin(theta));
                testInput.Add(new LineCoordinates(startVertex, endVertex));
            }

            int testOutput = LineCoordinates.GetIndexOfLongestLine(testInput);

            Assert.AreEqual(answer, testOutput);
        }
    }
}
