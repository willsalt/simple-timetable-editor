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
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExportOptionsModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(ExportOptionsModel).IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(ExportOptionsModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicDisplayLocoDiagramRowPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("DisplayLocoDiagramRow");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClass_DisplayLocoDiagramRowProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("DisplayLocoDiagramRow").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicFontSetPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("FontSet");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClass_FontSetProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("FontSet").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicGraphsInOutputPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("GraphsInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClassGraphs_InOutputProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("GraphsInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicToWorkRowInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("ToWorkRowInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClass_ToWorkRowInOutputProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("ToWorkRowInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicLocoToWorkRowInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("LocoToWorkRowInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClass_LocoToWorkRowInOutputProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("LocoToWorkRowInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicBoxHoursInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("BoxHoursInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClass_BoxHoursInOutputProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("BoxHoursInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicCreditsInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("CreditsInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClass_CreditsInOutputProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("CreditsInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicGlossaryInOutputPropertyOfTypeNullableBool()
        {
            PropertyInfo pInfo = typeof(ExportOptionsModel).GetProperty("GlossaryInOutput");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool?), pInfo.PropertyType);
        }

        [TestMethod]
        public void ExportOptionsModelClass_GlossaryInOutputProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(ExportOptionsModel).GetProperty("GlossaryInOutput").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
