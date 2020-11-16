using System;
using Timetabler.CoreData;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// This model represents location-specific data to be displayed in a timetable row.
    /// </summary>
    public class LocationDisplayModel : IWatchableItem
    {
        /// <summary>
        /// The unique ID of this row, consisting of the location ID plus a row type suffix.
        /// </summary>
        public string LocationKey { get; set; }

        /// <summary>
        /// The ID of the location that this row relates to.
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// The display name of the location.
        /// </summary>
        public string EditorDisplayName { get; set; }

        /// <summary>
        /// The display name of the location, formatted for export.
        /// </summary>
        public string ExportDisplayName { get; set; }

        /// <summary>
        /// The label to be entered in the column which specifies what type of information this row contains, such as "a", "d" or an empty string.
        /// </summary>
        public string ArrivalDepartureLabel { get; set; }

        /// <summary>
        /// This location row is present because it is always displayed.
        /// </summary>
        public bool AlwaysDisplay { get; set; }

        /// <summary>
        /// Whether to display this location's name with the normal font or the alternative font on export.
        /// </summary>
        public LocationFontType FontType { get; set; }

        /// <summary>
        /// The position of this location, so that it can be sorted against other <see cref="LocationDisplayModel"/> instances.
        /// </summary>
        public Distance Mileage { get; set; }

        /// <summary>
        /// Whether or not this location is a routing code row (these are displayed differently on export, without filler dots).
        /// </summary>
        public bool IsRoutingCodeRow { get; set; }

        /// <summary>
        /// Whether or not to display a separator line above this entry.
        /// </summary>
        public bool DisplaySeparatorAbove { get; set; }

        /// <summary>
        /// Whether or not to display a separator line below this entry.
        /// </summary>
        public bool DisplaySeparatorBelow { get; set; }

        /// <summary>
        /// Whether or not displaying a separator line above this location is set at location level.
        /// </summary>
        public bool ParentDisplaySeparatorAbove { get; set; }

        /// <summary>
        /// Whether or not displaying a separator line below this location is set at location level.
        /// </summary>
        public bool ParentDisplaySeparatorBelow { get; set; }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public event EventHandler<ModifiedEventArgs> Modified;

        /// <summary>
        /// Raises the <see cref="Modified" /> event.
        /// </summary>
        /// <param name="sender">The object which has modified the instance.</param>
        /// <param name="field">The name of the modified property, if only one property has been modified.</param>
        protected void OnModified(object sender, string field)
        {
            Modified?.Invoke(sender, new ModifiedEventArgs(this, field));
        }
    }
}
