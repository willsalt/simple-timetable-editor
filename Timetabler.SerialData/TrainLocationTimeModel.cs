namespace Timetabler.SerialData
{
    /// <summary>
    /// Class represeting the data items associating a train with a particular location, including arrival and departure times and routing information.
    /// </summary>
    public class TrainLocationTimeModel
    {
        /// <summary>
        /// Arrival time (if any)
        /// </summary>
        public TrainTimeModel Arrival { get; set; }

        /// <summary>
        /// Departure time (if any)
        /// </summary>
        public TrainTimeModel Departure { get; set; }

        /// <summary>
        /// Is the (departure) time a passing time or a stopping time?
        /// </summary>
        public bool? Pass { get; set; }

        /// <summary>
        /// Unique ID of the location that this refers to.
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Train path info - in other words, the track that the train approaches on.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Platform routing info - the platform or line that the train calls at or passes on.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Line routing info - the track that the train leaves on.
        /// </summary>
        public string Line { get; set; }
    }
}
