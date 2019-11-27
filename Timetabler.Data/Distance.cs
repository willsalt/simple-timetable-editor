using System;
using System.Globalization;

namespace Timetabler.Data
{
    /// <summary>
    /// This class describes a point on a railway route, in terms of its mileage from a datum point.
    /// The program assumes that mileage increases in the Down direction and decreases in the Up direction.
    /// </summary>
    public class Distance : IEquatable<Distance>, IComparable, IComparable<Distance>, IFormattable
    {
        /// <summary>
        /// The integer miles component of the mileage.
        /// </summary>
        public int Mileage { get; set; }

        /// <summary>
        /// The sub-miles component of the mileage, in chains.  One chain is 1/80 of one mile.
        /// </summary>
        public double Chainage { get; set; }

        /// <summary>
        /// The mileage figure, as a floating point number of miles.
        /// </summary>
        public double AbsoluteDistance
        {
            get
            {
                return Chainage / 80.0 + Mileage;
            }

            set
            {
                Mileage = (int)value;
                Chainage = (value - Mileage) * 80.0;
            }
        }

        /// <summary>
        /// Return true if d1 is less than d2, false otherwise.  A null parameter is treated as the lowest possible value.
        /// </summary>
        /// <param name="d1">A distance figure.</param>
        /// <param name="d2">A distance figure.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator <(Distance d1, Distance d2)
        {
            if (d1 is null)
            {
                return d2 is object;
            }
            if (d2 is null)
            {
                return false;
            }
            return d1.Mileage < d2.Mileage || (d1.Mileage == d2.Mileage && d1.Chainage < d2.Chainage);
        }

        /// <summary>
        /// Return true if d1 is less than or equal to d2, false otherwise.  A null parameter is treated as the lowest possible value.
        /// </summary>
        /// <param name="d1">A distance figure.</param>
        /// <param name="d2">A distance figure.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator <=(Distance d1, Distance d2)
        {
            if (d1 is null)
            {
                return true;
            }
            if (d2 is null)
            {
                return false;
            }
            return d1.Mileage < d2.Mileage || (d1.Mileage == d2.Mileage && d1.Chainage <= d2.Chainage);
        }

        /// <summary>
        /// Return true if d1 is greater than d2, false otherwise.  A null parameter is treated as the lowest possible value.
        /// </summary>
        /// <param name="d1">A distance instance.</param>
        /// <param name="d2">A distance instance.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator >(Distance d1, Distance d2)
        {
            if (d1 is null)
            {
                return false;
            }
            if (d2 is null)
            {
                return true;
            }
            return d1.Mileage > d2.Mileage || (d1.Mileage == d2.Mileage && d1.Chainage > d2.Chainage);
        }

        /// <summary>
        /// Return true if d1 is greater than or equal to d2, false otherwise.  A null parameter is treated as the lowest possible value.
        /// </summary>
        /// <param name="d1">A distance instance.</param>
        /// <param name="d2">A distance instance.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator >=(Distance d1, Distance d2)
        {
            if (d1 is null)
            {
                return d2 is null;
            }
            if (d2 is null)
            {
                return false;
            }
            return d1.Mileage > d2.Mileage || (d1.Mileage == d2.Mileage && d1.Chainage >= d2.Chainage);
        }

        /// <summary>
        /// Returns true if d1 and d2 represent an equal mileage, false otherwise.  Note that chainagise wraparound is not considered, so 2m 20ch is not considered equal to 1m 100ch.
        /// This should probably be considered a bug.  Two null parameters are considered equal, but null parameters are never equal to non-null parameters.
        /// </summary>
        /// <param name="d1">A distance instance.</param>
        /// <param name="d2">A distance instance.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator ==(Distance d1, Distance d2)
        {
            if (d1 is null)
            {
                return d2 is null;
            }
            if (d2 is null)
            {
                return false;
            }
            return d1.Mileage == d2.Mileage && d1.Chainage == d2.Chainage;
        }

        /// <summary>
        /// Returns false if d1 and d2 represent an equal mileage, false otherwise.  Note that chainagise wraparound is not considered, so 2m 20ch is not considered equal to 1m 100ch.
        /// This should probably be considered a bug.  Two null parameters are considered equal, but null parameters are never equal to non-null parameters.
        /// </summary>
        /// <param name="d1">A distance instance.</param>
        /// <param name="d2">A distance instance.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator !=(Distance d1, Distance d2)
        {
            if (d1 is null)
            {
                return d2 is object;
            }
            if (d2 is null)
            {
                return true;
            }
            return d1.Mileage != d2.Mileage || d2.Chainage != d1.Chainage;
        }

        /// <summary>
        /// Adds two <see cref="Distance" />s and returns a new <see cref="Distance" /> equal to their sum.  If one parameter is null, a copy of the other parameter is returned.
        /// </summary>
        /// <param name="d1">A <see cref="Distance" /> instance.</param>
        /// <param name="d2">A <see cref="Distance" /> instance.</param>
        /// <returns>A <see cref="Distance" /> instance whose value is equal to the sum of the two parameters (null being treated as zero), or null if both parameters are null.</returns>
        public static Distance operator +(Distance d1, Distance d2)
        {
            if (d1 is null)
            {
                if (d2 is null)
                {
                    return null;
                }
                return new Distance { Mileage = d2.Mileage, Chainage = d2.Chainage };
            }
            if (d2 is null)
            {
                return new Distance { Mileage = d1.Mileage, Chainage = d1.Chainage };
            }
            Distance sum = new Distance { Mileage = d1.Mileage + d2.Mileage, Chainage = d1.Chainage + d2.Chainage };
            while (sum.Chainage > 80d)
            {
                sum.Mileage++;
                sum.Chainage -= 80d;
            }
            return sum;
        }

        /// <summary>
        /// Adds two <see cref="Distance" />s and returns a new <see cref="Distance" /> equal to their sum.  If one parameter is null, a copy of the other parameter is returned.
        /// </summary>
        /// <param name="d1">A <see cref="Distance" /> instance.</param>
        /// <param name="d2">A <see cref="Distance" /> instance.</param>
        /// <returns>A <see cref="Distance" /> instance whose value is equal to the sum of the two parameters (null being treated as zero), or null if both parameters are null.</returns>
        public static Distance Add(Distance d1, Distance d2)
        {
            return d1 + d2;
        }

        /// <summary>
        /// Compares the value of this instance to the value of another instance.  Returns 1 if this instance is greater than the other, -1 if this instance is less than the other,
        /// and zero if they are equal.  If the other instance is null, this instance is considered greater.
        /// </summary>
        /// <param name="other">A distance instance.</param>
        /// <returns>An integer indicating comparative values.</returns>
        public int CompareTo(Distance other)
        {
            if (other == null)
            {
                return 1;
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
        /// Compares the value of this instance to the value of another instance.  Returns 1 if this instance is greater than the other, -1 if this instance is less than the other, and zero if
        /// they are equal.  If the other instance is null, this instance is considered greater.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="obj"/> parameter is not a <see cref="Distance"/> instance.</exception>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>An integer indicating comparative values.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var d = obj as Distance;
            if (d == null)
            {
                throw new ArgumentException(Resources.Error_WrongDataType, nameof(obj));
            }
            return CompareTo(d);
        }

        /// <summary>
        /// Equality comparison with another instance.
        /// </summary>
        /// <param name="other">The instance to compare against.</param>
        /// <returns>Boolean value indicating equality.</returns>
        public bool Equals(Distance other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality comparison with another object.  If the object is not a <see cref="Distance"/> instance, it is cast to <see cref="double"/> and compared against the 
        /// <see cref="AbsoluteDistance"/> of this instance.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>True if the objects' values are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            Distance distance = obj as Distance;
            if (distance != null)
            {
                return this == distance;
            }
            return AbsoluteDistance == (double)obj;
        }

        /// <summary>
        /// Returns a hash code identifying the value of this instance.
        /// </summary>
        /// <returns>An integer hash code.</returns>
        public override int GetHashCode()
        {
            return ((int)Chainage) ^ (Mileage << 7);
        }

        /// <summary>
        /// Returns a string representation of this instance, formatted using a given format string and provided culture-specific information.
        /// </summary>
        /// <remarks>This method recognises three possible format strings, each consisting of a single character.  "G" returns a string of the form "Xm Ych" where X and Y are integers.  "F" 
        /// functions as "G", but returns a floating-point chainage value.  "D" returns the <see cref="AbsoluteDistance"/> property.  Lower-case format characters are also accepted.</remarks>
        /// <param name="format">The format character to use.</param>
        /// <param name="formatProvider">Format provider containing culture-specific information.</param>
        /// <exception cref="FormatException">Thrown if a format string other than the single characters D, F or G is provided.</exception>
        /// <returns>The value of this object formatted as a string.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "G";
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return string.Format(formatProvider, "{0}m {1}ch", Mileage, (int)Chainage);
                case "F":
                    return string.Format(formatProvider, "{0}m {1}ch", Mileage, Chainage);
                case "D":
                    return AbsoluteDistance.ToString(formatProvider);
                default:
                    throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.Distance_ToString_FormatExceptionMessage, format));
            }
        }

        /// <summary>
        /// Returns a string representation of this instance, formatted using a given format string, for the current locale.
        /// </summary>
        /// <remarks>This method recognises three possible format strings, each consisting of a single character.  "G" returns a string of the form "Xm Ych" where X and Y are integers.  "F" 
        /// functions as "G", but returns a floating-point chainage value.  "D" returns the <see cref="AbsoluteDistance"/> property.  Lower-case format characters are also accepted.</remarks>
        /// <param name="format">The format character to use.</param>
        /// <exception cref="FormatException">Thrown if a format string other than the single characters D, F or G is provided.</exception>
        /// <returns>The value of this object formatted as a string.</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns a string representation of the value of this instance, in the format "Xm Ych".
        /// </summary>
        /// <returns>The value of this object formatted as a string.</returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }
    }
}
