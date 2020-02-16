namespace Timetabler.SerialData.Yaml
{
    public class TrainLocationTimeModel
    {
        public TrainTimeModel Arrival { get; set; }

        public TrainTimeModel Departure { get; set; }

        public bool? Pass { get; set; }

        public string LocationId { get; set; }

        public string Path { get; set; }

        public string Platform { get; set; }

        public string Line { get; set; }
    }
}
