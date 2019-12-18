using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TrainLocationTimeModelUnitTests
    {
        [TestMethod]
        public void TrainLocationTimeModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(TrainLocationTimeModel).IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TrainLocationTimeModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicArrivalTimePropertyOfTypeTrainTimeModel()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("ArrivalTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TrainTimeModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicDepartureTimePropertyOfTypeTrainTimeModel()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("DepartureTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TrainTimeModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicPassPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("Pass");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicLocationIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("LocationId");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicPathPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("Path");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicPlatformPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("Platform");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicLinePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainLocationTimeModel).GetProperty("Line");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainLocationTimeModelClass_ReadXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainLocationTimeModel testObject = new TrainLocationTimeModel();

            testObject.ReadXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ReadXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainLocationTimeModel testObject = new TrainLocationTimeModel();

            try
            {
                testObject.ReadXml(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("reader", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainLocationTimeModelClass_WriteXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainLocationTimeModel testObject = new TrainLocationTimeModel();

            testObject.WriteXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_WriteXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainLocationTimeModel testObject = new TrainLocationTimeModel();

            try
            {
                testObject.WriteXml(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("writer", ex.ParamName);
            }
        }
    }
}
