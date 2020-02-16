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
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SignalboxHoursSetModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(SignalboxHoursSetModel).IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(SignalboxHoursSetModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_HasPublicCategoryPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursSetModel).GetProperty("Category");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_CategoryPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursSetModel).GetProperty("Category").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_HasPublicSignalboxesPropertyOfTypeListOfSignalboxHoursModel()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursSetModel).GetProperty("Signalboxes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<SignalboxHoursModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_SignalboxesPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursSetModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_SignalboxesPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursSetModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_SignalboxesPropertyXmlArrayItemAttributeElementNamePropertyEqualsSignalbox()
        {
            XmlArrayItemAttribute attr = typeof(SignalboxHoursSetModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Signalbox", attr.ElementName);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_Constructor_CreatesObjectThatHasSignalboxesPropertyThatIsNotNull()
        {
            SignalboxHoursSetModel testOutput = new SignalboxHoursSetModel();

            Assert.IsNotNull(testOutput.Signalboxes);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
