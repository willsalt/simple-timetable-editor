using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Load;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Tests.Unit.Load
{
    [TestClass]
    public class DistanceModelExtensionsUnitTests
    {
        [TestMethod]
        public void DistanceModelExtensionsClassToDistanceMethodReturnsDistanceObjectWithCorrectMileageProperty()
        {
            DistanceModel testObject = GetRandomDistanceModel();

            Distance resultObject = testObject.ToDistance();

            Assert.AreEqual(testObject.Mileage, resultObject.Mileage);
        }

        [TestMethod]
        public void DistanceModelExtensionsClassToDistanceMethodReturnsDistanceObjectWithCorrectChainageProperty()
        {
            DistanceModel testObject = GetRandomDistanceModel();

            Distance resultObject = testObject.ToDistance();

            Assert.AreEqual(testObject.Chainage, resultObject.Chainage);
        }

        private DistanceModel GetRandomDistanceModel()
        {
            Random random = new Random();
            return new DistanceModel
            {
                Mileage = random.Next(),
                Chainage = random.NextDouble() * 80,
            };
        }
    }
}
