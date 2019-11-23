using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class SignalboxHoursSetModelUnitTests
    {
        [TestMethod]
        public void SignalboxHoursSetModelClassIsPublic()
        {
            Assert.IsTrue(typeof(SignalboxHoursSetModel).IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(SignalboxHoursSetModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClassHasPublicCategoryPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursSetModel).GetProperty("Category");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClassCategoryPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursSetModel).GetProperty("Category").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursSetModelClassHasPublicSignalboxesPropertyOfTypeListOfSignalboxHoursModel()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursSetModel).GetProperty("Signalboxes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<SignalboxHoursModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClassSignalboxesPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursSetModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursSetModelClassSignalboxesPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursSetModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursSetModelClassSignalboxesPropertyXmlArrayItemAttributeElementNamePropertyEqualsSignalbox()
        {
            XmlArrayItemAttribute attr = typeof(SignalboxHoursSetModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Signalbox", attr.ElementName);
        }
    }
}
