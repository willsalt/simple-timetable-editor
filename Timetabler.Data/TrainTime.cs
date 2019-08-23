using System;
using System.Collections.Generic;
using System.Linq;

namespace Timetabler.Data
{
    /// <summary>
    /// Represents a time in a timetable, plus any footnotes associated with it.
    /// </summary>
    public class TrainTime
    {
        /// <summary>
        /// The time.
        /// </summary>
        public TimeOfDay Time { get; set; }

        /// <summary>
        /// The footnotes that apply to this timing point.
        /// </summary>
        public List<Note> Footnotes { get; set; }

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
    }
}
