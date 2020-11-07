using System;
using Timetabler.CoreData;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data
{
    /// <summary>
    /// A class which describes a named and measured location on a railway line.
    /// </summary>
    public class Location : ICloneable, IUniqueItem, IEquatable<Location>, IEquatable<Distance>, IComparable, IComparable<Location>, IComparable<Distance>, IWatchableItem
    {
        /// <summary>
        /// A string that uniquely identifies this location.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of this location, as formatted for display in the application GUI.
        /// </summary>
        public string EditorDisplayName { get; set; }

        /// <summary>
        /// The name of this location, as formatted for display on timetables formatted for printed output.
        /// </summary>
        public string TimetableDisplayName { get; set; }

        /// <summary>
        /// The name of this location, as formatted for display on train graphs.
        /// </summary>
        public string GraphDisplayName { get; set; }

        /// <summary>
        /// An abbreviated code to describe this location.
        /// </summary>
        public string Tiploc { get; set; }

        /// <summary>
        /// Whether or not this location should always have arrival and/or departure rows displayed on Up pages of the timetable.
        /// </summary>
        public ArrivalDepartureOptions UpArrivalDepartureAlwaysDisplayed { get; set; }

        /// <summary>
        /// Whether or not this location should always have platform, path or line rows displayed on Up pages of the timetable.
        /// </summary>
        public TrainRoutingOptions UpRoutingCodesAlwaysDisplayed { get; set; }

        /// <summary>
        /// Whether or not this location should always have arrival and/or departure rows displayed on Down pages of the timetable.
        /// </summary>
        public ArrivalDepartureOptions DownArrivalDepartureAlwaysDisplayed { get; set; }
    
        /// <summary>
        /// Whether or not this location should always have platform, path or line rows displayed on Down pages of the timetable.
        /// </summary>
        public TrainRoutingOptions DownRoutingCodesAlwaysDisplayed { get; set; }

        /// <summary>
        /// The mileage value of this location.
        /// </summary>
        public Distance Mileage { get; set; }

        /// <summary>
        /// The font type to use when displaying this location's name on export.
        /// </summary>
        public LocationFontType FontType { get; set; }

        /// <summary>
        /// Whether or not a separator line should be drawn above this location.
        /// </summary>
        public bool DisplaySeparatorAbove { get; set; }

        /// <summary>
        /// Whether or not a separator line should be drawn below this location.
        /// </summary>
        public bool DisplaySeparatorBelow { get; set; }

        /// <summary>
        /// Default constructor, which defaults to locations having both arrival and departure rows on the timetable.
        /// </summary>
        public Location()
        {
            Mileage = new Distance();
            UpArrivalDepartureAlwaysDisplayed = DownArrivalDepartureAlwaysDisplayed = ArrivalDepartureOptions.Arrival | ArrivalDepartureOptions.Departure;
            FontType = LocationFontType.Normal;
        }

        /// <summary>
        /// Event raised when this object's properties are modified.  FIXME to be implemented.
        /// </summary>
        public event ModifiedEventHandler Modified;

        /// <summary>
        /// Raises the <see cref="Modified" /> event.
        /// </summary>
        /// <param name="sender">The object which has modified the instance.</param>
        /// <param name="field">The name of the modified property, if only one property has been modified.</param>
        protected void OnModified(object sender, string field)
        {
            Modified?.Invoke(sender, new ModifiedEventArgs(this, field));
        }

        /// <summary>
        /// Make a deep copy of this instance.
        /// </summary>
        /// <returns>A second <see cref="Location"/> instance which is a deep copy of this one.</returns>
        public object Clone()
        {
            Location loc = new Location
            {
                Id = Id,
                EditorDisplayName = EditorDisplayName,
                TimetableDisplayName = TimetableDisplayName,
                GraphDisplayName = GraphDisplayName,
                Tiploc = Tiploc,
                UpArrivalDepartureAlwaysDisplayed = UpArrivalDepartureAlwaysDisplayed,
                DownArrivalDepartureAlwaysDisplayed = DownArrivalDepartureAlwaysDisplayed,
                UpRoutingCodesAlwaysDisplayed = UpRoutingCodesAlwaysDisplayed,
                DownRoutingCodesAlwaysDisplayed = DownRoutingCodesAlwaysDisplayed,
                FontType = FontType,
                DisplaySeparatorAbove = DisplaySeparatorAbove,
                DisplaySeparatorBelow = DisplaySeparatorBelow,
                Mileage = Mileage,
            };
            return loc;
        }

        /// <summary>
        /// Overridden implementation which returns the <see cref="EditorDisplayName"/> property.
        /// </summary>
        /// <returns>The <see cref="EditorDisplayName"/> property.</returns>
        public override string ToString()
        {
            return EditorDisplayName;
        }

        /// <summary>
        /// Compare for equality with another <see cref="Location"/> instance.  Equality is based solely on the <see cref="Mileage"/> property of the objects.
        /// </summary>
        /// <param name="other">A second Location instance to compare.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public bool Equals(Location other)
        {
            if (other is null)
            {
                return false;
            }
            if (other.Mileage == null)
            {
                return Mileage == null;
            }
            return other.Mileage == Mileage;
        }

        /// <summary>
        /// Compare for equality with a <see cref="Distance"/> value.  Compares the <see cref="Mileage"/> property of this instance against the parameter.
        /// </summary>
        /// <param name="other">A <see cref="Distance"/> value.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public bool Equals(Distance other)
        {
            return Mileage == other;
        }

        /// <summary>
        /// Compare for equality with another object.  Throws an exception if the parameter is not a <see cref="Location"/> or <see cref="Distance"/> object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean value indicating equality.</returns>
        public override bool Equals(object obj)
        {
            var loc = obj as Location;
            if (loc != null)
            {
                return Equals(loc);
            }
            if (obj is Distance d)
            {
                return Equals(d);
            }
            return base.Equals(obj);
        }

        /// <summary>
        /// Return a hashed value of this object.
        /// </summary>
        /// <returns>An integer hash value.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares the value of the <see cref="Mileage"/> property with a <see cref="Distance"/> parameter.
        /// </summary>
        /// <param name="other">A <see cref="Distance"/> parameter to compare.</param>
        /// <returns>An integer indicating whether the <see cref="Mileage"/> property is less than, equal to or greater than the parameter.</returns>
        public int CompareTo(Distance other)
        {
            return Mileage.CompareTo(other);
        }

        /// <summary>
        /// Compared the value of the <see cref="Mileage"/> property with that of another <see cref="Location"/> instance.
        /// </summary>
        /// <param name="other">A <see cref="Location"/> object to compare.</param>
        /// <returns>An integer indicating whether the <see cref="Mileage"/> property of this object is less than, equal to or greater than that of the parameter.</returns>
        public int CompareTo(Location other)
        {
            if (other is null || other.Mileage == null)
            {
                return Mileage == null ? 0 : 1;
            }
            if (Mileage == null)
            {
                return -1;
            }
            return Mileage.CompareTo(other.Mileage);
        }

        /// <summary>
        /// Compare the <see cref="Mileage"/> property of this object against another object.  Throws an exception if the other object is not a <see cref="Location"/> 
        /// instance or <see cref="Distance"/> value.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>An integer indicating whether this object is less than, equal to or greater than the other object.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var l = obj as Location;
            if (l != null)
            {
                return CompareTo(l);
            }
            if (obj is Distance d)
            {
                return CompareTo(d);
            }

            throw new ArgumentException(Resources.Error_WrongDataType, nameof(obj));
        }

        /// <summary>
        /// Returns true if the <see cref="Mileage"/> property of l1 is less than that of l2, false otherwise.
        /// </summary>
        /// <param name="l1">A <see cref="Location"/> object.</param>
        /// <param name="l2">A <see cref="Location"/> object.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator <(Location l1, Location l2)
        {
            if (l1 is null)
            {
                return !(l2 is null);
            }
            if (l2 is null)
            {
                return false;
            }

            return l1.Mileage < l2.Mileage;
        }

        /// <summary>
        /// Returns true if the <see cref="Mileage"/> property of l1 is less than or equal to l2, false otherwise.
        /// </summary>
        /// <param name="l1">A <see cref="Location"/> object.</param>
        /// <param name="l2">A <see cref="Location"/> object.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator <=(Location l1, Location l2)
        {
            if (l1 is null)
            {
                return true;
            }
            if (l2 is null)
            {
                return false;
            }

            return l1.Mileage <= l2.Mileage;
        }

        /// <summary>
        /// Returns true if the <see cref="Mileage"/> property of l1 is greater than that of l2, false otherwise.
        /// </summary>
        /// <param name="l1">A <see cref="Location"/> object.</param>
        /// <param name="l2">A <see cref="Location"/> object.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator >(Location l1, Location l2)
        {
            if (l1 is null)
            {
                return false;
            }
            if (l2 is null)
            {
                return true;
            }

            return l1.Mileage > l2.Mileage;
        }

        /// <summary>
        /// Returns true if the <see cref="Mileage"/> property of l1 is greater than or equal to that of l2, false otherwise.
        /// </summary>
        /// <param name="l1">A <see cref="Location"/> object.</param>
        /// <param name="l2">A <see cref="Location"/> object.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator >=(Location l1, Location l2)
        {
            if (l1 is null)
            {
                return l2 is null;
            }
            if (l2 is null)
            {
                return false;
            }

            return l1.Mileage >= l2.Mileage;
        }

        /// <summary>
        /// Returns true if the <see cref="Mileage"/> properties of l1 and l2 are equal, false otherwise.
        /// </summary>
        /// <param name="l1">A <see cref="Location"/> object.</param>
        /// <param name="l2">A <see cref="Location"/> object.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator ==(Location l1, Location l2)
        {
            if (l1 is null)
            {
                return l2 is null;
            }
            if (l2 is null)
            {
                return false;
            }

            return l1.Mileage == l2.Mileage;
        }

        /// <summary>
        /// Returns true if the <see cref="Mileage"/> properties of l1 and l2 are not equal, false otherwise.
        /// </summary>
        /// <param name="l1">A <see cref="Location"/> object.</param>
        /// <param name="l2">A <see cref="Location"/> object.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator !=(Location l1, Location l2)
        {
            if (l1 is null)
            {
                return !(l2 is null);
            }
            if (l2 is null)
            {
                return true;
            }

            return l1.Mileage != l2.Mileage;
        }
    }
}
