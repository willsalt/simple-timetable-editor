using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Timetabler.XmlData.Tests.Unit
{
    [TestClass]
    public class SignalboxModelUnitTests
    {
        [TestMethod]
        public void SignalboxModelClassIsPublic()
        {
            Assert.IsTrue(typeof(SignalboxModel).IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(SignalboxModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClassHasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxModelClassIdPropertyIsDecoratedWithXmAttributeAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxModelClassHasPublicCodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxModel).GetProperty("Code");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxModelClassCodePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxModel).GetProperty("Code").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxModelClassHasPublicEditorDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxModel).GetProperty("EditorDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxModelClassEditorDisplayNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxModel).GetProperty("EditorDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxModelClassHasPublicTimetableDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxModel).GetProperty("TimetableDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxModelClassTimetableDisplayNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxModel).GetProperty("TimetableDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
