using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Comparers;
using Timetabler.Data.Extensions;

namespace Timetabler.Data.Tests.Unit.Extensions
{
    [TestClass]
    public class IEnumerableExtensionsUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void IEnumerableExtensionsClassLaterThanMethodReturnsCorrectNumberOfItems()
        {
            int listLen = _rnd.Next(100) + 2;
            List<VertexInformation> rawData = new List<VertexInformation>(listLen);
            List<VertexInformation> sortedData = new List<VertexInformation>(listLen);
            for (int i = 0; i < listLen; ++i)
            {
                VertexInformation vi = new VertexInformation(new TrainDrawingInfo(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), 
                    _rnd.NextDouble());
                rawData.Add(vi);
                sortedData.Add(vi);
            }
            sortedData.Sort(new VertexInformationTimeBasedComparer());
            int cutIdx = _rnd.Next(rawData.Count);
            VertexInformation cut = sortedData[cutIdx];

            List<VertexInformation> testOutput = rawData.LaterThan(cut).ToList();

            Assert.AreEqual(rawData.Count - cutIdx, testOutput.Count);
        }

        [TestMethod]
        public void IEnumerableExtensionsClassLaterThanMethodReturnsCorrectItems()
        {
            int listLen = _rnd.Next(100) + 2;
            List<VertexInformation> rawData = new List<VertexInformation>(listLen);
            List<VertexInformation> sortedData = new List<VertexInformation>(listLen);
            for (int i = 0; i < listLen; ++i)
            {
                VertexInformation vi = new VertexInformation(new TrainDrawingInfo(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), 
                    _rnd.NextDouble());
                rawData.Add(vi);
                sortedData.Add(vi);
            }
            sortedData.Sort(new VertexInformationTimeBasedComparer());
            int cutIdx = _rnd.Next(rawData.Count);
            VertexInformation cut = sortedData[cutIdx];

            List<VertexInformation> testOutput = rawData.LaterThan(cut).ToList();

            foreach (VertexInformation filtered in testOutput)
            {
                Assert.IsTrue(filtered.Time >= cut.Time);
                Assert.IsTrue(rawData.Contains(filtered));
                rawData.Remove(filtered);
            }
        }

        [TestMethod]
        public void IEnumerableExtensionsClassEarlierThanMethodReturnsCorrectNumberOfItems()
        {
            int listLen = _rnd.Next(100) + 2;
            List<VertexInformation> rawData = new List<VertexInformation>(listLen);
            List<VertexInformation> sortedData = new List<VertexInformation>(listLen);
            for (int i = 0; i < listLen; ++i)
            {
                VertexInformation vi = new VertexInformation(new TrainDrawingInfo(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), 
                    _rnd.NextDouble());
                rawData.Add(vi);
                sortedData.Add(vi);
            }
            sortedData.Sort(new VertexInformationTimeBasedComparer());
            int cutIdx = _rnd.Next(rawData.Count);
            VertexInformation cut = sortedData[cutIdx];

            List<VertexInformation> testOutput = rawData.EarlierThan(cut).ToList();

            Assert.AreEqual(cutIdx + 1, testOutput.Count);
        }

        [TestMethod]
        public void IEnumerableExtensionsClassEarlierThanMethodReturnsCorrectItems()
        {
            int listLen = _rnd.Next(100) + 2;
            List<VertexInformation> rawData = new List<VertexInformation>(listLen);
            List<VertexInformation> sortedData = new List<VertexInformation>(listLen);
            for (int i = 0; i < listLen; ++i)
            {
                VertexInformation vi = new VertexInformation(new TrainDrawingInfo(), new TimeOfDay(_rnd.Next(86400)), (ArrivalDepartureOptions)(_rnd.Next(3) + 1), _rnd.NextDouble(), 
                    _rnd.NextDouble());
                rawData.Add(vi);
                sortedData.Add(vi);
            }
            sortedData.Sort(new VertexInformationTimeBasedComparer());
            int cutIdx = _rnd.Next(rawData.Count);
            VertexInformation cut = sortedData[cutIdx];

            List<VertexInformation> testOutput = rawData.EarlierThan(cut).ToList();

            foreach (VertexInformation filtered in testOutput)
            {
                Assert.IsTrue(filtered.Time <= cut.Time);
                Assert.IsTrue(rawData.Contains(filtered));
                rawData.Remove(filtered);
            }
        }
    }
}
