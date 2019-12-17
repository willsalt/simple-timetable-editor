using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData;

namespace Timetabler.Data
{
    /// <summary>
    /// Represents a time in a timetable, plus any footnotes associated with it.
    /// </summary>
    public class TrainTime : IComparable, IComparable<TrainTime>, IComparable<TimeOfDay>
    {
        /// <summary>
        /// The time.
        /// </summary>
        public TimeOfDay Time { get; set; }

        /// <summary>
        /// The footnotes that apply to this timing point.
        /// </summary>
        public List<Note> Footnotes { get; private set; }

        /// <summary>
        /// The symbols of all the footnotes that apply to this timing point, concatenated into a single string, or a space if this timing point has no footnotes.
        /// </summary>
        public string FootnoteSymbols
        {
            get
            {
                return (Footnotes != null && Footnotes.Any()) ? string.Join(string.Empty, Footnotes.Select(n => n?.Symbol ?? "")) : "  ";
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainTime()
        {
            Footnotes = new List<Note>();
        }

        /// <summary>
        /// Attempt to populate the <see cref="Footnotes"/> property, 
        /// </summary>
        /// <param name="allFootnotes"></param>
        public void ResolveFootnotes(IDictionary<string, Note> allFootnotes)
        {
            if (allFootnotes is null)
            {
                throw new ArgumentNullException(nameof(allFootnotes));
            }
            List<string> currentIds = Footnotes.Select(n => n.Id).ToList();
            for (int i = 0; i < currentIds.Count; ++i)
            {
                if (allFootnotes.ContainsKey(currentIds[i]))
                {
                    Footnotes[i] = allFootnotes[currentIds[i]];
                }
            }
        }

        /// <summary>
        /// Create a copy of this instance.
        /// </summary>
        /// <returns></returns>
        public TrainTime Copy()
        {
            return CopyWithTime(Time?.Copy());
        }

        internal TrainTime CopyAndReflect(TimeOfDay aroundTime)
        {
            return CopyWithTime(Time?.CopyAndReflect(aroundTime));
        }

        private TrainTime CopyWithTime(TimeOfDay newTime)
        {
            return new TrainTime
            {
                Time = newTime,
                Footnotes = Footnotes.ToList(),
            };
        }

        /// <summary>
        /// Compare this object to a <see cref="TimeOfDay" /> instance.
        /// </summary>
        /// <param name="other">The instance to compare against.</param>
        /// <returns>-1, 0 or 1 according to whether the other object's value is less than, equal to or greater than this instance.</returns>
        public int CompareTo(TimeOfDay other)
        {
            return Time.CompareTo(other);
        }

        /// <summary>
        /// Compare this object to another <see cref="TrainTime" /> instance.
        /// </summary>
        /// <param name="other">The instance to compare against.</param>
        /// <returns>-1, 0 or 1 according to whether the other object's value is less than, equal to or greater than this instance.</returns>
        public int CompareTo(TrainTime other)
        {
            return Time.CompareTo(other?.Time);
        }

        /// <summary>
        /// Compare this object to another.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>-1, 0 or 1 according to whether the other object's value is less than, equal to or greater than this instance.</returns>
        /// <exception cref="ArgumentException">Thrown if the <c>obj</c> param is not of a type that this object can be compared to.</exception>
        public int CompareTo(object obj)
        {
            if (obj is TrainTime ttObj)
            {
                return CompareTo(ttObj);
            }
            if (obj is TimeOfDay todObj)
            {
                return CompareTo(todObj);
            }
            throw new ArgumentException(Resources.Error_WrongDataType, nameof(obj));
        }

        /// <summary>
        /// Returns true if t1 is after t2, otherwise false.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance.</param>
        /// <returns>True or false.</returns>
        public static bool operator >(TrainTime t1, TrainTime t2)
        {
            return t1?.Time > t2?.Time;
        }

        /// <summary>
        /// Returns true if instance t1 is before t2, false otherwise.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance.</param>
        /// <returns>True or false according to whether t1 is before or after t2.</returns>
        public static bool operator <(TrainTime t1, TrainTime t2)
        {
            return t1?.Time < t2?.Time;
        }

        /// <summary>
        /// Returns false if t1 is before t2, otherwise true.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance.</param>
        /// <returns>True or false.</returns>
        public static bool operator >=(TrainTime t1, TrainTime t2)
        {
            return t1?.Time >= t2?.Time;
        }

        /// <summary>
        /// Returns false if t2 is after t1, otherwise true.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance.</param>
        /// <returns>True or false.</returns>
        public static bool operator <=(TrainTime t1, TrainTime t2)
        {
            return t1?.Time <= t2?.Time;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="t1">First operand.</param>
        /// <param name="t2">Second operand.</param>
        /// <returns>True if the operands have the same times and footnote symbols, false otherwise.</returns>
        public static bool operator ==(TrainTime t1, TrainTime t2)
        {
            if (t1 is null)
            {
                return t2 is null;
            }
            if (t2 is null)
            {
                return false;
            }
            if (t1.Time != t2.Time)
            {
                return false;
            }
            return t1.FootnoteSymbols == t2.FootnoteSymbols;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="t1">First operand.</param>
        /// <param name="t2">Second operand.</param>
        /// <returns>False if the operands have the same times and footnote symbols, false otherwise.</returns>
        public static bool operator !=(TrainTime t1, TrainTime t2)
        {
            if (t1 is null)
            {
                return !(t2 is null);
            }
            if (t2 is null)
            {
                return true;
            }
            if (t1.Time != t2.Time)
            {
                return true;
            }
            return t1.FootnoteSymbols != t2.FootnoteSymbols;
        }

        /// <summary>
        /// Equality test.
        /// </summary>
        /// <param name="obj">The object to test for equality.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (!(obj is TrainTime ttObj))
            {
                return false;
            }
            
            return this == ttObj;
        }

        /// <summary>
        /// Generate a hashcode for this object.
        /// </summary>
        /// <returns>A hashcode generated based on the content of this object.</returns>
        public override int GetHashCode()
        {
            return (Time?.GetHashCode() ?? 0) ^ FootnoteSymbols.GetHashCode(); 
        }
    }
}
