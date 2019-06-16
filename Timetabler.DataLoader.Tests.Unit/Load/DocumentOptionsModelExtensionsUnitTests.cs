using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.DataLoader.Load;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Tests.Unit.Load
{
    [TestClass]
    public class DocumentOptionsModelExtensionsUnitTests
    {
        [TestMethod]
        public void DocumentOptionsModelExtensionsClassToDocumentOptionsMethodReturnsDocumentOptionsObjectWithCorrectClockTypePropertyIfArgumentClockTypeNamePropertyEqualsTwelveHourClock()
        {
            DocumentOptionsModel testObject = new DocumentOptionsModel { ClockTypeName = "TwelveHourClock" };

            DocumentOptions resultObject = testObject.ToDocumentOptions();

            Assert.AreEqual(ClockType.TwelveHourClock, resultObject.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClassToDocumentOptionsMethodReturnsDocumentOptionsObjectWithCorrectClockTypePropertyIfArgumentClockTypeNamePropertyEqualsTwentyFourHourClock()
        {
            DocumentOptionsModel testObject = new DocumentOptionsModel { ClockTypeName = "TwentyFourHourClock" };

            DocumentOptions resultObject = testObject.ToDocumentOptions();

            Assert.AreEqual(ClockType.TwentyFourHourClock, resultObject.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClassToDocumentOptionsMethodReturnsDocumentOptionsObjectWithCorrectGraphEditStylePropertyIfArgumentGraphEditStylePropertyEqualsFree()
        {
            DocumentOptionsModel testObject = new DocumentOptionsModel { GraphEditStyle = "Free" };

            DocumentOptions resultObject = testObject.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.Free, resultObject.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClassToDocumentOptionsMethodReturnsDocumentOptionsObjectWithCorrectGraphEditStylePropertyIfArgumentGraphEditStylePropertyEqualsPreserveSectionTimes()
        {
            DocumentOptionsModel testObject = new DocumentOptionsModel { GraphEditStyle = "PreserveSectionTimes" };

            DocumentOptions resultObject = testObject.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.PreserveSectionTimes, resultObject.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClassToDocumentOptionsMethodReturnsDocumentOptionsObjectWithGraphEditStylePropertyEqualToFreeIfArgumentGraphEditStylePropertyIsNull()
        {
            DocumentOptionsModel testObject = new DocumentOptionsModel { GraphEditStyle = null };

            DocumentOptions resultObject = testObject.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.Free, resultObject.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClassToDocumentOptionsMethodReturnsDocumentOptionsObjectWithGraphEditStylePropertyEqualToFreeIfArgumentGraphEditStylePropertyIsEmptyString()
        {
            DocumentOptionsModel testObject = new DocumentOptionsModel { GraphEditStyle = "" };

            DocumentOptions resultObject = testObject.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.Free, resultObject.GraphEditStyle);
        }
    }
}