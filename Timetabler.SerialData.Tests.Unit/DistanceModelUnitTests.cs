using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Timetabler.SerialData.Tests.Unit
{
    [TestClass]
    public class DistanceModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DistanceModelClass_IsPublic()
        {
            Type classType = typeof(DistanceModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void DistanceModelClass_IsNotAbstract()
        {
            Type classType = typeof(DistanceModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void DistanceModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(DistanceModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
        }

        [TestMethod]
        public void DistanceModelClass_HasPublicMilesPropertyOfTypeInt()
        {
            Type classType = typeof(DistanceModel);
            PropertyInfo property = classType.GetProperty("Miles");
            Assert.AreEqual(typeof(int), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DistanceModelClass_HasPublicChainsPropertyOfTypeDouble()
        {
            Type classType = typeof(DistanceModel);
            PropertyInfo property = classType.GetProperty("Chains");
            Assert.AreEqual(typeof(double), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
