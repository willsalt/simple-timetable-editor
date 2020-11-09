using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Extensions;

namespace Timetabler.Tests.Unit.Extensions
{
    [TestClass]
    public class DashStyleExtensionsUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DashStyleExtensionsClass_ToSystemDashStyleMethod_ReturnsCorrectValue_IfParameterEqualsSolid()
        {
            CoreData.DashStyle testParam = CoreData.DashStyle.Solid;

            System.Drawing.Drawing2D.DashStyle testOutput = testParam.ToSystemDashStyle();

            Assert.AreEqual(System.Drawing.Drawing2D.DashStyle.Solid, testOutput);
        }

        [TestMethod]
        public void DashStyleExtensionsClass_ToSystemDashStyleMethod_ReturnsCorrectValue_IfParameterEqualsDash()
        {
            CoreData.DashStyle testParam = CoreData.DashStyle.Dash;

            System.Drawing.Drawing2D.DashStyle testOutput = testParam.ToSystemDashStyle();

            Assert.AreEqual(System.Drawing.Drawing2D.DashStyle.Dash, testOutput);
        }

        [TestMethod]
        public void DashStyleExtensionsClass_ToSystemDashStyleMethod_ReturnsCorrectValue_IfParameterEqualsDot()
        {
            CoreData.DashStyle testParam = CoreData.DashStyle.Dot;

            System.Drawing.Drawing2D.DashStyle testOutput = testParam.ToSystemDashStyle();

            Assert.AreEqual(System.Drawing.Drawing2D.DashStyle.Dot, testOutput);
        }

        [TestMethod]
        public void DashStyleExtensionsClass_ToSystemDashStyleMethod_ReturnsCorrectValue_IfParameterEqualsDashDot()
        {
            CoreData.DashStyle testParam = CoreData.DashStyle.DashDot;

            System.Drawing.Drawing2D.DashStyle testOutput = testParam.ToSystemDashStyle();

            Assert.AreEqual(System.Drawing.Drawing2D.DashStyle.DashDot, testOutput);
        }

        [TestMethod]
        public void DashStyleExtensionsClass_ToSystemDashStyleMethod_ReturnsCorrectValue_IfParameterEqualsDashDotDot()
        {
            CoreData.DashStyle testParam = CoreData.DashStyle.DashDotDot;

            System.Drawing.Drawing2D.DashStyle testOutput = testParam.ToSystemDashStyle();

            Assert.AreEqual(System.Drawing.Drawing2D.DashStyle.DashDotDot, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
