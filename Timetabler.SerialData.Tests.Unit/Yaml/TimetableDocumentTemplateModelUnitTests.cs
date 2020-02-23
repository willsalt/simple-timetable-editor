using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class TimetableDocumentTemplateModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_IsPublic()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_IsNotAbstract()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicVersionPropertyOfTypeNullableInt()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            PropertyInfo property = classType.GetProperty("Version");
            Assert.AreEqual(typeof(int?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicDefaultOptionsPropertyOfTypeDocumentOptionsModel()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            PropertyInfo property = classType.GetProperty("DefaultOptions");
            Assert.AreEqual(typeof(DocumentOptionsModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicDefaultExportOptionsPropertyOfTypeExportOptionsModel()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            PropertyInfo property = classType.GetProperty("DefaultExportOptions");
            Assert.AreEqual(typeof(ExportOptionsModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicReadableMapsPropertyDerivedFromTypeICollectionOfNetworkMapModel()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            PropertyInfo property = classType.GetProperty("Maps");
            Assert.IsTrue(typeof(ICollection<NetworkMapModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicReadableNoteDefinitionsPropertyDerivedFromTypeICollectionOfNoteModel()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            PropertyInfo property = classType.GetProperty("NoteDefinitions");
            Assert.IsTrue(typeof(ICollection<NoteModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicReadableTrainClassesPropertyDerivedFromTypeICollectionOfTrainClassModel()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            PropertyInfo property = classType.GetProperty("TrainClasses");
            Assert.IsTrue(typeof(ICollection<TrainClassModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicReadableSignalboxesPropertyDerivedFromTypeICollectionOfSignalboxModel()
        {
            Type classType = typeof(TimetableDocumentTemplateModel);
            PropertyInfo property = classType.GetProperty("Signalboxes");
            Assert.IsTrue(typeof(ICollection<SignalboxModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_SetsMapsPropertyToEmptyCollection()
        {
            TimetableDocumentTemplateModel testOutput = new TimetableDocumentTemplateModel();

            Assert.IsNotNull(testOutput.Maps);
            Assert.AreEqual(0, testOutput.Maps.Count);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_SetsNoteDefinitionsPropertyToEmptyCollection()
        {
            TimetableDocumentTemplateModel testOutput = new TimetableDocumentTemplateModel();

            Assert.IsNotNull(testOutput.NoteDefinitions);
            Assert.AreEqual(0, testOutput.NoteDefinitions.Count);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_SetsTrainClassesPropertyToEmptyCollection()
        {
            TimetableDocumentTemplateModel testOutput = new TimetableDocumentTemplateModel();

            Assert.IsNotNull(testOutput.TrainClasses);
            Assert.AreEqual(0, testOutput.TrainClasses.Count);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_SetsVersionPropertyTo3()
        {
            TimetableDocumentTemplateModel testOutput = new TimetableDocumentTemplateModel();

            Assert.AreEqual(3, testOutput.Version.Value);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
