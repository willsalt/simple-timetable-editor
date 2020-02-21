namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// Describes a block section, in serialisable form.
    /// </summary>
    public class BlockSectionModel
    {
        /// <summary>
        /// Unique ID of this section.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The ID of the location at one end of the section.
        /// </summary>
        public string StartLocationId { get; set; }

        /// <summary>
        /// The ID of the location at the oppostite end of the section to <see cref="StartLocationId" />.
        /// </summary>
        public string EndLocationId { get; set; }

        /// <summary>
        /// The number of trains which can be in the section simultaneously.
        /// </summary>
        public int Capacity { get; set; }
    }
}
