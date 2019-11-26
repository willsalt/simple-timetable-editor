using System;

namespace Timetabler.CoreData.Helpers
{
    /// <summary>
    /// Helper and/or extension methods relating to strings.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// If the input string ends in any of the <see cref="LocationIdSuffixes"/> constants, return the input with that suffix removed.
        /// </summary>
        /// <param name="key">The string to test.</param>
        /// <returns>The parameter with any valid suffix removed.</returns>
        public static string StripArrivalDepartureSuffix(this string key)
        {
            if (key is null)
            {
                return null;
            }
            if (key.EndsWith(LocationIdSuffixes.Arrival, StringComparison.InvariantCulture))
            {
                return key.Remove(key.Length - LocationIdSuffixes.Arrival.Length);
            }
            if (key.EndsWith(LocationIdSuffixes.Departure, StringComparison.InvariantCulture))
            {
                return key.Remove(key.Length - LocationIdSuffixes.Departure.Length);
            }
            if (key.EndsWith(LocationIdSuffixes.Path, StringComparison.InvariantCulture))
            {
                return key.Remove(key.Length - LocationIdSuffixes.Path.Length);
            }
            if (key.EndsWith(LocationIdSuffixes.Platform, StringComparison.InvariantCulture))
            {
                return key.Remove(key.Length - LocationIdSuffixes.Platform.Length);
            }
            if (key.EndsWith(LocationIdSuffixes.Line, StringComparison.InvariantCulture))
            {
                return key.Remove(key.Length - LocationIdSuffixes.Line.Length);
            }
            return key;
        }
    }
}
