using Timetabler.CoreData;

namespace Timetabler.SerialData.Yaml
{
    public class LocationModel
    {
        public string Id { get; set; }

        public string EditorDisplayName { get; set; }

        public string TimetableDisplayName { get; set; }

        public string GraphDisplayName { get; set; }

        public string LocationCode { get; set; }

        public ArrivalDepartureOptions? UpArrivalDepartureAlwaysDisplayed { get; set; }

        public TrainRoutingOptions? UpRoutingCodesAlwaysDisplayed { get; set; }

        public ArrivalDepartureOptions? DownArrivalDepartureAlwaysDisplayed { get; set; }

        public TrainRoutingOptions? DownRoutingCodesAlwaysDisplayed { get; set; }

        public bool? DisplaySeparatorAbove { get; set; }

        public bool? DisplaySeparatorBelow { get; set; }

        public DistanceModel Mileage { get; set; }

        public string FontTypeName { get; set; }


    }
}