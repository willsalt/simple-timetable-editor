using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class DocumentOptionsModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DocumentOptionsModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(DocumentOptionsModel).IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(DocumentOptionsModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicClockTypeNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(DocumentOptionsModel).GetProperty("ClockTypeName");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_ClockTypeNameProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(DocumentOptionsModel).GetProperty("ClockTypeName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicDisplayTrainLabelsOnGraphsPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(DocumentOptionsModel).GetProperty("DisplayTrainLabelsOnGraphs");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DoucmentOptionsModelClass_DisplayTrainLabelsOnGraphsProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(DocumentOptionsModel).GetProperty("DisplayTrainLabelsOnGraphs").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
