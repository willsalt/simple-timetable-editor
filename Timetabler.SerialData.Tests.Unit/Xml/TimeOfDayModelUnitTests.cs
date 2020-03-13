using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TimeOfDayModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimeOfDayModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(TimeOfDayModel).IsPublic);
        }

        [TestMethod]
        public void TimeOfDayModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TimeOfDayModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TimeOfDayModelClass_HasPublicHours24PropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimeOfDayModel).GetProperty("Hours24");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimeOfDayModelClass_HasPublicMinutesPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimeOfDayModel).GetProperty("Minutes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimeOfDayModelClass_HasPublicSecondsPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimeOfDayModel).GetProperty("Seconds");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayModelClass_ReadXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TimeOfDayModel testObject = new TimeOfDayModel();

            testObject.ReadXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayModelClass_ReadXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TimeOfDayModel testObject = new TimeOfDayModel();

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
        public void TimeOfDayModelClass_WriteXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TimeOfDayModel testObject = new TimeOfDayModel();

            testObject.WriteXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayModelClass_WriteXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TimeOfDayModel testObject = new TimeOfDayModel();

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
