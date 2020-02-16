using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class BlockSectionModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void BlockSectionModelClass_IsPublic()
        {
            Type classType = typeof(BlockSectionModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClass_IsNotAbstract()
        {
            Type classType = typeof(BlockSectionModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(BlockSectionModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicIdPropertyOfTypeString()
        {
            Type classType = typeof(BlockSectionModel);
            PropertyInfo property = classType.GetProperty("Id");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicStartLocationIdPropertyOfTypeString()
        {
            Type classType = typeof(BlockSectionModel);
            PropertyInfo property = classType.GetProperty("StartLocationId");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicEndLocationIdPropertyOfTypeString()
        {
            Type classType = typeof(BlockSectionModel);
            PropertyInfo property = classType.GetProperty("EndLocationId");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicCapacityPropertyOfTypeInt()
        {
            Type classType = typeof(BlockSectionModel);
            PropertyInfo property = classType.GetProperty("Capacity");
            Assert.AreEqual(typeof(int), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
