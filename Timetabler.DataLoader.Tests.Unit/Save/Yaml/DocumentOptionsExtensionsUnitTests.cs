using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Data.Tests.Utility.Extensions;
using Timetabler.DataLoader.Save.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
{
    [TestClass]
    public class DocumentOptionsExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static DocumentOptions GetTestObject()
        {
            return new DocumentOptions
            {
                ClockType = _rnd.NextClockType(),
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean(),
                GraphEditStyle = _rnd.NextGraphEditStyle(),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DocumentOptionsExtensionsClass_ToYamlDocumentOptionsModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            DocumentOptions testParam = null;

            _ = testParam.ToYamlDocumentOptionsModel();

            Assert.Fail();
        }

        [TestMethod]
        public void DocumentOptionsExtensionsClass_ToYamlDocumentOptionsModelMethod_ReturnsObjectWithCorrectClockTypeNameParameter_IfParameterIsNotNull()
        {
            DocumentOptions testParam = GetTestObject();

            DocumentOptionsModel testOutput = testParam.ToYamlDocumentOptionsModel();

            Assert.AreEqual(testParam.ClockType.ToString("g"), testOutput.ClockTypeName);
        }

        [TestMethod]
        public void DocumentOptionsExtensionsClass_ToYamlDocumentOptionsModelMethod_ReturnsObjectWithCorrectDisplayTrainLabelsOnGraphsParameter_IfParameterIsNotNull()
        {
            DocumentOptions testParam = GetTestObject();

            DocumentOptionsModel testOutput = testParam.ToYamlDocumentOptionsModel();

            Assert.AreEqual(testParam.DisplayTrainLabelsOnGraphs, testOutput.DisplayTrainLabelsOnGraphs.Value);
        }

        [TestMethod]
        public void DocumentOptionsExtensionsClass_ToYamlDocumentOptionsModelMethod_ReturnsObjectWithCorrectGraphEditStyleParameter_IfParameterIsNotNull()
        {
            DocumentOptions testParam = GetTestObject();

            DocumentOptionsModel testOutput = testParam.ToYamlDocumentOptionsModel();

            Assert.AreEqual(testParam.GraphEditStyle.ToString("g"), testOutput.GraphEditStyle);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
