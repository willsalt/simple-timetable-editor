using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
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
            };

            return new GraphTrainProperties
            {
                Colour = new Colour(_rnd.NextUInt()),
                DashStyle = dashStyles[_rnd.Next(dashStyles.Length)],
                Width = (float)_rnd.NextDouble() * 5,
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GraphTrainPropertiesExtensionsClass_ToGraphTrainPropertiesModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            GraphTrainProperties testParam = null;

            _ = testParam.ToGraphTrainPropertiesModel();

            Assert.Fail();
        }

        [TestMethod]
        public void GraphTrainPropertiesExtensionsClass_ToGraphTrainPropertiesModelMethod_ReturnsObjectWithCorrectColourProperty_IfParameterIsNotNull()
        {
            GraphTrainProperties testParam = GetTestObject();

            GraphTrainPropertiesModel testOutput = testParam.ToGraphTrainPropertiesModel();

            Assert.AreEqual(testParam.Colour.Argb.ToString("X8", CultureInfo.InvariantCulture), testOutput.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesExtensionsClass_ToGraphTrainPropertiesModelMethod_ReturnsObjectWithCorrectDashStyleNameProperty_IfParameterIsNotNull()
        {
            GraphTrainProperties testParam = GetTestObject();

            GraphTrainPropertiesModel testOutput = testParam.ToGraphTrainPropertiesModel();

            Assert.AreEqual(testParam.DashStyle.ToString("g"), testOutput.DashStyleName);
        }

        [TestMethod]
        public void GraphTrainPropertiesExtensionsClass_ToGraphTrainPropertiesModelMethod_ReturnsObjectWithCorrectWidthProperty_IfParameterIsNotNull()
        {
            GraphTrainProperties testParam = GetTestObject();

            GraphTrainPropertiesModel testOutput = testParam.ToGraphTrainPropertiesModel();

            Assert.AreEqual(testParam.Width, testOutput.Width);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
