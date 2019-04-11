using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Timetabler.XmlData.Tests.Unit
{
    [TestClass]
    public class TrainLocationTimeModelUnitTests
    {
        [TestMethod]
        public void TrainLocationTimeModelClassIsPublic()
        {
            Assert.IsTrue(typeof(TrainLocationTimeModel).IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TrainLocationTimeModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassHasPublicArrivalTimePropertyOfTypeTrainTimeModel()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("ArrivalTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TrainTimeModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassHasPublicDepartureTimePropertyOfTypeTrainTimeModel()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("DepartureTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TrainTimeModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassHasPublicPassPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("Pass");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassHasPublicLocationIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("LocationId");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassHasPublicPathPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("Path");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassHasPublicPlatformPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("Platform");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassHasPublicLinePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("Line");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }
    }
}
