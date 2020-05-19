using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timetabler.CoreData;
using Timetabler.PdfExport.Extensions;
using Unicorn.CoreTypes;

namespace Timetabler.PdfExport.Tests.Unit.Extensions
{
    [TestClass]
    public class OrientationExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void OrientationExtensionsClass_ToPageOrientationMethod_ReturnsLandscapeValue_IfParameterValueIsLandscape()
        {
            Orientation testParam = Orientation.Landscape;

            PageOrientation testOutput = testParam.ToPageOrientation();

            Assert.AreEqual(PageOrientation.Landscape, testOutput);
        }

        [TestMethod]
        public void OrientationExtensionsClass_ToPageOrientationMethod_ReturnsPortraitValue_IfParameterValueIsPortrait()
        {
            Orientation testParam = Orientation.Portrait;

            PageOrientation testOutput = testParam.ToPageOrientation();

            Assert.AreEqual(PageOrientation.Portrait, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores
    }
}
