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
    public class ColourExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ColourExtensionsClass_ToColorMethod_ReturnsColorValueWithSameArgbValueAsParameter()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testParam = new Colour(constrParam);

            Color testOutput = testParam.ToColor();

            Assert.AreEqual(testParam.Argb, (uint)testOutput.ToArgb());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
