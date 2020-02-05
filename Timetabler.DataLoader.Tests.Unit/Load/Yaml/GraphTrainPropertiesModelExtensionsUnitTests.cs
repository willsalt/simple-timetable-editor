using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class GraphTrainPropertiesModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static readonly string[] _validDashStyles = { "Solid", "Dash", "Dot", "DashDot", "DashDotDot", "Custom" };

        private static GraphTrainPropertiesModel GetModel()
        {
            int colour = _rnd.Next();
            return new GraphTrainPropertiesModel
            {
                Colour = colour.ToString("X8", CultureInfo.InvariantCulture),
                Width = _rnd.NextNullableFloat(5f),
                DashStyleName = _rnd.NextPotentiallyValidString(_validDashStyles),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            GraphTrainPropertiesModel testParam = null;

            testParam.ToGraphTrainProperties();

            Assert.Fail();
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesModel_ReturnsObjectWithCorrectWidthProperty_IfWidthPropertyOfParameterIsNotNull()
        {
            GraphTrainPropertiesModel testParam = GetModel();
            testParam.Width = (float)(_rnd.NextDouble() * 5);

            GraphTrainProperties testOutput = testParam.ToGraphTrainProperties();

            Assert.AreEqual(testParam.Width, testOutput.Width);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesModel_ReturnsObjectWithWidthPropertyEqualTo1_IfWidthPropertyOfParameterIsNull()
        {
            GraphTrainPropertiesModel testParam = GetModel();
            testParam.Width = null;

            GraphTrainProperties testOutput = testParam.ToGraphTrainProperties();

            Assert.AreEqual(1f, testOutput.Width);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesModel_ReturnsObjectWithCorrectColourProperty_IfColourPropertyOfParameterIsValid()
        {
            GraphTrainPropertiesModel testParam = GetModel();

            GraphTrainProperties testOutput = testParam.ToGraphTrainProperties();

            Assert.AreEqual(testParam.Colour, testOutput.Colour.ToArgb().ToString("X8", CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesModel_ReturnsObjectWithColourPropertyEqualToBlack_IfColourPropertyOfParameterIsNotValid()
        {
            GraphTrainPropertiesModel testParam = GetModel();
            testParam.Colour = _rnd.NextString("GHIJKLMNOPQRSTVWXYZ", _rnd.Next(20));

            GraphTrainProperties testOutput = testParam.ToGraphTrainProperties();

            Assert.AreEqual(Color.Black, testOutput.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesModel_ReturnsObjectWithColourPropertyEqualToBlack_IfColourPropertyOfParameterIsNull()
        {
            GraphTrainPropertiesModel testParam = GetModel();
            testParam.Colour = null;

            GraphTrainProperties testOutput = testParam.ToGraphTrainProperties();

            Assert.AreEqual(Color.Black, testOutput.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesModel_ReturnsObjectWithCorrectDashStyleProperty_IfDashStyleNamePropertyOfParameterIsValid()
        {
            GraphTrainPropertiesModel testParam = GetModel();
            testParam.DashStyleName = _validDashStyles[_rnd.Next(_validDashStyles.Length)];

            GraphTrainProperties testOutput = testParam.ToGraphTrainProperties();

            Assert.AreEqual(testParam.DashStyleName, testOutput.DashStyle.ToString("g"));
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesModel_ReturnsObjectWithDashStylePropertyEqualToSolid_IfDashStyleNamePropertyOfParameterIsNotValid()
        {
            GraphTrainPropertiesModel testParam = GetModel();
            testParam.DashStyleName = _rnd.NextDefinitelyInvalidString(_validDashStyles);

            GraphTrainProperties testOutput = testParam.ToGraphTrainProperties();

            Assert.AreEqual(DashStyle.Solid, testOutput.DashStyle);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesModel_ReturnsObjectWithDashStylePropertyEqualToSolid_IfDashStyleNamePropertyOfParameterIsNull()
        {
            GraphTrainPropertiesModel testParam = GetModel();
            testParam.DashStyleName = null;

            GraphTrainProperties testOutput = testParam.ToGraphTrainProperties();

            Assert.AreEqual(DashStyle.Solid, testOutput.DashStyle);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
