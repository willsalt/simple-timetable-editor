namespace Timetabler.SerialData.Yaml
{
    public class SignalboxHoursModel
    {
        public string SignalboxId { get; set; }

        public TimeOfDayModel StartTime { get; set; }

        public TimeOfDayModel FinishTime { get; set; }

        public bool? TokenBalanceWarning { get; set; }
    }
}