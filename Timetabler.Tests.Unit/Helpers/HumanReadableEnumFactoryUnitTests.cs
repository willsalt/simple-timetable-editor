using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing.Drawing2D;
using System.Linq;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Helpers;
using Timetabler.Models;

namespace Timetabler.Tests.Unit.Helpers
{
    [TestClass]
    public class HumanReadableEnumFactoryUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetDashStylesMethod_ReturnsArrayOfLength5()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnumFactory.GetDashStyles();

            Assert.AreEqual(5, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleSolidValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnumFactory.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.Solid);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_Solid, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleDashValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnumFactory.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.Dash);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_Dash, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleDotValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnumFactory.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.Dot);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_Dot, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleDashDotValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnumFactory.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.DashDot);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_DashDot, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetDashStylesMethod_ReturnsArrayContainingDashStyleDashDotDotValueWithCorrectNameProperty()
        {
            HumanReadableEnum<DashStyle>[] testOutput = HumanReadableEnumFactory.GetDashStyles();

            HumanReadableEnum<DashStyle> item = testOutput.Single(e => e.Value == DashStyle.DashDotDot);
            Assert.AreEqual(Resources.HumanReadableEnum_DashStyle_DashDotDot, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetClockTypesMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<ClockType>[] testOutput = HumanReadableEnumFactory.GetClockTypes();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetClockTypesMethod_ReturnsArrayContainingClockTypeTwelveHourClockValueWithCorrectNameProperty()
        {
            HumanReadableEnum<ClockType>[] testOutput = HumanReadableEnumFactory.GetClockTypes();

            HumanReadableEnum<ClockType> item = testOutput.Single(e => e.Value == ClockType.TwelveHourClock);
            Assert.AreEqual(Resources.HumanReadableEnum_ClockType_12Hour, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetClockTypesMethod_ReturnsArrayContainingClockTypeTwentyFourHourClockValueWithCorrectNameProperty()
        {
            HumanReadableEnum<ClockType>[] testOutput = HumanReadableEnumFactory.GetClockTypes();

            HumanReadableEnum<ClockType> item = testOutput.Single(e => e.Value == ClockType.TwentyFourHourClock);
            Assert.AreEqual(Resources.HumanReadableEnum_ClockType_24Hour, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetArrivalDepartureMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<ArrivalDepartureOptions>[] testOutput = HumanReadableEnumFactory.GetArrivalDeparture();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetArrivalDepartureMethod_ReturnsArrayContainingArrivalDepartureOptionsArrivalValueWithCorrectNameProperty()
        {
            HumanReadableEnum<ArrivalDepartureOptions>[] testOutput = HumanReadableEnumFactory.GetArrivalDeparture();

            HumanReadableEnum<ArrivalDepartureOptions> item = testOutput.Single(e => e.Value == ArrivalDepartureOptions.Arrival);
            Assert.AreEqual(Resources.HumanReadableEnum_ArrivalDeparture_Arrival, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetArrivalDepartureMethod_ReturnsArrayContainingArrivalDepartureOptionsDepartureValueWithCorrectNameProperty()
        {
            HumanReadableEnum<ArrivalDepartureOptions>[] testOutput = HumanReadableEnumFactory.GetArrivalDeparture();

            HumanReadableEnum<ArrivalDepartureOptions> item = testOutput.Single(e => e.Value == ArrivalDepartureOptions.Departure);
            Assert.AreEqual(Resources.HumanReadableEnum_ArrivalDeparture_Departure, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetAddSubtractMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<AddSubtract>[] testOutput = HumanReadableEnumFactory.GetAddSubtract();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetAddSubtractMethod_ReturnsArrayContainingAddSubtractAddValueWithCorrectNameProperty()
        {
            HumanReadableEnum<AddSubtract>[] testOutput = HumanReadableEnumFactory.GetAddSubtract();

            HumanReadableEnum<AddSubtract> item = testOutput.Single(e => e.Value == AddSubtract.Add);
            Assert.AreEqual(Resources.HumanReadableEnum_AddSubtract_Add, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetAddSubtractMethod_ReturnsArrayContainingAddSubtractSubtractValueWithCorrectNameProperty()
        {
            HumanReadableEnum<AddSubtract>[] testOutput = HumanReadableEnumFactory.GetAddSubtract();

            HumanReadableEnum<AddSubtract> item = testOutput.Single(e => e.Value == AddSubtract.Subtract);
            Assert.AreEqual(Resources.HumanReadableEnum_AddSubtract_Subtract, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetLocationFontTypeMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<LocationFontType>[] testOutput = HumanReadableEnumFactory.GetLocationFontType();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetLocationFontTypeMethod_ReturnsArrayContainingLocationFontTypeNormalValueWithCorrectNameProperty()
        {
            HumanReadableEnum<LocationFontType>[] testOutput = HumanReadableEnumFactory.GetLocationFontType();

            HumanReadableEnum<LocationFontType> item = testOutput.Single(e => e.Value == LocationFontType.Normal);
            Assert.AreEqual(Resources.HumanReadableEnum_LocationFontType_Normal, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetLocationFontTypeMethod_ReturnsArrayContainingLocationFontTypeCondensedValueWithCorrectNameProperty()
        {
            HumanReadableEnum<LocationFontType>[] testOutput = HumanReadableEnumFactory.GetLocationFontType();

            HumanReadableEnum<LocationFontType> item = testOutput.Single(e => e.Value == LocationFontType.Condensed);
            Assert.AreEqual(Resources.HumanReadableEnum_LocationFontType_Condensed, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetHalfOfDayForSelectionMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<HalfOfDay>[] testOutput = HumanReadableEnumFactory.GetHalfOfDayForSelection();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetHalfOfDayForSelectionMethod_ReturnsArrayContainingHalfOfDayAMValueWithCorrectNameProperty()
        {
            HumanReadableEnum<HalfOfDay>[] testOutput = HumanReadableEnumFactory.GetHalfOfDayForSelection();

            HumanReadableEnum<HalfOfDay> item = testOutput.Single(e => e.Value == HalfOfDay.AM);
            Assert.AreEqual(Resources.HumanReadableEnum_HalfOfDay_AM, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetHalfOfDayForSelectionMethod_ReturnsArrayContainingHalfOfDayPMValueWithCorrectNameProperty()
        {
            HumanReadableEnum<HalfOfDay>[] testOutput = HumanReadableEnumFactory.GetHalfOfDayForSelection();

            HumanReadableEnum<HalfOfDay> item = testOutput.Single(e => e.Value == HalfOfDay.PM);
            Assert.AreEqual(Resources.HumanReadableEnum_HalfOfDay_PM, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetGraphEditStyleMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<GraphEditStyle>[] testOutput = HumanReadableEnumFactory.GetGraphEditStyle();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetGraphEditStyleMethod_ReturnsArrayContainingGraphEditStyleFreeValueWithCorrectNameProperty()
        {
            HumanReadableEnum<GraphEditStyle>[] testOutput = HumanReadableEnumFactory.GetGraphEditStyle();

            HumanReadableEnum<GraphEditStyle> item = testOutput.Single(e => e.Value == GraphEditStyle.Free);
            Assert.AreEqual(Resources.HumanReadableEnum_GraphEditStyle_Free, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetGraphEditStyleMethod_ReturnsArrayContainingGraphEditStylePreserveSectionTimesValueWithCorrectNameProperty()
        {
            HumanReadableEnum<GraphEditStyle>[] testOutput = HumanReadableEnumFactory.GetGraphEditStyle();

            HumanReadableEnum<GraphEditStyle> item = testOutput.Single(e => e.Value == GraphEditStyle.PreserveSectionTimes);
            Assert.AreEqual(Resources.HumanReadableEnum_GraphEditStyle_PreserveSectionTimes, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetPdfExportEngineMethod_ReturnsArrayOfLength2()
        {
            HumanReadableEnum<PdfExportEngine>[] testOutput = HumanReadableEnumFactory.GetPdfExportEngine();

            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetPdfExportEngineMethod_ReturnsArrayContainingPdfExportEngineUnicornValueWithCorrectNameProperty()
        {
            HumanReadableEnum<PdfExportEngine>[] testOutput = HumanReadableEnumFactory.GetPdfExportEngine();

            HumanReadableEnum<PdfExportEngine> item = testOutput.Single(e => e.Value == PdfExportEngine.Unicorn);
            Assert.AreEqual(Resources.HumanReadableEnum_PdfExportEngine_Unicorn, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetPdfExportEngineMethod_ReturnsArrayContainingPdfExportEngineExternalValueWithCorrectNameProperty()
        {
            HumanReadableEnum<PdfExportEngine>[] testOutput = HumanReadableEnumFactory.GetPdfExportEngine();

            HumanReadableEnum<PdfExportEngine> item = testOutput.Single(e => e.Value == PdfExportEngine.External);
            Assert.AreEqual(Resources.HumanReadableEnum_PdfExportEngine_External, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetOrientationMethod_ReturnsArrayContainingPortraitValueWithCorrectNameProperty()
        {
            HumanReadableEnum<Orientation>[] testOutput = HumanReadableEnumFactory.GetOrientation();

            HumanReadableEnum<Orientation> item = testOutput.Single(e => e.Value == Orientation.Portrait);
            Assert.AreEqual(Resources.HumanReadableEnum_Orientation_Portrait, item.Name);
        }

        [TestMethod]
        public void HumanReadableEnumFactoryClass_GetOrientationMethod_ReturnsArrayContainingLandscapeValueWithCorrectNameProperty()
        {
            HumanReadableEnum<Orientation>[] testOutput = HumanReadableEnumFactory.GetOrientation();

            HumanReadableEnum<Orientation> item = testOutput.Single(e => e.Value == Orientation.Landscape);
            Assert.AreEqual(Resources.HumanReadableEnum_Orientation_Landscape, item.Name);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
