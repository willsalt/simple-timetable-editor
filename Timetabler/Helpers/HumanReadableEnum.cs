using System;

namespace Timetabler.Helpers
{
    /// <summary>
    /// A class which boxes an enum value and also provides a human-readable and potentially translated string describing the name of the enum value.  Intended for use as ComboBox selection items.
    /// </summary>
    /// <typeparam name="TEnum">The enum type which this class boxes.</typeparam>
    public class HumanReadableEnum<TEnum> where TEnum : struct, IComparable, IFormattable, IConvertible // if only "where T : enum" was legal but it's not 
    {
        /// <summary>
        /// The human-readable name which matches the <see cref="Value"/> property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The enum value.
        /// </summary>
        public TEnum Value { get; set; }

        /// <summary>
        /// Convert this instance to a string.
        /// </summary>
        /// <returns>The <see cref="Name"/> property of this instance.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
