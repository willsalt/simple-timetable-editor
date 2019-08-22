using System;
using System.Globalization;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data
{
    /// <summary>
    /// A reference type which represents a clock time, to the nearest second.
    /// </summary>
    public class TimeOfDay : IEquatable<TimeOfDay>, IComparable, IComparable<TimeOfDay>, IFormattable, ICopyableItem<TimeOfDay>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TimeOfDay()
        {

        }

        /// <summary>
        /// Construct from components to the nearest second.
        /// </summary>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        public TimeOfDay(int hours, int minutes, int seconds)
        {
            AbsoluteSeconds = (hours * 3600 + minutes * 60 + seconds) % 86400;
        }

        /// <summary>
        /// Construct from components to the nearest minute.
        /// </summary>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        public TimeOfDay(int hours, int minutes)
        {
            AbsoluteSeconds = (hours * 3600 + minutes * 60) % 86400;
        }

        /// <summary>
        /// Construct from components to the nearest second, using the twelve-hour clock.
        /// </summary>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="seconds">Number of seconds.</param>
        /// <param name="half">AM or PM.</param>
        public TimeOfDay(int hours, int minutes, int seconds, HalfOfDay half)
        {
            AbsoluteSeconds = (hours * 3600 + minutes * 60 + seconds + half == HalfOfDay.PM ? 43200 : 0) % 86400;
        }

        public TimeOfDay CopyAndReflect(TimeOfDay aroundTime)
        {
            int newSeconds = AbsoluteSeconds - ((AbsoluteSeconds - aroundTime.AbsoluteSeconds) * 2);
            return new TimeOfDay(newSeconds);
        }

        /// <summary>
        /// Construct from components to the nearest minute, using the twelve-hour clock.
        /// </summary>
        /// <param name="hours">Number of hours.</param>
        /// <param name="minutes">Number of minutes.</param>
        /// <param name="half">AM or PM.</param>
        public TimeOfDay(int hours, int minutes, HalfOfDay half)
        {
            AbsoluteSeconds = (hours * 3600 + minutes * 60 + half == HalfOfDay.PM ? 43200 : 0) % 86400;
        }

        /// <summary>
        /// Construct from the number of seconds since midnight.
        /// </summary>
        /// <param name="seconds">Number of seconds since midnight.</param>
        public TimeOfDay(int seconds)
        {
            AbsoluteSeconds = seconds;
        }

        /// <summary>
        /// Construct from the number of seconds since midnight, rounding to the nearest whole second.
        /// </summary>
        /// <param name="seconds">Number of seconds since midnight.</param>
        public TimeOfDay(double seconds)
        {
            AbsoluteSeconds = (int)Math.Round(seconds);
        }

        /// <summary>
        /// The number of seconds since midnight.  This property is not serialised, but is the primary property when the object is in memory.  Other properties are derived from this one.
        /// </summary>
        public int AbsoluteSeconds { get; set; }

        /// <summary>
        /// The number of hours in the time, using the 24-hour clock.
        /// </summary>
        public int Hours24
        {
            get
            {
                return AbsoluteSeconds / 3600;
            }
            set
            {
                AbsoluteSeconds = (value * 3600 + Minutes * 60 + Seconds) % 86400;
            }
        }

        /// <summary>
        /// The number of hours in the time, using the 12-hour clock.
        /// </summary>
        public int Hours12
        {
            get
            {
                int val = (AbsoluteSeconds / 3600) % 12;
                return val == 0 ? 12 : val;
            }
            set
            {
                if (HalfOfDay == HalfOfDay.AM)
                {
                    AbsoluteSeconds = (value * 3600 + Minutes * 60 + Seconds) % 86400;
                }
                else
                {
                    AbsoluteSeconds = (value * 3600 + Minutes * 60 + Seconds + 43200) % 86400;
                }
            }
        }

        /// <summary>
        /// The number of minutes in the time.
        /// </summary>
        public int Minutes
        {
            get
            {
                return (AbsoluteSeconds % 3600) / 60;
            }
            set
            {
                AbsoluteSeconds = (Hours24 * 3600 + value * 60 + Seconds) % 86400;
            }
        }

        /// <summary>
        /// The number of seconds in the time.
        /// </summary>
        public int Seconds
        {
            get
            {
                return AbsoluteSeconds % 60;
            }
            set
            {
                AbsoluteSeconds = (Hours24 * 3600 + Minutes * 60 + value) % 86400;
            }
        }

        /// <summary>
        /// Whether this time is AM or PM (or noon).
        /// </summary>
        public HalfOfDay HalfOfDay
        {
            get
            {
                if (AbsoluteSeconds == 43200)
                {
                    return HalfOfDay.Noon;
                }
                if (AbsoluteSeconds > 43200)
                {
                    return HalfOfDay.PM;
                }
                return HalfOfDay.AM;
            }
            set
            {
                if (value == HalfOfDay.Noon)
                {
                    AbsoluteSeconds = 43200;
                }
                else if (value == HalfOfDay.AM && AbsoluteSeconds >= 43200)
                {
                    AbsoluteSeconds -= 43200;
                }
                else if (value == HalfOfDay.PM && AbsoluteSeconds < 43200)
                {
                    AbsoluteSeconds += 43200;
                }
            }
        }

        /// <summary>
        /// Create a <see cref="TimeOfDay" /> object based on a <see cref="TimeSpan" /> value, taking the latter as the time elapsed since midnight and assuming that the day is a normal 24-hour day
        /// </summary>
        /// <param name="ts">The amount of time elapsed since midnight.</param>
        /// <returns>A <see cref="TimeOfDay" /> instance.</returns>
        public static TimeOfDay FromTimeSpan(TimeSpan ts)
        {
            return new TimeOfDay(ts.TotalSeconds);
        }

        /// <summary>
        /// Is this time of day equal in value to another instance?
        /// </summary>
        /// <param name="other">Another <see cref="TimeOfDay"/> instance.</param>
        /// <returns>true if the instances are equal in value, false otherwise.</returns>
        public bool Equals(TimeOfDay other)
        {
            return this == other;
        }

        /// <summary>
        /// Is this time of day equal in value to another instance?
        /// </summary>
        /// <param name="obj">An <see cref="object"/></param>
        /// <returns>true if the other instance is a <see cref="TimeOfDay"/> equal in value to this one, false if the other instance is not equal in value or is a different type.</returns>
        public override bool Equals(object obj)
        {
            var t = obj as TimeOfDay;
            if (t != null)
            {
                return this == t;
            }
            return false;
        }

        /// <summary>
        /// Returns an int hashcode.
        /// </summary>
        /// <returns>An int derived from the value of the object.</returns>
        public override int GetHashCode()
        {
            return AbsoluteSeconds;
        }

        /// <summary>
        /// Compare this instance to another object.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <exception cref="ArgumentException">Thrown if the obj parameter is not a <see cref="TimeOfDay"/> instance.</exception>
        /// <returns>-1, 0 or 1 according to whether the other object's value is less than, equal to or greater than this instance.</returns>
        public int CompareTo(object obj)
        {
            var t = obj as TimeOfDay;
            if (t == null)
            {
                throw new ArgumentException("Wrong data type passed.", "obj");
            }
            return CompareTo(t);
        }

        /// <summary>
        /// Compare this instance to another object of the same type.
        /// </summary>
        /// <param name="other">The object to compare to.</param>
        /// <returns>-1, 0 or 1 according to whether the other instance's value is less than, equal to or greater than this instance.</returns>
        public int CompareTo(TimeOfDay other)
        {
            if (ReferenceEquals(other, null))
            {
                return -1;
            }
            if (this < other)
            {
                return -1;
            }
            if (this > other)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Convert to a string.
        /// </summary>
        /// <remarks>
        /// <para>If the format parameter consists of the single character "G" or "g", the string will consist of the value of the <see cref="AbsoluteSeconds"/> property.</para>
        /// <para>Otherwise, the following character sequences in the format parameter will be replaced as follows:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Format character</term>
        /// <description>Replacement</description>
        /// </listheader>
        /// <item><term>f</term><description>If the seconds component of the time is 30 or greater, a half symbol; otherwise an empty string.</description></item>
        /// <item><term>h</term><description>Hours from 1-12, leading zeros omitted.</description></item>
        /// <item><term>hh</term><description>Hours from 01-12, leading zero preserved.</description></item>
        /// <item><term>H</term><description>Hours from 0-23, leading zeros omitted.</description></item>
        /// <item><term>HH</term><description>Hours from 00-23, leading zero preserved.</description></item>
        /// <item><term>m</term><descrption>Minutes from 0-59, leading zero omitted.</descrption></item>
        /// <item><term>mm</term><description>Minutes from 00-59, leading zero preserved.</description></item>
        /// <item><term>s</term><description>Seconds from 0-59, leading zero omitted.</description></item>
        /// <item><term>ss</term><description>Seconds from 00-59, leading zero preserved.</description></item>
        /// <item><term>t</term><description>The first letter of the AM/PM designator for the relevant culture.</description></item>
        /// <item><term>tt</term><description>The AM/PM designator for the relevant culture.</description></item>
        /// </list>
        /// </remarks>
        /// <param name="format">Format string</param>
        /// <param name="formatProvider">Culture-specific information.</param>
        /// <returns>A string containing the value of the object formatted as per the format string and culture.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "g" || format == "G")
            {
                return AbsoluteSeconds.ToString(formatProvider);
            }

            format = format.Replace("hh", Hours12.ToString("d2", formatProvider));
            format = format.Replace("h", Hours12.ToString(formatProvider));
            format = format.Replace("HH", Hours24.ToString("d2", formatProvider));
            format = format.Replace("H", Hours24.ToString(formatProvider));
            format = format.Replace("mm", Minutes.ToString("d2", formatProvider));
            format = format.Replace("m", Minutes.ToString(formatProvider));
            format = format.Replace("ss", Seconds.ToString("d2", formatProvider));
            format = format.Replace("s", Seconds.ToString(formatProvider));
            format = format.Replace("f", Seconds >= 30 ? "½" : string.Empty);
            if (format.Contains("t"))
            {
                string desig = GetDesignator(formatProvider, false);
                format = format.Replace("tt", desig);
                if (!desig.Contains("t"))
                {
                    format = format.Replace("t", desig.Substring(0, 1));
                }
            }
            if (format.Contains("T"))
            {
                string desig = GetDesignator(formatProvider, true);
                format = format.Replace("TT", desig);
                if (!desig.Contains("T"))
                {
                    format = format.Replace("T", desig.Substring(0, 1));
                }
            }

            return format;
        }

        private string GetDesignator(IFormatProvider formatProvider, bool upperCase)
        {
            var info = formatProvider.GetFormat(typeof(DateTimeFormatInfo)) as DateTimeFormatInfo;
            string desig;
            if (AbsoluteSeconds >= 43200)
            {
                desig = info.PMDesignator;
            }
            else
            {
                desig = info.AMDesignator;
            }
            return upperCase ? desig.ToUpper() : desig.ToLower();
        }

        /// <summary>
        /// Convert to a string.
        /// </summary>
        /// <remarks>
        /// <para>If the format parameter consists of the single character "G" or "g", the string will consist of the value of the <see cref="AbsoluteSeconds"/> property.</para>
        /// <para>Otherwise, the following character sequences in the format parameter will be replaced as follows:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Format character</term>
        /// <description>Replacement</description>
        /// </listheader>
        /// <item><term>f</term><description>If the seconds component of the time is 30 or greater, a half symbol; otherwise an empty string.</description></item>
        /// <item><term>h</term><description>Hours from 1-12, leading zeros omitted.</description></item>
        /// <item><term>hh</term><description>Hours from 01-12, leading zero preserved.</description></item>
        /// <item><term>H</term><description>Hours from 0-23, leading zeros omitted.</description></item>
        /// <item><term>HH</term><description>Hours from 00-23, leading zero preserved.</description></item>
        /// <item><term>m</term><descrption>Minutes from 0-59, leading zero omitted.</descrption></item>
        /// <item><term>mm</term><description>Minutes from 00-59, leading zero preserved.</description></item>
        /// <item><term>s</term><description>Seconds from 0-59, leading zero omitted.</description></item>
        /// <item><term>ss</term><description>Seconds from 00-59, leading zero preserved.</description></item>
        /// <item><term>t</term><description>The first letter of the AM/PM designator for the current culture.</description></item>
        /// <item><term>tt</term><description>The AM/PM designator for the current culture.</description></item>
        /// </list>
        /// </remarks>
        /// <param name="format">Format string</param>
        /// <returns>A string containing the value of the object formatted as per the format string and current culture.</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Convert to string.  Equivalent to calling ToString(string format) with "HH:mmf" as the format string.
        /// </summary>
        /// <returns>The instance's data converted to a string using the default format and current culture.</returns>
        public override string ToString()
        {
            return ToString("HH:mmf");
        }

        /// <summary>
        /// Returns true if the two objects are equal, false otherwise.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance to check for equality.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance to check for equality.</param>
        /// <returns>True or false.</returns>
        public static bool operator ==(TimeOfDay t1, TimeOfDay t2)
        {
            if (ReferenceEquals(t1, null))
            {
                return ReferenceEquals(t2, null);
            }
            if (ReferenceEquals(t2, null))
            {
                return false;
            }
            return t1.AbsoluteSeconds == t2.AbsoluteSeconds;
        }

        /// <summary>
        /// Returns true if the instances are not equal, false otherwise.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance to check for equality.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance to check for equality.</param>
        /// <returns>True or false</returns>
        public static bool operator !=(TimeOfDay t1, TimeOfDay t2)
        {
            if (ReferenceEquals(t1, null))
            {
                return !ReferenceEquals(t2, null);
            }
            if (ReferenceEquals(t2, null))
            {
                return true;
            }
            return t1.AbsoluteSeconds != t2.AbsoluteSeconds;
        }

        /// <summary>
        /// Returns true if instance t1 is before t2, false otherwise.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance.</param>
        /// <returns>True or false according to whether t1 is before or after t2.</returns>
        public static bool operator <(TimeOfDay t1, TimeOfDay t2)
        {
            if (ReferenceEquals(t1, null))
            {
                return !(ReferenceEquals(t2, null));
            }
            if (ReferenceEquals(t2, null))
            {
                return false;
            }
            return t1.AbsoluteSeconds < t2.AbsoluteSeconds;
        }

        /// <summary>
        /// Returns false if t2 is after t1, otherwise true.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance.</param>
        /// <returns>True or false.</returns>
        public static bool operator <=(TimeOfDay t1, TimeOfDay t2)
        {
            if (ReferenceEquals(t1, null))
            {
                return true;
            }
            if (ReferenceEquals(t2, null))
            {
                return false;
            }
            return t1.AbsoluteSeconds <= t2.AbsoluteSeconds;
        }

        /// <summary>
        /// Returns true if t1 is after t2, otherwise false.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance.</param>
        /// <returns>True or false.</returns>
        public static bool operator >(TimeOfDay t1, TimeOfDay t2)
        {
            if (ReferenceEquals(t1, null))
            {
                return false;
            }
            if (ReferenceEquals(t2, null))
            {
                return true;
            }
            return t1.AbsoluteSeconds > t2.AbsoluteSeconds;
        }

        /// <summary>
        /// Returns false if t1 is before t2, otherwise true.
        /// </summary>
        /// <param name="t1">A <see cref="TimeOfDay"/> instance.</param>
        /// <param name="t2">A <see cref="TimeOfDay"/> instance.</param>
        /// <returns>True or false.</returns>
        public static bool operator >=(TimeOfDay t1, TimeOfDay t2)
        {
            if (ReferenceEquals(t1, null))
            {
                return ReferenceEquals(t2, null);
            }
            if (ReferenceEquals(t2, null))
            {
                return false;
            }
            return t1.AbsoluteSeconds >= t2.AbsoluteSeconds;
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan" /> representing the time elapsed between the two parameters.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>A <see cref="TimeSpan" /> struct.</returns>
        public static TimeSpan operator -(TimeOfDay t1, TimeOfDay t2)
        {
            return TimeSpan.FromSeconds(t1.AbsoluteSeconds - t2.AbsoluteSeconds);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan" /> representing the time elapsed between the two parameters.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>A <see cref="TimeSpan" /> struct.</returns>
        public static TimeSpan operator -(TimeOfDay t1, TimeSpan t2)
        {
            return TimeSpan.FromSeconds(t1.AbsoluteSeconds - t2.TotalSeconds);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan" /> representing the time elapsed between the two parameters.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>A <see cref="TimeSpan" /> struct.</returns>
        public static TimeSpan operator -(TimeSpan t1, TimeOfDay t2)
        {
            return TimeSpan.FromSeconds(t1.TotalSeconds - t2.AbsoluteSeconds);
        }

        /// <summary>
        /// Returns a new <see cref="TimeOfDay" /> object representing the time of day of the first parameter, plus the span of time of the second parameter.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>A new <see cref="TimeOfDay" /> instance.</returns>
        public static TimeOfDay operator +(TimeOfDay t1, TimeSpan t2)
        {
            return new TimeOfDay(t1.AbsoluteSeconds + t2.TotalSeconds);
        }

        /// <summary>
        /// Returns a new <see cref="TimeOfDay" /> object representing the time of day of the second parameter, plus the span of time of the first parameter.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>A new <see cref="TimeOfDay" /> instance.</returns>
        public static TimeOfDay operator +(TimeSpan t1, TimeOfDay t2)
        {
            return new TimeOfDay(t1.TotalSeconds + t2.AbsoluteSeconds);
        }

        /// <summary>
        /// Offsets a <see cref="TimeOfDay"/> by a given number of minutes.
        /// </summary>
        /// <param name="minutes">The number of minutes (positive or negative) to add to the current time.</param>
        public void AddMinutes(int minutes)
        {
            AbsoluteSeconds += minutes * 60;
        }

        /// <summary>
        /// Create a copy of this object.
        /// </summary>
        /// <returns>A copy of this object.</returns>
        public TimeOfDay Copy()
        {
            return new TimeOfDay { AbsoluteSeconds = AbsoluteSeconds };
        }

        /// <summary>
        /// Copy the contents of this object into another.
        /// </summary>
        /// <param name="target">The target object to be overwritten.</param>
        public void CopyTo(TimeOfDay target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            target.AbsoluteSeconds = AbsoluteSeconds;
        }
    }
}
