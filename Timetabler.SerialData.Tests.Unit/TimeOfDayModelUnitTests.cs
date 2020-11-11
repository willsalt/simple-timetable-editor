using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Timetabler.SerialData.Tests.Unit
{
    [TestClass]
    public class TimeOfDayModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimeOfDayModelClass_IsPublic()
        {
            Type classType = typeof(TimeOfDayModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void TimeOfDayModelClass_IsNotAbstract()
        {
            Type classType = typeof(TimeOfDayModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void TimeOfDayModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(TimeOfDayModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void TimeOfDayModelClass_HasPublicTimePropertyOfTypeString()
        {
            Type classType = typeof(TimeOfDayModel);
            PropertyInfo property = classType.GetProperty("Time");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
