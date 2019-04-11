using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Timetabler.XmlData.Tests.Unit
{
    [TestClass]
    public class DocumentOptionsModelUnitTests
    {
        [TestMethod]
        public void DocumentOptionsModelClassIsPublic()
        {
            Assert.IsTrue(typeof(DocumentOptionsModel).IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(DocumentOptionsModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClassHasPublicClockTypeNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(DocumentOptionsModel).GetProperty("ClockTypeName");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClassClockTypeNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(DocumentOptionsModel).GetProperty("ClockTypeName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void DocumentOptionsModelClassHasPublicDisplayTrainLabelsOnGraphsPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(DocumentOptionsModel).GetProperty("DisplayTrainLabelsOnGraphs");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DoucmentOptionsModelClassDisplayTrainLabelsOnGraphsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(DocumentOptionsModel).GetProperty("DisplayTrainLabelsOnGraphs").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
