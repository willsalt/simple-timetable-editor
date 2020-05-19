using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class DocumentOptionsModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;
        private static readonly string[] _validClockTypes = { "TwelveHourClock", "TwentyFourHourClock" };
        private static readonly string[] _validGraphEditStyles = { "Free", "PreserveSectionTimes" };

        private static DocumentOptionsModel GetModel()
        {
            DocumentOptionsModel model = new DocumentOptionsModel
            {
                DisplayTrainLabelsOnGraphs = _rnd.NextNullableBoolean(),
                ClockTypeName = _rnd.NextPotentiallyValidString(_validClockTypes),
                GraphEditStyle = _rnd.NextPotentiallyValidString(_validGraphEditStyles),
            };
            
            return model;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            DocumentOptionsModel testParam = null;

            testParam.ToDocumentOptions();

            Assert.Fail();
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithDisplayTrainLabelsOnGraphsPropertyEqualToTrue_IfParameterHasDisplayTrainLabelsOnGraphsPropertyEqualToTrue()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.DisplayTrainLabelsOnGraphs = true;

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.IsTrue(testOutput.DisplayTrainLabelsOnGraphs);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithDisplayTrainLabelsOnGraphsPropertyEqualToFalse_IfParameterHasDisplayTrainLabelsOnGraphsPropertyEqualToFalse()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.DisplayTrainLabelsOnGraphs = false;

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.IsFalse(testOutput.DisplayTrainLabelsOnGraphs);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithDisplayTrainLabelsOnGraphsPropertyEqualToTrue_IfParameterHasDisplayTrainLabelsOnGraphsPropertyEqualToNull()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.DisplayTrainLabelsOnGraphs = null;

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.IsTrue(testOutput.DisplayTrainLabelsOnGraphs);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithClockTypePropertyEqualToTwelveHourClock_IfParameterHasClockTypeNamePropertyEqualToTwelveHourClock()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.ClockTypeName = "TwelveHourClock";

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.AreEqual(ClockType.TwelveHourClock, testOutput.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithClockTypePropertyEqualToTwentyFourHourClock_IfParameterHasClockTypeNamePropertyEqualToTwentyFourHourClock()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.ClockTypeName = "TwentyFourHourClock";

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.AreEqual(ClockType.TwentyFourHourClock, testOutput.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithClockTypePropertyEqualToTwelveHourClock_IfParameterHasClockTypeNamePropertyIsNotAValidEnumValue()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.ClockTypeName = _rnd.NextDefinitelyInvalidString(_validClockTypes);

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.AreEqual(ClockType.TwelveHourClock, testOutput.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithClockTypePropertyEqualToTwelveHourClock_IfParameterHasClockTypeNamePropertyIsNull()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.ClockTypeName = null;

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.AreEqual(ClockType.TwelveHourClock, testOutput.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithGraphEditStylePropertyEqualToFree_IfParameterHasGraphEditStylePropertyEqualToFree()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.GraphEditStyle = "Free";

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.Free, testOutput.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithGraphEditStylePropertyEqualToPreserveSectionTimes_IfParameterHasGraphEditStylePropertyEqualToPreserveSectionTimes()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.GraphEditStyle = "PreserveSectionTimes";

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.PreserveSectionTimes, testOutput.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithGraphEditStylePropertyEqualToPreserveSectionTimes_IfParameterHasGraphEditStylePropertyThatIsNotAValidValue()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.GraphEditStyle = _rnd.NextDefinitelyInvalidString(_validGraphEditStyles);

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.PreserveSectionTimes, testOutput.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ReturnsObjectWithGraphEditStylePropertyEqualToPreserveSectionTimes_IfParameterHasGraphEditStylePropertyEqualToNull()
        {
            DocumentOptionsModel testParam = GetModel();
            testParam.GraphEditStyle = null;

            DocumentOptions testOutput = testParam.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.PreserveSectionTimes, testOutput.GraphEditStyle);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
