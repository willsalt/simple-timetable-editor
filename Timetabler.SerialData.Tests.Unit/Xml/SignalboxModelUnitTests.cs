using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class SignalboxModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SignalboxModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(SignalboxModel).IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(SignalboxModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxModelClass_IdProperty_IsDecoratedWithXmAttributeAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicCodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxModel).GetProperty("Code");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxModelClass_CodeProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxModel).GetProperty("Code").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicEditorDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxModel).GetProperty("EditorDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxModelClass_EditorDisplayNameProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxModel).GetProperty("EditorDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicTimetableDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxModel).GetProperty("TimetableDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxModelClass_TimetableDisplayNameProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxModel).GetProperty("TimetableDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
