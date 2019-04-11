using System;
using System.Drawing.Drawing2D;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Models;

namespace Timetabler.Helpers
{
    /// <summary>
    /// A class which boxes an enum value and also provides a human-readable and potentially translated string describing the name of the enum value.  Intended for use as ComboBox selection items.
    /// </summary>
    /// <typeparam name="TEnum">The enum type which this class boxes.</typeparam>
    public class HumanReadableEnum<TEnum> where TEnum : struct, IComparable, IFormattable, IConvertible // if only "where T : enum" was legal but it's not 
    {
        /// <summary>
        /// The human-readable name which matches the <see cref="Value"/> property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The enum value.
        /// </summary>
        public TEnum Value { get; set; }

        /// <summary>
        /// Convert this instance to a string.
        /// </summary>
        /// <returns>The <see cref="Name"/> property of this instance.</returns>
        public override string ToString()
        {
            return Name;
        }

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
    }
}
