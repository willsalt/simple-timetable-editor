using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class GraphTrainPropertiesModelUnitTests
    {
        [TestMethod]
        public void GraphTrainPropertiesModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(GraphTrainPropertiesModel).IsPublic);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(GraphTrainPropertiesModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_HasPublicColourCodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(GraphTrainPropertiesModel).GetProperty("ColourCode");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_HasPublicWidthPropertyOfTypeFloat()
        {
            PropertyInfo pInfo = typeof(GraphTrainPropertiesModel).GetProperty("Width");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(float), pInfo.PropertyType);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_HasPublicDashStyleNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(GraphTrainPropertiesModel).GetProperty("DashStyleName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GraphTrainPropertiesModelClass_ReadXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel();

            testObject.ReadXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_ReadXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel();

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
        public void GraphTrainPropertiesModelClass_WriteXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel();

            testObject.WriteXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_WriteXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel();

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
