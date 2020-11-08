using System.Drawing.Drawing2D;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Models;

namespace Timetabler.Helpers
{
    /// <summary>
    /// HumanReadableEnum&lt;T&gt; generator methods.
    /// </summary>
    public static class HumanReadableEnumFactory
    {
        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}"/> instances representing the values of the <see cref="DashStyle"/> enumeration.
        /// </summary>
        /// <remarks>The DashStyle.Custom value is not included in the output, as the program does not currently support this dash style.</remarks>
        /// <returns>An array of <see cref="HumanReadableEnum{TEnum}"/> instances.</returns>
        public static HumanReadableEnum<DashStyle>[] GetDashStyles()
        {
            return new[]
            {
                new HumanReadableEnum<DashStyle> { Name = Resources.HumanReadableEnum_DashStyle_Solid, Value = DashStyle.Solid },
                new HumanReadableEnum<DashStyle> { Name = Resources.HumanReadableEnum_DashStyle_Dash, Value = DashStyle.Dash },
                new HumanReadableEnum<DashStyle> { Name = Resources.HumanReadableEnum_DashStyle_Dot, Value = DashStyle.Dot },
                new HumanReadableEnum<DashStyle> { Name = Resources.HumanReadableEnum_DashStyle_DashDot, Value = DashStyle.DashDot },
                new HumanReadableEnum<DashStyle> { Name = Resources.HumanReadableEnum_DashStyle_DashDotDot, Value = DashStyle.DashDotDot },
            };
        }

        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}"/> instances representing the values of the <see cref="ClockType"/> enumeration.
        /// </summary>
        /// <returns>An array of <see cref="HumanReadableEnum{TEnum}"/> instances.</returns>
        public static HumanReadableEnum<ClockType>[] GetClockTypes()
        {
            return new[]
            {
                new HumanReadableEnum<ClockType> { Name = Resources.HumanReadableEnum_ClockType_12Hour, Value = ClockType.TwelveHourClock },
                new HumanReadableEnum<ClockType> { Name = Resources.HumanReadableEnum_ClockType_24Hour, Value = ClockType.TwentyFourHourClock },
            };
        }

        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}"/> instances representing the values of the <see cref="ArrivalDepartureOptions"/> enumeration.
        /// </summary>
        /// <returns>An array of <see cref="HumanReadableEnum{TEnum}"/> instances.</returns>
        public static HumanReadableEnum<ArrivalDepartureOptions>[] GetArrivalDeparture()
        {
            return new[]
            {
                new HumanReadableEnum<ArrivalDepartureOptions> { Name = Resources.HumanReadableEnum_ArrivalDeparture_Arrival, Value = ArrivalDepartureOptions.Arrival },
                new HumanReadableEnum<ArrivalDepartureOptions> { Name = Resources.HumanReadableEnum_ArrivalDeparture_Departure, Value = ArrivalDepartureOptions.Departure }
            };
        }

        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}"/> instances representing the values of the <see cref="AddSubtract"/> enumeration.
        /// </summary>
        /// <returns>An array of <see cref="HumanReadableEnum{TEnum}"/> instances.</returns>
        public static HumanReadableEnum<AddSubtract>[] GetAddSubtract()
        {
            return new[]
            {
                new HumanReadableEnum<AddSubtract> { Name = Resources.HumanReadableEnum_AddSubtract_Add, Value = AddSubtract.Add },
                new HumanReadableEnum<AddSubtract> { Name = Resources.HumanReadableEnum_AddSubtract_Subtract, Value = AddSubtract.Subtract },
            };
        }

        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}"/> instances representing the values of the <see cref="LocationFontType"/> enumeration.
        /// </summary>
        /// <returns>An array of <see cref="HumanReadableEnum{TEnum}"/> instances.</returns>
        public static HumanReadableEnum<LocationFontType>[] GetLocationFontType()
        {
            return new[]
            {
                new HumanReadableEnum<LocationFontType> { Name = Resources.HumanReadableEnum_LocationFontType_Normal, Value = LocationFontType.Normal },
                new HumanReadableEnum<LocationFontType> { Name = Resources.HumanReadableEnum_LocationFontType_Condensed, Value = LocationFontType.Condensed },
            };
        }

        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}"/> instances representing the "AM" and "PM" values of the <see cref="HalfOfDay"/> enumeration.
        /// </summary>
        /// <returns>An array of <see cref="HumanReadableEnum{TEnum}"/> instances.</returns>
        public static HumanReadableEnum<HalfOfDay>[] GetHalfOfDayForSelection()
        {
            return new[]
            {
                new HumanReadableEnum<HalfOfDay> { Name = Resources.HumanReadableEnum_HalfOfDay_AM, Value = HalfOfDay.AM },
                new HumanReadableEnum<HalfOfDay> { Name = Resources.HumanReadableEnum_HalfOfDay_PM, Value = HalfOfDay.PM },
            };
        }

        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}" /> instances representing the values of the <see cref="GraphEditStyle" /> enumeration.
        /// </summary>
        /// <returns>An array of <see cref="HumanReadableEnum{TEnum}" /> instances.</returns>
        public static HumanReadableEnum<GraphEditStyle>[] GetGraphEditStyle()
        {
            return new[]
            {
                new HumanReadableEnum<GraphEditStyle> { Name = Resources.HumanReadableEnum_GraphEditStyle_Free, Value = GraphEditStyle.Free },
                new HumanReadableEnum<GraphEditStyle> { Name = Resources.HumanReadableEnum_GraphEditStyle_PreserveSectionTimes, Value = GraphEditStyle.PreserveSectionTimes }
            };
        }

        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}" /> instances representing the values of the <see cref="Orientation" /> enumeration.
        /// </summary>
        /// <returns>An array of <see cref="HumanReadableEnum{TEnum}" /> instances.</returns>
        public static HumanReadableEnum<Orientation>[] GetOrientation()
        {
            return new[]
            {
                new HumanReadableEnum<Orientation> { Name = Resources.HumanReadableEnum_Orientation_Landscape, Value = Orientation.Landscape },
                new HumanReadableEnum<Orientation> { Name = Resources.HumanReadableEnum_Orientation_Portrait, Value = Orientation.Portrait },
            };
        }

        /// <summary>
        /// Generate an array of <see cref="HumanReadableEnum{TEnum}" /> instances representing the values of the <see cref="SectionSelection" /> enumeration.
        /// </summary>
        /// <returns></returns>
        public static HumanReadableEnum<SectionSelection>[] GetSectionSelection()
        {
            return new[]
            {
                new HumanReadableEnum<SectionSelection> { Name = Resources.HumanReadableEnum_SectionSelection_None, Value = SectionSelection.None },
                new HumanReadableEnum<SectionSelection> { Name = Resources.HumanReadableEnum_SectionSelection_First, Value = SectionSelection.First },
                new HumanReadableEnum<SectionSelection> { Name = Resources.HumanReadableEnum_SectionSelection_All, Value = SectionSelection.All },
            };
        }
    }
}
