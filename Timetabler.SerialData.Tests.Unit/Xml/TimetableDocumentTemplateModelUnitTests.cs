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
        [TestMethod]
        public void TimetableDocumentTemplateModelClassIsPublic()
        {
            Assert.IsTrue(typeof(TimetableDocumentTemplateModel).IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TimetableDocumentTemplateModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassIsDecoratedWithXmlRootAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassXmlRootAttributeElementNamePropertyEqualsTimetableDocumentTemplate()
        {
            XmlRootAttribute attr = typeof(TimetableDocumentTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual("TimetableDocumentTemplate", attr.ElementName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassXmlRootAttributeNamespacePropertyEqualsNamespacesV3()
        {
            XmlRootAttribute attr = typeof(TimetableDocumentTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual(Namespaces.V3, attr.Namespace);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassHasPublicVersionPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("Version");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassVersionPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassVersionPropertyXmlAttributeAttributeAttributeNamePropertyEqualsVersion()
        {
            XmlAttributeAttribute attr = typeof(TimetableDocumentTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First();
            Assert.AreEqual("version", attr.AttributeName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassHasPublicMapsPropertyOfTypeListOfNetworkMapModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("Maps");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NetworkMapModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassMapsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassMapsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassMapsPropertyXmlArrayItemAttributeElementNamePropertyEqualsMap()
        {
            XmlArrayItemAttribute attr = typeof(TimetableDocumentTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Map", attr.ElementName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassHasPublicDefaultOptionsPropertyOfTypeDocumentOptionsModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("DefaultOptions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(DocumentOptionsModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassDefaultOptionsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("DefaultOptions").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassHasPublicDefaultExportOptionsPropertyOfTypeExportOptionsModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("DefaultExportOptions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ExportOptionsModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassDefaultExportOptionsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("DefaultExportOptions").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassHasPublicNoteDefinitionsPropertyOfTypeListOfNoteModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("NoteDefinitions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NoteModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassNoteDefinitionsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassNoteDefinitionsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassNoteDefinitionsPropertyXmlArrayItemAttributeElementNamePropertyEqualsNote()
        {
            XmlArrayItemAttribute attr = typeof(TimetableDocumentTemplateModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Note", attr.ElementName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassHasPublicTrainClassesPropertyOfTypeListOfTrainClassModel()
        {
            PropertyInfo pInfo = typeof(TimetableDocumentTemplateModel).GetProperty("TrainClasses");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainClassModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassTrainClassesPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("TrainClasses").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassTrainClassesPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableDocumentTemplateModel).GetProperty("TrainClasses").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassTrainClassesPropertyXmlArrayItemAttributeElementNamePropertyEqualsTrainClass()
        {
            XmlArrayItemAttribute attr = typeof(TimetableDocumentTemplateModel).GetProperty("TrainClasses").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("TrainClass", attr.ElementName);
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelClassDefaultConstructorSetsVersionPropertyTo3()
        {
            TimetableDocumentTemplateModel testObject = new TimetableDocumentTemplateModel();

            Assert.AreEqual(3, testObject.Version);
        }
    }
}
