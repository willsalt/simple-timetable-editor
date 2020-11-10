using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class NoteModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void NoteModelClass_IsPublic()
        {
            Type classType = typeof(NoteModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_IsNotAbstract()
        {
            Type classType = typeof(NoteModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(NoteModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicIdPropertyOfTypeString()
        {
            Type classType = typeof(NoteModel);
            PropertyInfo property = classType.GetProperty("Id");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicSymbolPropertyOfTypeString()
        {
            Type classType = typeof(NoteModel);
            PropertyInfo property = classType.GetProperty("Symbol");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicDefinitionPropertyOfTypeString()
        {
            Type classType = typeof(NoteModel);
            PropertyInfo property = classType.GetProperty("Definition");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicAppliesToTrainsPropertyOfTypeNullableBool()
        {
            Type classType = typeof(NoteModel);
            PropertyInfo property = classType.GetProperty("AppliesToTrains");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicAppliesToTimingsPropertyOfTypeNullableBool()
        {
            Type classType = typeof(NoteModel);
            PropertyInfo property = classType.GetProperty("AppliesToTimings");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicDefinedInGlossaryPropertyOfTypeNullableBool()
        {
            Type classType = typeof(NoteModel);
            PropertyInfo property = classType.GetProperty("DefinedInGlossary");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void NoteModelClass_HasPublicDefinedOnPagesPropertyOfTypeNullableBool()
        {
            Type classType = typeof(NoteModel);
            PropertyInfo property = classType.GetProperty("DefinedOnPages");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
