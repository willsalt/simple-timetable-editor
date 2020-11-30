using System;

namespace Timetabler.CoreData
{
    /// <summary>
    /// An enumeration for the part of the day a time may fall in.
    /// </summary>
    public enum HalfOfDay
    {
        /// <summary>
        /// Morning.
        /// </summary>
        AM,

        /// <summary>
        /// Noon.
        /// </summary>
        Noon,

        /// <summary>
        /// Afternoon or evening.
        /// </summary>
        PM
    }

    /// <summary>
    /// Methods to operate on the <see cref="HalfOfDay"/> enumeration.
    /// </summary>
    public static class HalfOfDayExtensions
    {
        /// <summary>
        /// Converts a <see cref="HalfOfDay"/> value to a translatable string.
        /// </summary>
        /// <param name="halfOfDay">The value to be converted.</param>
        /// <returns>A translatable string describing the value.</returns>
        public static string ToNameString(this HalfOfDay halfOfDay)
        {
            switch (halfOfDay)
            {
                case HalfOfDay.AM:
                default:
                    return Resources.HalfOfDay_ToNameString_Am;
                case HalfOfDay.PM:
                    return Resources.HalfOfDay_ToNameString_Pm;
                case HalfOfDay.Noon:
                    return Resources.HalfOfDay_ToNameString_Noon;
            }
        }

        /// <summary>
        /// Converts a <see cref="Nullable{HalfOfDay}" /> value to a translatable string.
        /// </summary>
        /// <param name="halfOfDay">The value to be converted.</param>
        /// <returns>A translatable string describing the value.</returns>
        public static string ToNameString(this HalfOfDay? halfOfDay) => halfOfDay is null ? "" : halfOfDay.Value.ToNameString();
    }
}
