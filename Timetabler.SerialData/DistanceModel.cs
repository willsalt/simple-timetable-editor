namespace Timetabler.SerialData
{
    /// <summary>
    /// Describes a distance in serialisable form.
    /// </summary>
    public class DistanceModel
    {
        /// <summary>
        /// The number of miles the distance consists of, truncated.
        /// </summary>
        public int Miles { get; set; }

        /// <summary>
        /// The fraction of a mile that the distance consists of, in chains.
        /// </summary>
        public double Chains { get; set; }
    }
}
