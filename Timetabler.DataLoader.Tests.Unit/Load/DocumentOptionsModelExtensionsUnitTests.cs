using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}