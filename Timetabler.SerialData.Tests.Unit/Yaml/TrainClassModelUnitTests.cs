using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class TrainClassModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainClassModelClass_IsPublic()
        {
            Type classType = typeof(TrainClassModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void TrainClassModelClass_IsNotAbstract()
        {
            Type classType = typeof(TrainClassModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void TrainClassModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(TrainClassModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void TrainClassModelClass_HasPublicIdPropertyOfTypeString()
        {
            Type classType = typeof(TrainClassModel);
            PropertyInfo property = classType.GetProperty("Id");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainClassModelClass_HasPublicDescriptionPropertyOfTypeString()
        {
            Type classType = typeof(TrainClassModel);
            PropertyInfo property = classType.GetProperty("Description");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainClassModelClass_HasPublicTableCodePropertyOfTypeString()
        {
            Type classType = typeof(TrainClassModel);
            PropertyInfo property = classType.GetProperty("TableCode");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
