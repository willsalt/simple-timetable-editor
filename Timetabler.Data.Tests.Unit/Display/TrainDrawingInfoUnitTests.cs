using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TrainDrawingInfoUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        private VertexInformation GetVertexInformation(TrainDrawingInfo tdi)
        {
            return new VertexInformation(tdi, _rnd.NextTimeOfDay(), _rnd.NextArrivalDepartureOptions(), _rnd.NextDouble(), _rnd.NextDouble());
        }

        [TestMethod]
        public void TrainDrawingInfoClassLineVertexesPropertyGetMethodReturnsAllVertexesFromAllLines()
        {
            int lineCount = _rnd.Next(10) + 1;
            TrainDrawingInfo testObject = new TrainDrawingInfo();
            List<VertexInformation> vertexList = new List<VertexInformation>(lineCount * 2);
            for (int i = 0; i < lineCount; ++i)
            {
                LineCoordinates line = new LineCoordinates(GetVertexInformation(testObject), GetVertexInformation(testObject));
                vertexList.Add(line.Vertex1);
                vertexList.Add(line.Vertex2);
                testObject.Lines.Add(line);
            }

            List<VertexInformation> testOutput = testObject.LineVertexes.ToList();

            Assert.AreEqual(vertexList.Count, testOutput.Count);
            foreach (VertexInformation vi in testOutput)
            {
                Assert.IsTrue(vertexList.Contains(vi));
                vertexList.Remove(vi);
            }
        }

        [TestMethod]
        public void TrainDrawingInfoClassLineVertexesPropertyGetMethodOnlyReturnsDistinctVertexesWhereVertexObjectsAreSharedBetweenLines()
        {
            TrainDrawingInfo testObject = new TrainDrawingInfo();
            int vertexCount = _rnd.Next(10) + 1;
            int lineCount = _rnd.Next(10) + vertexCount;
            VertexInformation[] vertexSource = new VertexInformation[vertexCount];
            bool[] vertexesUsed = new bool[vertexCount];
            for (int i = 0; i < vertexCount; ++i)
            {
                vertexSource[i] = GetVertexInformation(testObject);
            }
            for (int i = 0; i < lineCount; ++i)
            {
                int firstIndex = _rnd.Next(vertexCount);
                int secondIndex = _rnd.Next(vertexCount);
                testObject.Lines.Add(new LineCoordinates(vertexSource[firstIndex], vertexSource[secondIndex]));
                vertexesUsed[firstIndex] = true;
                vertexesUsed[secondIndex] = true;
            }
            List<VertexInformation> vertexList = vertexSource.Where((v, i) => vertexesUsed[i]).ToList();

            List<VertexInformation> testOutput = testObject.LineVertexes.ToList();

            Assert.AreEqual(vertexList.Count, testOutput.Count);
            foreach (VertexInformation vi in testOutput)
            {
                Assert.IsTrue(vertexList.Contains(vi));
                vertexList.Remove(vi);
            }
        }
    }
}
