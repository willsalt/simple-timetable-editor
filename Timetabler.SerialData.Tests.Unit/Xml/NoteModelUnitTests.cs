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
        [TestMethod]
        public void NoteModelClassIsPublic()
        {
            Assert.IsTrue(typeof(NoteModel).IsPublic);
        }

        [TestMethod]
        public void NoteModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(NoteModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void NoteModelClassHasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClassIdPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("Id").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClassHasPublicSymbolPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("Symbol");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClassSymbolPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("Symbol").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClassHasPublicDefinitionPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("Definition");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClassDefinitionPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("Definition").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClassHasPublicAppliesToTrainsPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("AppliesToTrains");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClassAppliesToTrainsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("AppliesToTrains").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClassHasPublicAppliesToTimingsPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("AppliesToTimings");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClassAppliesToTimingsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("AppliesToTimings").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClassHasPublicDefinedOnPagesPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("DefinedOnPages");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClassDefinedOnPagesPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("DefinedOnPages").GetCustomAttributes<XmlElementAttribute>().First());
        }

        [TestMethod]
        public void NoteModelClassHasPublicDefinedInGlossaryPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(NoteModel).GetProperty("DefinedInGlossary");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void NoteModelClassDefinedInGlossaryPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(NoteModel).GetProperty("DefinedInGlossary").GetCustomAttributes<XmlElementAttribute>().First());
        }
    }
}
