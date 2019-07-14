using Timetabler.Data;

namespace Timetabler.Models
{
    public class TrainCopyFormModel
    {
        public string TrainId { get; set; }

        public string TrainName { get; set; }

        public AddSubtract AddSubtract { get; set; }

        public int Offset { get; set; }

        public bool ClearInlineNotes { get; set; }

        public static TrainCopyFormModel FromTrain(Train train)
        {
            return new TrainCopyFormModel
            {
                TrainId = train.Id,
                TrainName = train.Headcode,
                AddSubtract = AddSubtract.Add,
                Offset = 0
            };
        }
    }
}
