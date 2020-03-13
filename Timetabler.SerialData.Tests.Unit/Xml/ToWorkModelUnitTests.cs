using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class ToWorkModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ToWorkModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(ToWorkModel).IsPublic);
        }

        [TestMethod]
        public void ToWorkModelClass_ImplementsIXmlSerializable()
        {
            Assert.IsTrue(typeof(IXmlSerializable).IsAssignableFrom(typeof(ToWorkModel)));
        }

        [TestMethod]
        public void ToWorkModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(ToWorkModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void ToWorkModelClass_HasPublicAtTimePropertyOfTypeTimeOfDayModel()
        {
            PropertyInfo pInfo = typeof(ToWorkModel).GetProperty("AtTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TimeOfDayModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void ToWorkModelClass_HasPublicTextPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(ToWorkModel).GetProperty("Text");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToWorkModelClass_ReadXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            ToWorkModel testObject = new ToWorkModel();

            testObject.ReadXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkModelClass_ReadXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            ToWorkModel testObject = new ToWorkModel();

            try
            {
                testObject.ReadXml(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("reader", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToWorkModelClass_WriteXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            ToWorkModel testObject = new ToWorkModel();

            testObject.WriteXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkModelClass_WriteXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            ToWorkModel testObject = new ToWorkModel();

            try
            {
                testObject.WriteXml(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("writer", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
