using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TimetableDocumentTemplateModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(TimetableDocumentTemplateModel).IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TimetableDocumentTemplateModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_IsDecoratedWithXmlRootAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_XmlRootAttributeElementNamePropertyEqualsTimetableDocumentTemplate()
        {
            XmlRootAttribute attr = typeof(TimetableDocumentTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual("TimetableDocumentTemplate", attr.ElementName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_XmlRootAttributeNamespacePropertyEqualsNamespacesV3()
        {
            XmlRootAttribute attr = typeof(TimetableDocumentTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual(Namespaces.V3, attr.Namespace);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicVersionPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("Version");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_VersionPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_VersionPropertyXmlAttributeAttributeAttributeNamePropertyEqualsVersion()
        {
            XmlAttributeAttribute attr = typeof(TimetableDocumentTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First();
            Assert.AreEqual("version", attr.AttributeName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicMapsPropertyOfTypeListOfNetworkMapModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("Maps");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NetworkMapModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_MapsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_MapsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_MapsPropertyXmlArrayItemAttributeElementNamePropertyEqualsMap()
        {
            XmlArrayItemAttribute attr = typeof(TimetableDocumentTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Map", attr.ElementName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicDefaultOptionsPropertyOfTypeDocumentOptionsModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("DefaultOptions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(DocumentOptionsModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_DefaultOptionsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("DefaultOptions").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicDefaultExportOptionsPropertyOfTypeExportOptionsModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("DefaultExportOptions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ExportOptionsModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_DefaultExportOptionsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("DefaultExportOptions").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicNoteDefinitionsPropertyOfTypeListOfNoteModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("NoteDefinitions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NoteModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_NoteDefinitionsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_NoteDefinitionsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_NoteDefinitionsPropertyXmlArrayItemAttributeElementNamePropertyEqualsNote()
        {
            XmlArrayItemAttribute attr = typeof(TimetableDocumentTemplateModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Note", attr.ElementName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_HasPublicTrainClassesPropertyOfTypeListOfTrainClassModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("TrainClasses");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainClassModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_TrainClassesPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("TrainClasses").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_TrainClassesPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("TrainClasses").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_TrainClassesPropertyXmlArrayItemAttributeElementNamePropertyEqualsTrainClass()
        {
            XmlArrayItemAttribute attr = typeof(TimetableDocumentTemplateModel).GetProperty("TrainClasses").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("TrainClass", attr.ElementName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_SetsVersionPropertyTo3()
        {
            TimetableDocumentTemplateModel testObject = new TimetableDocumentTemplateModel();

            Assert.AreEqual(3, testObject.Version);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_CreatesObjectWithMapsPropertyThatIsNotNull()
        {
            TimetableDocumentTemplateModel testOutput = new TimetableDocumentTemplateModel();

            Assert.IsNotNull(testOutput.Maps);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_CreatesObjectWithNoteDefinitionsPropertyThatIsNotNull()
        {
            TimetableDocumentTemplateModel testOutput = new TimetableDocumentTemplateModel();

            Assert.IsNotNull(testOutput.NoteDefinitions);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_CreatesObjectWithTraiinClassesPropertyThatIsNotNull()
        {
            TimetableDocumentTemplateModel testOutput = new TimetableDocumentTemplateModel();

            Assert.IsNotNull(testOutput.TrainClasses);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClass_Constructor_CreatesObjectWithSignalboxesPropertyThatIsNotNull()
        {
            TimetableDocumentTemplateModel testOutput = new TimetableDocumentTemplateModel();

            Assert.IsNotNull(testOutput.Signalboxes);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
