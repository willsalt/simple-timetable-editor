using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class ExportOptionsModelUnitTests
    {
        [TestMethod]
        public void ExportOptionsModelClassIsPublic()
        {
            Assert.IsTrue(typeof(ExportOptionsModel).IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(ExportOptionsModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicDisplayLocoDiagramRowPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("DisplayLocoDiagramRow");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassDisplayLocoDiagramRowPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("DisplayLocoDiagramRow").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicFontSetPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("FontSet");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassFontSetPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("FontSet").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicGraphsInOutputPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("GraphsInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassGraphsInOutputPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("GraphsInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicToWorkRowInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("ToWorkRowInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassToWorkRowInOutputPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("ToWorkRowInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicLocoToWorkRowInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("LocoToWorkRowInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassLocoToWorkRowInOutputPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("LocoToWorkRowInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicBoxHoursInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("BoxHoursInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassBoxHoursInOutputPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("BoxHoursInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicCreditsInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("CreditsInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassCreditsInOutputPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("CreditsInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicGlossaryInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("GlossaryInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassGlossaryInOutputPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("GlossaryInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
