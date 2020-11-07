using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class NoteModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void NoteModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(NoteModel).IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(NoteModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClass_IdProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("Id").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClass_HasPublicSymbolPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("Symbol");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClass_SymbolProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("Symbol").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClass_HasPublicDefinitionPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("Definition");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClass_DefinitionProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("Definition").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClass_HasPublicAppliesToTrainsPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("AppliesToTrains");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClass_AppliesToTrainsProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("AppliesToTrains").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClass_HasPublicAppliesToTimingsPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("AppliesToTimings");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClass_AppliesToTimingsProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("AppliesToTimings").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClass_HasPublicDefinedOnPagesPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("DefinedOnPages");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClass_DefinedOnPagesProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("DefinedOnPages").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClass_HasPublicDefinedInGlossaryPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("DefinedInGlossary");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClass_DefinedInGlossaryProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("DefinedInGlossary").GetCustomAttributes<XmlElementAttribute>().First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
