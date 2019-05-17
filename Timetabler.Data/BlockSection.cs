namespace Timetabler.Data
{
    public class BlockSection
    {
        public string Id { get; set; }

        public Location StartLocation { get; set; }

        public Location EndLocation { get; set; }

        public int Capacity { get; set; }

        public int MinimumTravelTime { get; set; }
    }
}
