using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
{
    [TestClass]
    public class GraphTrainPropertiesExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static GraphTrainProperties GetTestObject()
        {
            DashStyle[] dashStyles = new[]
            {
                DashStyle.Solid,
                DashStyle.Dash,
                DashStyle.Dot,
                DashStyle.DashDot,
                DashStyle.DashDotDot,
                DashStyle.Custom,
            };

            return new GraphTrainProperties
            {
                Colour = Color.FromArgb(_rnd.Next()),
                DashStyle = dashStyles[_rnd.Next(dashStyles.Length)],
                Width = (float)_rnd.NextDouble() * 5,
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GraphTrainPropertiesExtensionsClass_ToYamlGraphTrainPropertiesModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            GraphTrainProperties testParam = null;

            _ = testParam.ToYamlGraphTrainPropertiesModel();

            Assert.Fail();
        }

        [TestMethod]
        public void GraphTrainPropertiesExtensionsClass_ToYamlGraphTrainPropertiesModelMethod_ReturnsObjectWithCorrectColourProperty_IfParameterIsNotNull()
        {
            GraphTrainProperties testParam = GetTestObject();

            GraphTrainPropertiesModel testOutput = testParam.ToYamlGraphTrainPropertiesModel();

            Assert.AreEqual(testParam.Colour.ToArgb().ToString("X8", CultureInfo.InvariantCulture), testOutput.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesExtensionsClass_ToYamlGraphTrainPropertiesModelMethod_ReturnsObjectWithCorrectDashStyleNameProperty_IfParameterIsNotNull()
        {
            GraphTrainProperties testParam = GetTestObject();

            GraphTrainPropertiesModel testOutput = testParam.ToYamlGraphTrainPropertiesModel();

            Assert.AreEqual(testParam.DashStyle.ToString("g"), testOutput.DashStyleName);
        }

        [TestMethod]
        public void GraphTrainPropertiesExtensionsClass_ToYamlGraphTrainPropertiesModelMethod_ReturnsObjectWithCorrectWidthProperty_IfParameterIsNotNull()
        {
            GraphTrainProperties testParam = GetTestObject();

            GraphTrainPropertiesModel testOutput = testParam.ToYamlGraphTrainPropertiesModel();

            Assert.AreEqual(testParam.Width, testOutput.Width);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
