using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class DocumentOptionsModelExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            DocumentOptionsModel testObject = null;

            _ = testObject.ToDocumentOptions();

            Assert.Fail();
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClass_ToDocumentOptionsMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            DocumentOptionsModel testObject = null;

            try
            {
                _ = testObject.ToDocumentOptions();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }

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
        public void DocumentOptionsModelExtensionsClassToDocumentOptionsMethodReturnsDocumentOptionsObjectWithGraphEditStylePropertyEqualToPreserveSectionTimesIfArgumentGraphEditStylePropertyIsNull()
        {
            DocumentOptionsModel testObject = new DocumentOptionsModel { GraphEditStyle = null };

            DocumentOptions resultObject = testObject.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.PreserveSectionTimes, resultObject.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsModelExtensionsClassToDocumentOptionsMethodReturnsDocumentOptionsObjectWithGraphEditStylePropertyEqualToPreserveSectionTimesIfArgumentGraphEditStylePropertyIsEmptyString()
        {
            DocumentOptionsModel testObject = new DocumentOptionsModel { GraphEditStyle = "" };

            DocumentOptions resultObject = testObject.ToDocumentOptions();

            Assert.AreEqual(GraphEditStyle.PreserveSectionTimes, resultObject.GraphEditStyle);
        }
    }
}