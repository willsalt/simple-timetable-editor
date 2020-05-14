using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class DistanceModelExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DistanceModelExtensionsClass_ToDistanceMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            DistanceModel testObject = null;

            _ = testObject.ToDistance();

            Assert.Fail();
        }

        [TestMethod]
        public void DistanceModelExtensionsClass_ToDistanceMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            DistanceModel testObject = null;

            try
            {
                _ = testObject.ToDistance();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }

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

#pragma warning restore CA1707 // Identifiers should not contain underscores
        
        private static DistanceModel GetRandomDistanceModel()
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
