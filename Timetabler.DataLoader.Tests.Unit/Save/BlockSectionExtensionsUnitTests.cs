using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class BlockSectionExtensionsUnitTests
    {
        private static Random _rnd = new Random();

        private Location GetLocation()
        {
            const int idLength = 8;
            return new Location { Id = _rnd.NextHexString(idLength) };
        }

        private BlockSection GetBlockSection()
        {
            return new BlockSection
            {
                Capacity = _rnd.Next(4) + 1,
                MinimumTravelTime = _rnd.Next(30),
                StartLocation = GetLocation(),
                EndLocation = GetLocation(),
            };
        }

        [TestMethod]
        public void BlockSectionExtensionsClassToBlockSectionModelMethodReturnsNullIfParameterIsNull()
        {
            BlockSection testObject = null;

            BlockSectionModel testOutput = testObject.ToBlockSectionModel();

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void BlockSectionExtensionsClassToBlockSectionModelMethodReturnsNonNullObjectIfParameterIsNotNull()
        {
            BlockSection testObject = GetBlockSection();    

            BlockSectionModel testOutput = testObject.ToBlockSectionModel();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void BlockSectionExtensionsClassToBlockSectionModelMethodReturnsObjectWithCorrectStartLocationIdProperty()
        {
            BlockSection testObject = GetBlockSection();

            BlockSectionModel testOutput = testObject.ToBlockSectionModel();

            Assert.AreEqual(testObject.StartLocation.Id, testOutput.StartLocationId);
        }

        [TestMethod]
        public void BlockSectionExtensionsClassToBlockSectionModelMethodReturnsObjectWithNullStartLocationIdPropertyIfLocationPropertyOfParameterIsNull()
        {
            BlockSection testObject = GetBlockSection();
            testObject.StartLocation = null;

            BlockSectionModel testOutput = testObject.ToBlockSectionModel();

            Assert.IsNull(testOutput.StartLocationId);
        }

        [TestMethod]
        public void BlockSectionExtensionsClassToBlockSectionModelMethodReturnsObjectWithCorrectEndLocationIdProperty()
        {
            BlockSection testObject = GetBlockSection();

            BlockSectionModel testOutput = testObject.ToBlockSectionModel();

            Assert.AreEqual(testObject.EndLocation.Id, testOutput.EndLocationId);
        }

        [TestMethod]
        public void BlockSectionExtensionsClassToBlockSectionModelMethodReturnsObjectWithNullEndLocationIdPropertyIfLocationPropertyOfParameterIsNull()
        {
            BlockSection testObject = GetBlockSection();
            testObject.EndLocation = null;

            BlockSectionModel testOutput = testObject.ToBlockSectionModel();

            Assert.IsNull(testOutput.EndLocationId);
        }

        [TestMethod]
        public void BlockSectionExtensionsClassToBlockSectionModelMethodReturnsObjectWithCorrectCapacityProperty()
        {
            BlockSection testObject = GetBlockSection();

            BlockSectionModel testOutput = testObject.ToBlockSectionModel();

            Assert.AreEqual(testObject.Capacity, testOutput.Capacity);
        }

        [TestMethod]
        public void BlockSectionExtensionsClassToBlockSectionModelMethodReturnsObjectWithCorrectMinimumSectionTimeProperty()
        {
            BlockSection testObject = GetBlockSection();

            BlockSectionModel testOutput = testObject.ToBlockSectionModel();

            Assert.AreEqual(testObject.MinimumTravelTime, testOutput.MinimumSectionTime);
        }
    }
}
