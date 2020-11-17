using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;
using Timetabler.Data.Extensions;

namespace Timetabler.Data.Tests.Unit.Extensions
{
    [TestClass]
    public class IEnumerableExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void IEnumerableExtensionsClass_LaterThanMethod_ReturnsCorrectNumberOfItems()
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
            // If our randomly-selected cut item has the same time value as another in the list, then its index does not actually give us the correct number of items
            // that will be in the output.
            cutIdx = sortedData.FindIndex(vi => vi.Time == cut.Time);

            List<VertexInformation> testOutput = rawData.LaterThan(cut).ToList();

            Assert.AreEqual(rawData.Count - cutIdx, testOutput.Count);
        }

        [TestMethod]
        public void IEnumerableExtensionsClass_LaterThanMethod_ReturnsCorrectItems()
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
            foreach (VertexInformation unfiltered in rawData)
            {
                Assert.IsTrue(unfiltered.Time < cut.Time);
            }
        }

        [TestMethod]
        public void IEnumerableExtensionsClass_EarlierThanMethod_ReturnsCorrectNumberOfItems()
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
            // If our randomly-selected cut item has the same time value as another in the list, then its index does not actually give us the correct number of items
            // that will be in the output.
            cutIdx = sortedData.FindLastIndex(vi => vi.Time == cut.Time);

            List<VertexInformation> testOutput = rawData.EarlierThan(cut).ToList();

            Assert.AreEqual(cutIdx + 1, testOutput.Count);
        }

        [TestMethod]
        public void IEnumerableExtensionsClass_EarlierThanMethod_ReturnsCorrectItems()
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
            foreach (VertexInformation unfiltered in rawData)
            {
                Assert.IsTrue(unfiltered.Time > cut.Time);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
