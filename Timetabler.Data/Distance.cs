using System;
using System.Globalization;

namespace Timetabler.Data
{
    /// <summary>
    /// This class describes a point on a railway route, in terms of its mileage from a datum point.
    /// The program assumes that mileage increases in the Down direction and decreases in the Up direction.
    /// </summary>
    public struct Distance : IEquatable<Distance>, IComparable, IComparable<Distance>, IFormattable
    {
        /// <summary>
        /// Label used to describe the major part of the distance (such as "M" or "Miles")
        /// </summary>
        public static string MajorLabel => Resources.Distance_MileageLabel;

        /// <summary>
        /// Label used to describe the minor part of the distance (such as "C" or "Chains")
        /// </summary>
        public static string MinorLabel => Resources.Distance_ChainageLabel;

        /// <summary>
        /// The integer miles component of the mileage.
        /// </summary>
        public int Mileage { get; private set; }

        /// <summary>
        /// The sub-miles component of the mileage, in chains.  One chain is 1/80 of one mile.
        /// </summary>
        public double Chainage { get; private set; }

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
        /// Constructor.
        /// </summary>
        /// <param name="miles">The miles portion of the distance.</param>
        /// <param name="chains">The chains portion of the distance.</param>
        public Distance(int miles, double chains)
        {
            Mileage = miles + ((int)chains) / 80;
            Chainage = chains % 80;
        }

        /// <summary>
        /// Return true if d1 is less than d2, false otherwise.
        /// </summary>
        /// <param name="d1">A distance figure.</param>
        /// <param name="d2">A distance figure.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator <(Distance d1, Distance d2)
        {
            return d1.Mileage < d2.Mileage || (d1.Mileage == d2.Mileage && d1.Chainage < d2.Chainage);
        }

        /// <summary>
        /// Return true if d1 is less than or equal to d2, false otherwise.
        /// </summary>
        /// <param name="d1">A distance figure.</param>
        /// <param name="d2">A distance figure.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator <=(Distance d1, Distance d2)
        {
            return d1.Mileage < d2.Mileage || (d1.Mileage == d2.Mileage && d1.Chainage <= d2.Chainage);
        }

        /// <summary>
        /// Return true if d1 is greater than d2, false otherwise.
        /// </summary>
        /// <param name="d1">A distance instance.</param>
        /// <param name="d2">A distance instance.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator >(Distance d1, Distance d2)
        {
            return d1.Mileage > d2.Mileage || (d1.Mileage == d2.Mileage && d1.Chainage > d2.Chainage);
        }

        /// <summary>
        /// Return true if d1 is greater than or equal to d2, false otherwise.
        /// </summary>
        /// <param name="d1">A distance instance.</param>
        /// <param name="d2">A distance instance.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator >=(Distance d1, Distance d2)
        {
            return d1.Mileage > d2.Mileage || (d1.Mileage == d2.Mileage && d1.Chainage >= d2.Chainage);
        }

        /// <summary>
        /// Returns true if d1 and d2 represent an equal mileage, false otherwise.   Note that chainage wraparound is not considered, so 2m 20ch is not considered 
        /// equal to 1m 100ch.  This should not be an issue, as the constructor should normalise the latter.
        /// </summary>
        /// <param name="d1">A distance instance.</param>
        /// <param name="d2">A distance instance.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator ==(Distance d1, Distance d2)
        {
            return d1.Mileage == d2.Mileage && d1.Chainage == d2.Chainage;
        }

        /// <summary>
        /// Returns false if d1 and d2 represent an equal mileage, true otherwise.  Note that chainage wraparound is not considered, so 2m 20ch is not considered 
        /// equal to 1m 100ch.  This should not be an issue, as the constructor should normalise the latter.
        /// </summary>
        /// <param name="d1">A distance instance.</param>
        /// <param name="d2">A distance instance.</param>
        /// <returns>A boolean value.</returns>
        public static bool operator !=(Distance d1, Distance d2)
        {
            return d1.Mileage != d2.Mileage || d2.Chainage != d1.Chainage;
        }

        /// <summary>
        /// Adds two <see cref="Distance" />s and returns a <see cref="Distance" /> equal to their sum.
        /// </summary>
        /// <param name="d1">A <see cref="Distance" /> value.</param>
        /// <param name="d2">A <see cref="Distance" /> value.</param>
        /// <returns>A <see cref="Distance" /> value equal to the sum of the two parameters.</returns>
        public static Distance operator +(Distance d1, Distance d2)
        {
            return new Distance(d1.Mileage + d2.Mileage, d1.Chainage + d2.Chainage);
        }

        /// <summary>
        /// Adds two <see cref="Distance" />s and returns a <see cref="Distance" /> equal to their sum.
        /// </summary>
        /// <param name="d1">A <see cref="Distance" /> value.</param>
        /// <param name="d2">A <see cref="Distance" /> value.</param>
        /// <returns>A <see cref="Distance" /> value equal to the sum of the two parameters.</returns>
        public static Distance Add(Distance d1, Distance d2)
        {
            return d1 + d2;
        }

        /// <summary>
        /// Compute the absolute difference between two <see cref="Distance" /> instances.
        /// </summary>
        /// <param name="d1">A <see cref="Distance" /> instance.</param>
        /// <param name="d2">A <see cref="Distance" /> instance.</param>
        /// <returns>A <see cref="Distance" /> instance whose value is equal to the difference between the two parameters.</returns>
        public static Distance Difference(Distance d1, Distance d2)
        {
            if (d1 == d2)
            {
                return new Distance();
            }
            if (d1 > d2)
            {
                return Subtract(d1, d2);
            }
            else
            {
                return Subtract(d2, d1);
            }
        }

        private static Distance Subtract(Distance d1, Distance d2)
        {
            int miles = d1.Mileage - d2.Mileage;
            double chains = d1.Chainage - d2.Chainage;
            if (chains >= 0)
            {
                return new Distance(miles, chains);
            }
            return new Distance(miles - 1, 80 + chains);
        }

        /// <summary>
        /// Compares this value to another value.  Returns 1 if this value is greater than the other, -1 if this value is less than the other, and zero if they 
        /// are equal.
        /// </summary>
        /// <param name="other">A distance value.</param>
        /// <returns>An integer indicating comparative values.</returns>
        public int CompareTo(Distance other)
        {
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
        /// Compares this value to another <see cref="Distance" /> value.  Returns 1 if this instance is greater than the other, -1 if this instance is less than the other, and zero if
        /// they are equal.  Throws an exception if the parameter is not a <see cref="Distance" /> value.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="obj"/> parameter is not a <see cref="Distance"/> value.</exception>
        /// <param name="obj">The value to compare to.</param>
        /// <returns>An integer indicating comparative values.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is Distance d))
            {
                throw new ArgumentException(Resources.Error_WrongDataType, nameof(obj));
            }

            return CompareTo(d);
        }

        /// <summary>
        /// Equality comparison with another value.
        /// </summary>
        /// <param name="other">The value to compare against.</param>
        /// <returns>Boolean value indicating equality.</returns>
        public bool Equals(Distance other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality comparison with another object.  If the object is not a <see cref="Distance"/> value, it is cast to <see cref="double"/> and compared against the 
        /// <see cref="AbsoluteDistance"/> of this value.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>True if the objects' values are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Distance distance)
            {
                return this == distance;
            }
            return AbsoluteDistance == (double)obj;
        }

        /// <summary>
        /// Returns a hash code identifying this value.
        /// </summary>
        /// <returns>An integer hash code.</returns>
        public override int GetHashCode()
        {
            return ((int)Chainage) ^ (Mileage << 7);
        }

        /// <summary>
        /// Returns a string representation of this value, formatted using a given format string and provided culture-specific information.
        /// </summary>
        /// <remarks>This method recognises three possible format strings, each consisting of a single character.  "G" returns a string of the form "Xm Ych" where 
        /// X and Y are integers.  "F" functions as "G", but returns a floating-point chainage value.  "D" returns the <see cref="AbsoluteDistance"/> property.  
        /// Lower-case format characters are also accepted.</remarks>
        /// <param name="format">The format character to use.</param>
        /// <param name="formatProvider">Format provider containing culture-specific information.</param>
        /// <exception cref="FormatException">Thrown if a format string other than the single characters D, F or G (or their lowercase equivalent) is 
        /// provided.</exception>
        /// <returns>This value formatted as a string.</returns>
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
        /// Returns a string representation of this value, formatted using a given format string, for the current locale.
        /// </summary>
        /// <remarks>This method recognises three possible format strings, each consisting of a single character.  "G" returns a string of the form "Xm Ych" where 
        /// X and Y are integers.  "F" functions as "G", but returns a floating-point chainage value.  "D" returns the <see cref="AbsoluteDistance"/> property.  
        /// Lower-case format characters are also accepted.</remarks>
        /// <param name="format">The format character to use.</param>
        /// <exception cref="FormatException">Thrown if a format string other than the single characters D, F or G (or their lowercase equivalent) is 
        /// provided.</exception>
        /// <returns>This value formatted as a string.</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns a string representation of this value, in the format "Xm Ych".
        /// </summary>
        /// <returns>The value of this object formatted as a string.</returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }
    }
}
