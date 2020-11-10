using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData.Extensions;
using Timetabler.CoreData.Helpers;

namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// An abstract parent class for model classes with an <c>Id</c> property containing a string which can be used to uniquely identify an instance of the class.
    /// </summary>
    public abstract class UniqueItemModel
    {
        /// <summary>
        /// A unique string ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// In a set of instances of this type, populate the <see cref="Id" /> property of any instances for which that property is <c>null</c>, or an empty or
        /// whitespace-only string.
        /// </summary>
        /// <param name="collection">The set of instances to check for missing <see cref="Id" /> values.</param>
        public static void PopulateMissingIds(IEnumerable<UniqueItemModel> collection)
        {
            if (collection is null)
            {
                return;
            }
            UniqueItemModel[] allItems = collection.ToArray();
            UniqueItemModel[] missingIds = allItems.Where(l => string.IsNullOrWhiteSpace(l.Id)).ToArray();
            if (missingIds.Length == 0)
            {
                return;
            }
            GeneralHelper.GetNewId(allItems.Select(i => i.Id), missingIds.Length).ForEach((s, i) => missingIds[i].Id = s);
        }
    }
}
