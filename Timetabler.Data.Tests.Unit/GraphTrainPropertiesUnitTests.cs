using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Tests.Utility.Providers;
using Timetabler.Data.Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class GraphTrainPropertiesUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void GraphTrainPropertiesClass_Constructor_SetsWidthPropertyToTwo()
        {
            GraphTrainProperties testObject = new GraphTrainProperties();

            Assert.AreEqual(2f, testObject.Width);
        }

        [TestMethod]
        public void GraphTrainPropertiesClass_Constructor_SetsColourPropertyToBlack()
        {
            GraphTrainProperties testObject = new GraphTrainProperties();

            Assert.AreEqual(Color.Black, testObject.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesClass_Constructor_SetsDashStylePropertyToSolid()
        {
            GraphTrainProperties testObject = new GraphTrainProperties();

            Assert.AreEqual(DashStyle.Solid, testObject.DashStyle);
        }

        [TestMethod]
        public void GraphTrainPropertiesClass_CopyMethod_ReturnsNewObjectWithCorrectWidthProperty()
        {
            GraphTrainProperties testObject = _rnd.NextGraphTrainProperties();

            GraphTrainProperties testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Width, testOutput.Width);
        }

        [TestMethod]
        public void GraphTrainPropertiesClass_CopyMethod_ReturnsNewObjectWithCorrectColourProperty()
        {
            GraphTrainProperties testObject = _rnd.NextGraphTrainProperties();

            GraphTrainProperties testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Colour, testOutput.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesClass_CopyMethod_ReturnsNewObjectWithCorrectDashStyleProperty()
        {
            GraphTrainProperties testObject = _rnd.NextGraphTrainProperties();

            GraphTrainProperties testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DashStyle, testOutput.DashStyle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GraphTrainPropertiesClass_CopyToMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            GraphTrainProperties testObject = _rnd.NextGraphTrainProperties();
            GraphTrainProperties testParam = null;

            testObject.CopyTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void GraphTrainPropertiesClass_CopyToMethod_SetsWidthPropertyOfParameter_IfParameterIsNotNull()
        {
            GraphTrainProperties testObject = _rnd.NextGraphTrainProperties();
            GraphTrainProperties testParam = _rnd.NextGraphTrainProperties();

            testObject.CopyTo(testParam);

            Assert.AreEqual(testObject.Width, testParam.Width);
        }

        [TestMethod]
        public void GraphTrainPropertiesClass_CopyToMethod_SetsColourPropertyOfParameter_IfParameterIsNotNull()
        {
            GraphTrainProperties testObject = _rnd.NextGraphTrainProperties();
            GraphTrainProperties testParam = _rnd.NextGraphTrainProperties();

            testObject.CopyTo(testParam);

            Assert.AreEqual(testObject.Colour, testParam.Colour);
        }

        [TestMethod]
        public void GraphTrainPropertiesClass_CopyToMethod_SetsDashStylePropertyOfParameter_IfParameterIsNotNull()
        {
            GraphTrainProperties testObject = _rnd.NextGraphTrainProperties();
            GraphTrainProperties testParam = _rnd.NextGraphTrainProperties();

            testObject.CopyTo(testParam);

            Assert.AreEqual(testObject.DashStyle, testParam.DashStyle);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
