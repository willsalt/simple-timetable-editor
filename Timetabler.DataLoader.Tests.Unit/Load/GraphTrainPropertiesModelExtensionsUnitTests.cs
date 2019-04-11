using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using Timetabler.Data;
using Timetabler.DataLoader.Load;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Tests.Unit.Load
{
    [TestClass]
    public class GraphTrainPropertiesModelExtensionsUnitTests
    {
        private Random _random;

        public GraphTrainPropertiesModelExtensionsUnitTests()
        {
            _random = new Random();
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClassToGraphTrainPropertiesMethodDoesNotReturnNullIfParameterIsNull()
        {
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel();

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.IsNotNull(testResult);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClassToGraphTrainPropertiesMethodReturnsNullIfParameterIsNull()
        {
            GraphTrainPropertiesModel testObject = null;

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.IsNull(testResult);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClassToGraphTrainPropertiesMethodReturnsObjectWithCorrectColourProperty()
        {
            Color testColour = Color.FromArgb(_random.Next());
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel { ColourCode = testColour.ToArgb().ToString("X8", CultureInfo.InvariantCulture) };

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.AreEqual(testColour, testResult.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClassToGraphTrainPropertiesMethodReturnsObjectWithCorrectDashStyleProperty()
        {
            DashStyle[] validDashStyles = new[] { DashStyle.Dash, DashStyle.DashDot, DashStyle.DashDotDot, DashStyle.Dot, DashStyle.Solid };
            DashStyle testDashStyle = validDashStyles[_random.Next(validDashStyles.Length)];
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel { DashStyleName = Enum.GetName(typeof(DashStyle), testDashStyle) };

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.AreEqual(testDashStyle, testResult.DashStyle);
        }

        [TestMethod]
        public void GraphTrainPropertiesModelExtensionsClassToGraphTrainPropertiesMethodReturnsObjectWithCorrectWidthProperty()
        {
            float testWidth = (float)(_random.NextDouble() * 10);
            GraphTrainPropertiesModel testObject = new GraphTrainPropertiesModel { Width = testWidth };

            GraphTrainProperties testResult = testObject.ToGraphTrainProperties();

            Assert.AreEqual(testWidth, testResult.Width);
        }
    }
}
