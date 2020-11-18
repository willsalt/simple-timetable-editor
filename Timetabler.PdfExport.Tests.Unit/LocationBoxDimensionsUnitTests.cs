using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using Tests.Utility.Providers;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class LocationBoxDimensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static TextVerticalLocation GetTVL() => new TextVerticalLocation(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000,
            _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);

        private static LocationBoxDimensions GetLocationBoxDimensions(int? locationMinCount = null)
        {
            LocationBoxDimensions dimensions = new LocationBoxDimensions
            {
                MajorDistanceColumnWidth = _rnd.NextDouble() * 20,
                MinorDistanceColumnWidth = _rnd.NextDouble() * 20,
            };
            int locationOffsetCount = _rnd.Next(50) + locationMinCount ?? 0;
            for (int i = 0; i < locationOffsetCount; ++i)
            {
                dimensions.LocationOffsets.Add(i.ToString(CultureInfo.CurrentCulture), GetTVL());
            }
            return dimensions;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LocationBoxDimensionsClass_LeftOffsetProperty_EqualsSumOfMajorDistanceColumnWidthAndMinorDistanceColumnWidthProperties()
        {
            LocationBoxDimensions testObject = GetLocationBoxDimensions();
            double expectedOutput = testObject.MajorDistanceColumnWidth + testObject.MinorDistanceColumnWidth;

            double testOutput = testObject.LeftOffset;

            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void LocationBoxDimensionsClass_LocationOffsetListProperty_ContainsSameNumberOfItemsAsLocationOffsetsProperty()
        {
            LocationBoxDimensions testObject = GetLocationBoxDimensions();

            List<TextVerticalLocation> testOutput = testObject.LocationOffsetList;

            Assert.AreEqual(testObject.LocationOffsets.Count, testOutput.Count);
        }
        
        [TestMethod]
        public void LocationBoxDimensionsClass_LocationOffsetListProperty_ContainsSameObjectsAsLocationOffsetsPropertyValues()
        {
            LocationBoxDimensions testObject = GetLocationBoxDimensions();

            List<TextVerticalLocation> testOutput = testObject.LocationOffsetList;

            foreach (var item in testObject.LocationOffsets.Values)
            {
                Assert.IsTrue(testOutput.Contains(item));
                testOutput.Remove(item);
            }
            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void LocationBoxDimensionsClass_LocationOffsetListProperty_ContainsObjectsOrderedByTopProperty()
        {
            LocationBoxDimensions testObject = GetLocationBoxDimensions(2);

            List<TextVerticalLocation> testOutput = testObject.LocationOffsetList;

            for (int i = 1; i < testOutput.Count; ++i)
            {
                Assert.IsTrue(testOutput[i].Top >= testOutput[i - 1].Top);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
