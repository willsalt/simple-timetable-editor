using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class DocumentOptionsModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DocumentOptionsModelClass_IsPublic()
        {
            Type classType = typeof(DocumentOptionsModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_IsNotAbstract()
        {
            Type classType = typeof(DocumentOptionsModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(DocumentOptionsModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicClockTypeNamePropertyOfTypeString()
        {
            Type classType = typeof(DocumentOptionsModel);
            PropertyInfo property = classType.GetProperty("ClockTypeName");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicGraphEditStylePropertyOfTypeString()
        {
            Type classType = typeof(DocumentOptionsModel);
            PropertyInfo property = classType.GetProperty("GraphEditStyle");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicDisplayTrainLabelsOnGraphsPropertyOfTypeNullableBool()
        {
            Type classType = typeof(DocumentOptionsModel);
            PropertyInfo property = classType.GetProperty("DisplayTrainLabelsOnGraphs");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicDisplaySpeedLinesOnGraphsPropertyOfTypeNullableBool()
        {
            Type classType = typeof(DocumentOptionsModel);
            PropertyInfo property = classType.GetProperty("DisplaySpeedLinesOnGraphs");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicSpeedLineSpeedPropertyOfTypeNullableInt()
        {
            Type classType = typeof(DocumentOptionsModel);
            PropertyInfo property = classType.GetProperty("SpeedLineSpeed");
            Assert.AreEqual(typeof(int?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicDisplaySpeedLineSpacingMinutesPropertyOfTypeNullableInt()
        {
            Type classType = typeof(DocumentOptionsModel);
            PropertyInfo property = classType.GetProperty("SpeedLineSpacingMinutes");
            Assert.AreEqual(typeof(int?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DocumentOptionsModelClass_HasPublicSpeedLineAppearancePropertyOfTypeGraphTrainPropertiesModel()
        {
            Type classType = typeof(DocumentOptionsModel);
            PropertyInfo property = classType.GetProperty("SpeedLineAppearance");
            Assert.AreEqual(typeof(GraphTrainPropertiesModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
