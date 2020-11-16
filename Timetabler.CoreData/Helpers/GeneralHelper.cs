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

#pragma warning disable CA5394 // Do not use insecure randomness

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
            Dictionary<string, T> map = existingItems.Where(i => i.Id != null).ToDictionary(i => i.Id);
            string id;
            do
            {
                id = _random.Next().ToString("x8", CultureInfo.InvariantCulture);
            } while (map != null && map.ContainsKey(id));

            return id;
        }

        /// <summary>
        /// Given an enumeration of existing IDs, return an enumeration of random IDs taht are not duplicated and are not in the set of existing IDs.
        /// </summary>
        /// <param name="existingItems">The set of existing IDs.</param>
        /// <param name="count">The number of new IDs to return.</param>
        /// <returns>An enumeration of strings suitable for use as an ID string and that do not duplicate any in the existing set or in the output set.</returns>
        public static IEnumerable<string> GetNewId(IEnumerable<string> existingItems, int count)
        {
            if (count == 0)
            {
                yield break;
            }
            Dictionary<string, string> map;
            if (existingItems != null)
            {
                map = existingItems.Where(i => !string.IsNullOrWhiteSpace(i)).ToDictionary(i => i);
            }
            else
            {
                map = new Dictionary<string, string>();
            }
            for (int i = 0; i < count; ++i)
            {
                string id;
                do
                {
                    id = _random.Next().ToString("x8", CultureInfo.InvariantCulture);
                } while (map != null && map.ContainsKey(id));
                map.Add(id, id);
                yield return id;
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
