using System;

namespace Unicorn.Interfaces
{
    /// <summary>
    ///  Immutable class which encapsulates the start and end of a range of locations along a dimension.
    /// </summary>
    public struct UniRange : IEquatable<UniRange>
    {
        /// <summary>
        /// Start
        /// </summary>
        public double Start { get; private set; }

        /// <summary>
        /// End
        /// </summary>
        public double End { get; private set; }

        /// <summary>
        /// Size - the distance between <see cref="Start" /> and <see cref="End" />.
        /// </summary>
        public double Size { get { return End - Start; } }

        /// <summary>
        /// Constructor, setting <see cref="Start" /> and <see cref="End" /> properties.    
        /// </summary>
        /// <param name="start">The value of the <see cref="Start" /> property.</param>
        /// <param name="end">The value of the <see cref="End" /> property.</param>
        public UniRange(double start, double end)
        {
            Start = start;
            End = end;
        }

        public bool Equals(UniRange other) => this == other;

        public override bool Equals(object obj)
        {
            if (obj is UniRange other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() ^ (End * 2).GetHashCode();
        }

        public static bool operator ==(UniRange a, UniRange b) => a.Start == b.Start && a.End == b.End;

        public static bool operator !=(UniRange a, UniRange b) => a.Start != b.Start || a.End != b.End;
    }
}
