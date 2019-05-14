using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data
{
    /// <summary>
    /// A class describing a train in a timetable.
    /// </summary>
    public class Train : IUniqueItem, IWatchableItem
    {
        /// <summary>
        /// The unique identifier of this train.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The headcode or diagram number of this train.
        /// </summary>
        public string Headcode { get; set; }

        /// <summary>
        /// The diagram number of the loco, if different or relevant.
        /// </summary>
        public string LocoDiagram { get; set; }

        /// <summary>
        /// The <see cref="TrainClass.Id"/> property of the <see cref="TrainClass"/> property, for normalised serialisation.
        /// </summary>
        public string TrainClassId { get; set; }
        
        /// <summary>
        /// The class of this train.
        /// </summary>
        public TrainClass TrainClass { get; set; }

        /// <summary>
        /// The graph display properties of this train.
        /// </summary>
        public GraphTrainProperties GraphProperties { get; set; }

        /// <summary>
        /// The timing points of this train.
        /// </summary>
        public List<TrainLocationTime> TrainTimes { get; set; }

        /// <summary>
        /// Include separator above this train if it does not start at the first location.
        /// </summary>
        public bool IncludeSeparatorAbove { get; set; }

        /// <summary>
        /// Include separator below this train if it does not start at the first location.
        /// </summary>
        public bool IncludeSeparatorBelow { get; set; }

        /// <summary>
        /// Note associated with this train, to be drawn in the timetable.
        /// </summary>
        public string InlineNote { get; set; }

        /// <summary>
        /// Details of the next service worked by this train.
        /// </summary>
        public ToWork ToWork { get; set; }

        /// <summary>
        /// Details of the next service worked by this loco (if different).
        /// </summary>
        public ToWork LocoToWork { get; set; }

        /// <summary>
        /// Footnotes that apply to this train.
        /// </summary>
        public List<Note> Footnotes { get; }

        /// <summary>
        /// Event to be raised when this object is modified.  Not yet implemented.
        /// </summary>
        public event ModifiedEventHandler Modified;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Train()
        {
            TrainTimes = new List<TrainLocationTime>();
            GraphProperties = new GraphTrainProperties();
            Footnotes = new List<Note>();

            // These default to true to avoid User Error - me thinking that there is a bug when in reality the fields just weren't set
            IncludeSeparatorAbove = true;
            IncludeSeparatorBelow = true;
        }

        /// <summary>
        /// Populate the <see cref="Footnotes"/> property with objects with the same IDs as the contents of the _footnoteIds member.
        /// </summary>
        /// <param name="footnoteDictionary"></param>
        public void ResolveFootnotes(Dictionary<string, Note> footnoteDictionary)
        {
            List<string> currentIds = Footnotes.Select(n => n.Id).ToList();
            for (int i = 0; i < currentIds.Count; ++i)
            {
                if (footnoteDictionary.ContainsKey(currentIds[i]))
                {
                    Footnotes[i] = footnoteDictionary[currentIds[i]];
                }
            }
        }

        /// <summary>
        /// Create a partially deep copy of this train.  The <see cref="TrainTimes"/> property is deep-copied; other properties are shallow-copied.
        /// </summary>
        /// <returns>A copy of the current instance.</returns>
        public Train Copy()
        {
            Train t = new Train
            {
                Headcode = Headcode,
                LocoDiagram = LocoDiagram,
                TrainClass = TrainClass,
                TrainClassId = TrainClassId,
                IncludeSeparatorAbove = IncludeSeparatorAbove,
                IncludeSeparatorBelow = IncludeSeparatorBelow,
                InlineNote = InlineNote,
                GraphProperties = GraphProperties.Copy(),
                ToWork = ToWork?.Copy(),
                LocoToWork = LocoToWork?.Copy(),
            };
            foreach (TrainLocationTime tlt in TrainTimes)
            {
                t.TrainTimes.Add(tlt.Copy());
            }
            foreach (Note fn in Footnotes as IEnumerable<Note>)
            {
                t.Footnotes.Add(fn);
            }

            return t;
        }

        /// <summary>
        /// Ensure that the user-visible version of all of the data for this train is up-to-date with the raw data.
        /// </summary>
        public void RefreshTimingPointModels()
        {
            foreach (var timingPoint in TrainTimes)
            {
                timingPoint.RefreshTimeModels();
            }
        }

        internal void ResolveTrainClass(Dictionary<string, TrainClass> trainClasses)
        {
            if (TrainClass == null)
            {
                return;
            }
            if (trainClasses.ContainsKey(TrainClass.Id))
            {
                TrainClass = trainClasses[TrainClass.Id];
            }
        }
    }
}
