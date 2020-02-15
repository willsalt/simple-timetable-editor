using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class GraphTrainPropertiesModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void GraphTrainPropertiesModelClass_IsPublic()
        {
            Type classType = typeof(GraphTrainPropertiesModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_IsNotAbstract()
        {
            Type classType = typeof(GraphTrainPropertiesModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(GraphTrainPropertiesModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_HasPublicColourPropertyOfTypeString()
        {
            Type classType = typeof(GraphTrainPropertiesModel);
            PropertyInfo property = classType.GetProperty("Colour");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_HasPublicDashStyleNamePropertyOfTypeString()
        {
            Type classType = typeof(GraphTrainPropertiesModel);
            PropertyInfo property = classType.GetProperty("DashStyleName");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelClass_HasPublicWidthPropertyOfTypeNullableFloat()
        {
            Type classType = typeof(GraphTrainPropertiesModel);
            PropertyInfo property = classType.GetProperty("Width");
            Assert.AreEqual(typeof(float?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
