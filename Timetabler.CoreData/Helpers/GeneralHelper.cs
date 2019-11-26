using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.CoreData.Helpers
{
    /// <summary>
    /// Collection of general helper methods that are static and not bound to specific classes.
    /// </summary>
    public static class GeneralHelper
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Given an enumeration of existing items, return a random string which is not used as the Id property of any existing items in the enumeration.
        /// </summary>
        /// <typeparam name="T">The <see cref="IUniqueItem"/> implementation to provide an ID string for.</typeparam>
        /// <param name="existingItems">The existing items whose IDs must not be duplicated.</param>
        /// <returns>A string suitable for use as an ID string for an instance of T.</returns>
        public static string GetNewId<T>(IEnumerable<T> existingItems) where T : IUniqueItem
        {
            if (existingItems is null)
            {
                throw new ArgumentNullException(nameof(existingItems));
            }
            Dictionary<string, T> map = existingItems.ToDictionary(i => i.Id);
            string id;
            do
            {
                id = _random.Next().ToString("x8", CultureInfo.InvariantCulture);
            } while (map != null && map.ContainsKey(id));

            return id;
        }
    }
}
