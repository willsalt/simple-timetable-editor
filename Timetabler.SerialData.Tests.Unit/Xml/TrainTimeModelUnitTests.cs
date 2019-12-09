using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TrainTimeModelUnitTests
    {
        [TestMethod]
        public void TrainTimeModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(TrainTimeModel).IsPublic);
        }

        [TestMethod]
        public void TrainTimeModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TrainTimeModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainTimeModelClass_HasPublicTimePropertyOfTypeTimeOfDayModel()
        {
            PropertyInfo pInfo = typeof(TrainTimeModel).GetProperty("Time");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TimeOfDayModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainTimeModelClass_HasPublicFootnoteIdsPropertyOfTypeListOfString()
        {
            PropertyInfo pInfo = typeof(TrainTimeModel).GetProperty("FootnoteIds");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<string>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainTimeModelClass_Constructor_CreatesObjectWithFootnoteIdsPropertyThatIsNotNull()
        {
            TrainTimeModel testOutput = new TrainTimeModel();

            Assert.IsNotNull(testOutput.FootnoteIds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainTimeModelClass_ReadXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainTimeModel testObject = new TrainTimeModel();

            testObject.ReadXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeModelClass_ReadXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainTimeModel testObject = new TrainTimeModel();

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
        public void TrainTimeModelClass_WriteXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainTimeModel testObject = new TrainTimeModel();

            testObject.WriteXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeModelClass_WriteXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainTimeModel testObject = new TrainTimeModel();

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
