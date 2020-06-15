using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class GraphTrainPropertiesModelExtensionsUnitTests
    {
        private static readonly Random _random = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesMethod_DoesNotReturnNull_IfParameterIsNull()
        {
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel();

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.IsNotNull(testResult);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesMethod_ReturnsNull_IfParameterIsNull()
        {
            GraphTrainPropertiesModel testObject = null;

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.IsNull(testResult);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesMethod_ReturnsObjectWithCorrectColourProperty()
        {
            Color testColour = Color.FromArgb(_random.Next());
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel { ColourCode = testColour.ToArgb().ToString("X8", CultureInfo.InvariantCulture) };

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.AreEqual(testColour, testResult.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesMethod_ReturnsObjectWithCorrectDashStyleProperty()
        {
            DashStyle[] validDashStyles = new[] { DashStyle.Dash, DashStyle.DashDot, DashStyle.DashDotDot, DashStyle.Dot, DashStyle.Solid };
            DashStyle testDashStyle = validDashStyles[_random.Next(validDashStyles.Length)];
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel { DashStyleName = Enum.GetName(typeof(DashStyle), testDashStyle) };

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.AreEqual(testDashStyle, testResult.DashStyle);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesMethod_ReturnsObjectWithCorrectWidthProperty()
        {
            float testWidth = (float)(_random.NextDouble() * 10);
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel { Width = testWidth };

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.AreEqual(testWidth, testResult.Width);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
