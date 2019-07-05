using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Providers;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class LocationBoxDimensionsUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        private LocationBoxDimensions GetLocationBoxDimensions(int? locationMinCount = null)
        {
            LocationBoxDimensions dimensions = new LocationBoxDimensions();
            int locationOffsetCount = _rnd.Next(50) + locationMinCount ?? 0;
            for (int i = 0; i < locationOffsetCount; ++i)
            {
                dimensions.LocationOffsets.Add(i.ToString(), new TextVerticalLocation
                {
                    Baseline = _rnd.NextDouble() * 1000,
                    Bottom = _rnd.NextDouble() * 1000,
                    Top = _rnd.NextDouble() * 1000,
                });
            }
            return dimensions;
        }

        [TestMethod]
        public void LocationBoxDimensionsClassLocationOffsetListPropertyContainsSameNumberOfItemsAsLocationOffsetsProperty()
        {
            LocationBoxDimensions testObject = GetLocationBoxDimensions();

            List<TextVerticalLocation> testOutput = testObject.LocationOffsetList;

            Assert.AreEqual(testObject.LocationOffsets.Count, testOutput.Count);
        }
        
        [TestMethod]
        public void LocationBoxDimensionsClassLocationOffsetListPropertyContainsSameObjectsAsLocationOffsetsPropertyValues()
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
        public void LocationBoxDimensionsClassLocationOffsetListPropertyContainsObjectsOrderedByTopProperty()
        {
            LocationBoxDimensions testObject = GetLocationBoxDimensions(2);

            List<TextVerticalLocation> testOutput = testObject.LocationOffsetList;

            for (int i = 1; i < testOutput.Count; ++i)
            {
                Assert.IsTrue(testOutput[i].Top >= testOutput[i - 1].Top);
            }
        }
    }
}
