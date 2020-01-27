namespace Timetabler.SerialData.Yaml
{
    public class ExportOptionsModel
    {
        public bool DisplayLocoDiagramRow { get; set; }

        public string FontSet { get; set; }

        public bool? GraphsInOutput { get; set; }

        public bool? ToWorkRowInOutput { get; set; }

        public bool? LocoToWorkRowInOutput { get; set; }

        public bool? BoxHoursInOutput { get; set; }

        public bool? CreditsInOutput { get; set; }

        public bool? GlossaryInOutput { get; set; }

        public double? LineWidth { get; set; }

        public double? FillerDashLineWidth { get; set; }
    }
}