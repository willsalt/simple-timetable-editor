using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Timetabler.XmlData.Tests.Unit
{
    [TestClass]
    public class GraphTrainPropertiesModelUnitTests
    {
        [TestMethod]
        public void GraphTrainPropertiesModelClassIsPublic()
        {
            Assert.IsTrue(typeof(GraphTrainPropertiesModel).IsPublic);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(GraphTrainPropertiesModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClassHasPublicColourCodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(GraphTrainPropertiesModel).GetProperty("ColourCode");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClassHasPublicWidthPropertyOfTypeFloat()
        {
            PropertyInfo pInfo = typeof(GraphTrainPropertiesModel).GetProperty("Width");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(float), pInfo.PropertyType);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClassHasPublicDashStyleNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(GraphTrainPropertiesModel).GetProperty("DashStyleName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }
    }
}
