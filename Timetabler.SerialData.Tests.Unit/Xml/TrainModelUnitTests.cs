using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TrainModelUnitTests
    {
        [TestMethod]
        public void TrainModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(TrainModel).IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TrainModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicHeadcodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("Headcode");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicLocoDiagramPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("LocoDiagram");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicTrainClassIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("TrainClassId");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicGraphPropertiesPropertyOfTypeGraphTrainPropertiesModel()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("GraphProperties");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(GraphTrainPropertiesModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicTrainTimesPropertyOfTypeListOfTrainLocationTimeModel()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("TrainTimes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainLocationTimeModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicFootnoteIdsPropertyOfTypeListOfString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("FootnoteIds");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<string>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicIncludeSeparatorAbovePropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("IncludeSeparatorAbove");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicIncludeSeparatorBelowPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("IncludeSeparatorBelow");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicInlineNotePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("InlineNote");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicToWorkPropertyOfTypeToWorkModel()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("ToWork");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ToWorkModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicLocoToWorkPropertyOfTypeToWorkModel()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("LocoToWork");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ToWorkModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClass_Constructor_CreatesObjectWithTrainTimesPropertyThatIsNotNull()
        {
            TrainModel testOutput = new TrainModel();

            Assert.IsNotNull(testOutput.TrainTimes);
        }

        [TestMethod]
        public void TrainModelClass_Constructor_CreatesObjectWithFootnoteIdsPropertyThatIsNotNull()
        {
            TrainModel testOutput = new TrainModel();

            Assert.IsNotNull(testOutput.FootnoteIds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainModelClass_ReadXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainModel testObject = new TrainModel();

            testObject.ReadXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainModelClass_ReadXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainModel testObject = new TrainModel();

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
        public void TrainModelClass_WriteXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainModel testObject = new TrainModel();

            testObject.WriteXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainModelClass_WriteXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainModel testObject = new TrainModel();

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
