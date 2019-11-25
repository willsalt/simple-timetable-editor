using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing.Drawing2D;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Helpers;
using Timetabler.Models;

namespace Timetabler.Tests.Unit.Helpers
{
    [TestClass]
    public class HumanReadableEnumUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void HumanReadableEnumClass_ToStringMethod_ReturnsNameProperty()
        {
            string testValue = _rnd.NextString(_rnd.Next(48));
            HumanReadableEnum<ClockType> testObject = new HumanReadableEnum<ClockType> { Value = ClockType.TwelveHourClock, Name = testValue };

            string testOutput = testObject.ToString();

            Assert.AreEqual(testValue, testOutput);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetDashStylesMethod_ReturnsArrayOfLength5()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnum<DashStyle>.GetDashStyles();

            Assert.AreEqual(5, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleSolidValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnum<DashStyle>.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.Solid);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_Solid, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleDashValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnum<DashStyle>.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.Dash);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_Dash, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleDotValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnum<DashStyle>.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.Dot);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_Dot, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleDashDotValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnum<DashStyle>.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.DashDot);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_DashDot, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleDashDotDotValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnum<DashStyle>.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.DashDotDot);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_DashDotDot, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetClockTypesMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<ClockType>[] testOutput = HumanReadableEnum<ClockType>.GetClockTypes();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetClockTypesMethod_ReturnsArrayContainingClockTypeTwelveHourClockValueWithCorrectNameProperty()
        {
            HumanReadableEnum<ClockType>[] testOutput = HumanReadableEnum<ClockType>.GetClockTypes();

            HumanReadableEnum<ClockType> item = testOutput.Single(e => e.Value == ClockType.TwelveHourClock);
            Assert.AreEqual(Resources.HumanReadableEnum_ClockType_12Hour, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetClockTypesMethod_ReturnsArrayContainingClockTypeTwentyFourHourClockValueWithCorrectNameProperty()
        {
            HumanReadableEnum<ClockType>[] testOutput = HumanReadableEnum<ClockType>.GetClockTypes();

            HumanReadableEnum<ClockType> item = testOutput.Single(e => e.Value == ClockType.TwentyFourHourClock);
            Assert.AreEqual(Resources.HumanReadableEnum_ClockType_24Hour, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetArrivalDepartureMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<ArrivalDepartureOptions>[] testOutput = HumanReadableEnum<ArrivalDepartureOptions>.GetArrivalDeparture();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetArrivalDepartureMethod_ReturnsArrayContainingArrivalDepartureOptionsArrivalValueWithCorrectNameProperty()
        {
            HumanReadableEnum<ArrivalDepartureOptions>[] testOutput = HumanReadableEnum<ArrivalDepartureOptions>.GetArrivalDeparture();

            HumanReadableEnum<ArrivalDepartureOptions> item = testOutput.Single(e => e.Value == ArrivalDepartureOptions.Arrival);
            Assert.AreEqual(Resources.HumanReadableEnum_ArrivalDeparture_Arrival, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetArrivalDepartureMethod_ReturnsArrayContainingArrivalDepartureOptionsDepartureValueWithCorrectNameProperty()
        {
            HumanReadableEnum<ArrivalDepartureOptions>[] testOutput = HumanReadableEnum<ArrivalDepartureOptions>.GetArrivalDeparture();

            HumanReadableEnum<ArrivalDepartureOptions> item = testOutput.Single(e => e.Value == ArrivalDepartureOptions.Departure);
            Assert.AreEqual(Resources.HumanReadableEnum_ArrivalDeparture_Departure, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetAddSubtractMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<AddSubtract>[] testOutput = HumanReadableEnum<AddSubtract>.GetAddSubtract();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetAddSubtractMethod_ReturnsArrayContainingAddSubtractAddValueWithCorrectNameProperty()
        {
            HumanReadableEnum<AddSubtract>[] testOutput = HumanReadableEnum<AddSubtract>.GetAddSubtract();

            HumanReadableEnum<AddSubtract> item = testOutput.Single(e => e.Value == AddSubtract.Add);
            Assert.AreEqual(Resources.HumanReadableEnum_AddSubtract_Add, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetAddSubtractMethod_ReturnsArrayContainingAddSubtractSubtractValueWithCorrectNameProperty()
        {
            HumanReadableEnum<AddSubtract>[] testOutput = HumanReadableEnum<AddSubtract>.GetAddSubtract();

            HumanReadableEnum<AddSubtract> item = testOutput.Single(e => e.Value == AddSubtract.Subtract);
            Assert.AreEqual(Resources.HumanReadableEnum_AddSubtract_Subtract, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetLocationFontTypeMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<LocationFontType>[] testOutput = HumanReadableEnum<LocationFontType>.GetLocationFontType();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetLocationFontTypeMethod_ReturnsArrayContainingLocationFontTypeNormalValueWithCorrectNameProperty()
        {
            HumanReadableEnum<LocationFontType>[] testOutput = HumanReadableEnum<LocationFontType>.GetLocationFontType();

            HumanReadableEnum<LocationFontType> item = testOutput.Single(e => e.Value == LocationFontType.Normal);
            Assert.AreEqual(Resources.HumanReadableEnum_LocationFontType_Normal, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetLocationFontTypeMethod_ReturnsArrayContainingLocationFontTypeCondensedValueWithCorrectNameProperty()
        {
            HumanReadableEnum<LocationFontType>[] testOutput = HumanReadableEnum<LocationFontType>.GetLocationFontType();

            HumanReadableEnum<LocationFontType> item = testOutput.Single(e => e.Value == LocationFontType.Condensed);
            Assert.AreEqual(Resources.HumanReadableEnum_LocationFontType_Condensed, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetHalfOfDayForSelectionMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<HalfOfDay>[] testOutput = HumanReadableEnum<HalfOfDay>.GetHalfOfDayForSelection();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetHalfOfDayForSelectionMethod_ReturnsArrayContainingHalfOfDayAMValueWithCorrectNameProperty()
        {
            HumanReadableEnum<HalfOfDay>[] testOutput = HumanReadableEnum<HalfOfDay>.GetHalfOfDayForSelection();

            HumanReadableEnum<HalfOfDay> item = testOutput.Single(e => e.Value == HalfOfDay.AM);
            Assert.AreEqual(Resources.HumanReadableEnum_HalfOfDay_AM, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetHalfOfDayForSelectionMethod_ReturnsArrayContainingHalfOfDayPMValueWithCorrectNameProperty()
        {
            HumanReadableEnum<HalfOfDay>[] testOutput = HumanReadableEnum<HalfOfDay>.GetHalfOfDayForSelection();

            HumanReadableEnum<HalfOfDay> item = testOutput.Single(e => e.Value == HalfOfDay.PM);
            Assert.AreEqual(Resources.HumanReadableEnum_HalfOfDay_PM, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetGraphEditStyleMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<GraphEditStyle>[] testOutput = HumanReadableEnum<GraphEditStyle>.GetGraphEditStyle();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetGraphEditStyleMethod_ReturnsArrayContainingGraphEditStyleFreeValueWithCorrectNameProperty()
        {
            HumanReadableEnum<GraphEditStyle>[] testOutput = HumanReadableEnum<GraphEditStyle>.GetGraphEditStyle();

            HumanReadableEnum<GraphEditStyle> item = testOutput.Single(e => e.Value == GraphEditStyle.Free);
            Assert.AreEqual(Resources.HumanReadableEnum_GraphEditStyle_Free, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetGraphEditStyleMethod_ReturnsArrayContainingGraphEditStylePreserveSectionTimesValueWithCorrectNameProperty()
        {
            HumanReadableEnum<GraphEditStyle>[] testOutput = HumanReadableEnum<GraphEditStyle>.GetGraphEditStyle();

            HumanReadableEnum<GraphEditStyle> item = testOutput.Single(e => e.Value == GraphEditStyle.PreserveSectionTimes);
            Assert.AreEqual(Resources.HumanReadableEnum_GraphEditStyle_PreserveSectionTimes, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetPdfExportEngineMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<PdfExportEngine>[] testOutput = HumanReadableEnum<PdfExportEngine>.GetPdfExportEngine();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetPdfExportEngineMethod_ReturnsArrayContainingPdfExportEngineUnicornValueWithCorrectNameProperty()
        {
            HumanReadableEnum<PdfExportEngine>[] testOutput = HumanReadableEnum<PdfExportEngine>.GetPdfExportEngine();

            HumanReadableEnum<PdfExportEngine> item = testOutput.Single(e => e.Value == PdfExportEngine.Unicorn);
            Assert.AreEqual(Resources.HumanReadableEnum_PdfExportEngine_Unicorn, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumClass_GetPdfExportEngineMethod_ReturnsArrayContainingPdfExportEngineExternalValueWithCorrectNameProperty()
        {
            HumanReadableEnum<PdfExportEngine>[] testOutput = HumanReadableEnum<PdfExportEngine>.GetPdfExportEngine();

            HumanReadableEnum<PdfExportEngine> item = testOutput.Single(e => e.Value == PdfExportEngine.External);
            Assert.AreEqual(Resources.HumanReadableEnum_PdfExportEngine_External, item.Name);
        }
    }
}
