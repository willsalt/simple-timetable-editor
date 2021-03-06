﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class LineCoordinatesUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LineCoordinatesClass_Constructor_SetsVertex1PropertyToValueOfFirstParameter()
        {
            VertexInformation testParam0 = new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble());
            VertexInformation testParam1 = new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble());

            LineCoordinates testOutput = new LineCoordinates(testParam0, testParam1);

            Assert.AreSame(testParam0, testOutput.Vertex1);
        }

        [TestMethod]
        public void LineCoordinatesClass_Constructor_SetsVertex2PropertyToValueOfSecondParameter()
        {
            VertexInformation testParam0 = new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble());
            VertexInformation testParam1 = new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble());

            LineCoordinates testOutput = new LineCoordinates(testParam0, testParam1);

            Assert.AreSame(testParam1, testOutput.Vertex2);
        }

        [TestMethod]
        public void LineCoordinatesClass_GetIndexOfLongestLineMethod_ReturnsMinusOne_IfParameterIsNull()
        {
            int testOutput = LineCoordinates.GetIndexOfLongestLine(null);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void LineCoordinatesClass_GetIndexOfLongestLineMethod_ReturnsMinusOne_IfParameterIsEmptyList()
        {
            int testOutput = LineCoordinates.GetIndexOfLongestLine(new List<LineCoordinates>());

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void LineCoordinatesClass_GetIndexOfLongestLineMethod_ReturnsMinusOne_IfEveryItemInParameterIsNull()
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
        public void LineCoordinatesClass_GetIndexOfLongestLineMethod_ReturnsZero_IfParameterContainsOneItem()
        {
            List<LineCoordinates> testInput = new List<LineCoordinates>
            {
                new LineCoordinates(new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble()),
                    new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble()))
            };

            int testOutput = LineCoordinates.GetIndexOfLongestLine(testInput);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void LineCoordinatesClass_GetIndexOfLongestLineMethod_ReturnsIndexOfNonNullItem_IfParameterOnlyContainsOneNonNullItem()
        {
            List<LineCoordinates> testInput = new List<LineCoordinates>();
            LineCoordinates testItem = 
                new LineCoordinates(new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble()),
                    new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble()));
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
        public void LineCoordinatesClass_GetIndexOfLongestLineMethod_ReturnsCorrectValue_IfThereAreMultipleNonNullItemsInList()
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
                VertexInformation startVertex = new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble() * 200, 
                    _rnd.NextDouble() * 200);
                double theta = _rnd.NextDouble() * Math.PI * 2;
                VertexInformation endVertex = new VertexInformation(new TrainDrawingInfo(), _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), startVertex.X + lengths[i] * Math.Cos(theta), 
                    startVertex.Y + lengths[i] * Math.Sin(theta));
                testInput.Add(new LineCoordinates(startVertex, endVertex));
            }

            int testOutput = LineCoordinates.GetIndexOfLongestLine(testInput);

            Assert.AreEqual(answer, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
