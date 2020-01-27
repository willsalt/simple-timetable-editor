namespace Timetabler.SerialData.Yaml
{
    public class NoteModel
    {
        public string Id { get; set; }

        public string Symbol { get; set; }

        public string Definition { get; set; }

        public bool? AppliesToTrains { get; set; }

        public bool? AppliesToTimings { get; set; }

        public bool? DefinedOnPages { get; set; }

        public bool? DefinedInGlossary { get; set; }
    }
}