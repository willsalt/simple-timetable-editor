using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Extensions;

namespace Timetabler.Tests.Unit.Extensions
{
    [TestClass]
    public class ColorExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ColorExtensionsClass_ToColourMethod_ReturnsColourWithSameArgbPropertyAsParameter()
        {
            int constrParam = (int)_rnd.NextUInt();
            Color testParam = Color.FromArgb(constrParam);

            Colour testOutput = testParam.ToColour();

            Assert.AreEqual((uint)constrParam, testOutput.Argb);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
