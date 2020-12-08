using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.CoreData;

namespace Timetabler.SerialData.Tests.Unit
{
    [TestClass]
    public class ExportOptionsModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExportOptionsModelClass_IsPublic()
        {
            Type classType = typeof(ExportOptionsModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_IsNotAbstract()
        {
            Type classType = typeof(ExportOptionsModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(ExportOptionsModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicFontSetPropertyOfTypeString()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("FontSet");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsFontSetPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.FontSet);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicGraphsInOutputPropertyOfTypeNullableBool()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("GraphsInOutput");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsGraphsInOutputPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.GraphsInOutput);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicSetToWorkRowInOutputPropertyOfTypeNullableBool()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("SetToWorkRowInOutput");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsSetToWorkRowInOutputPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.SetToWorkRowInOutput);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicLocoToWorkRowInOutputPropertyOfTypeNullableBool()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("LocoToWorkRowInOutput");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsLocoToWorkRowInOutputPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.LocoToWorkRowInOutput);
        }


        [TestMethod]
        public void ExportOptionsModelClass_HasPublicDisplayLocoDiagramRowPropertyOfTypeNullableBool()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("DisplayLocoDiagramRow");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsDisplayLocoDiagramRowPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.DisplayLocoDiagramRow);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicBoxHoursInOutputPropertyOfTypeNullableBool()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("BoxHoursInOutput");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsBoxHoursInOutputPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.BoxHoursInOutput);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicCreditsInOutputPropertyOfTypeNullableBool()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("CreditsInOutput");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsCreditsInOutputPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.CreditsInOutput);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicGlossaryInOutputPropertyOfTypeNullableBool()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("GlossaryInOutput");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsGlossaryInOutputPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.GlossaryInOutput);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicLineWidthPropertyOfTypeNullableDouble()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("LineWidth");
            Assert.AreEqual(typeof(double?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsLineWidthPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.LineWidth);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicGraphAxisLineWidthPropertyOfTypeNullableDouble()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("GraphAxisLineWidth");
            Assert.AreEqual(typeof(double?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsGraphAxisLineWidthPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.GraphAxisLineWidth);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicFillerDashLineWidthPropertyOfTypeNullableDouble()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("FillerDashLineWidth");
            Assert.AreEqual(typeof(double?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsFillerDashLineWidthPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.FillerDashLineWidth);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicUpSectionLabelPropertyOfTypeString()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("UpSectionLabel");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsUpSectionLabelPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.UpSectionLabel);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicDownSectionLabelPropertyOfTypeString()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("DownSectionLabel");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsDownSectionLabelPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.DownSectionLabel);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicMorningLabelPropertyOfTypeString()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("MorningLabel");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsMorningLabelPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.MorningLabel);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicMiddayLabelPropertyOfTypeString()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("MiddayLabel");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsMiddayLabelPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.MiddayLabel);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicAfternoonLabelPropertyOfTypeString()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("AfternoonLabel");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsAfternoonLabelPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.AfternoonLabel);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicDistancesInOutputPropertyOfTypeNullableSectionSelection()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("DistancesInOutput");
            Assert.AreEqual(typeof(SectionSelection?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsDistancesInOutputPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.DistancesInOutput);
        }

        [TestMethod]
        public void ExportOptionsModelClass_HasPublicFirstDirectionExportedPropertyOfTypeNullableDirection()
        {
            Type classType = typeof(ExportOptionsModel);
            PropertyInfo property = classType.GetProperty("FirstDirectionExported");
            Assert.AreEqual(typeof(Direction?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClass_Constructor_SetsFirstDirectionExportedPropertyToNull()
        {
            ExportOptionsModel testOutput = new ExportOptionsModel();

            Assert.IsNull(testOutput.FirstDirectionExported);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
