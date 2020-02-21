namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// Class representing a type of train, in serialisable form.
    /// </summary>
    public class TrainClassModel
    {
        /// <summary>
        /// Unique ID of this train class.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Code used to refer to this class, such as "B" or "5".
        /// </summary>
        public string TableCode { get; set; }

        /// <summary>
        /// Description of this class, such as "Ordinary Passenger" or "Empty Stock".
        /// </summary>
        public string Description { get; set; }
    }
}
