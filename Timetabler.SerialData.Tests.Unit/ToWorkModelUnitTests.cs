using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class ToWorkModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ToWorkModelClass_IsPublic()
        {
            Type classType = typeof(ToWorkModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void ToWorkModelClass_IsNotAbstract()
        {
            Type classType = typeof(ToWorkModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void ToWorkModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(ToWorkModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void ToWorkModelClass_HasPublicAtPropertyOfTypeTimeOfDayModel()
        {
            Type classType = typeof(ToWorkModel);
            PropertyInfo property = classType.GetProperty("At");
            Assert.AreEqual(typeof(TimeOfDayModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ToWorkModelClass_HasPublicTextPropertyOfTypeString()
        {
            Type classType = typeof(ToWorkModel);
            PropertyInfo property = classType.GetProperty("Text");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
