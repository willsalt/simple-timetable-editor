using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData;
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
        public List<TrainLocationTime> TrainTimes { get; private set; }

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
        /// Raises the <see cref="Modified" /> event.
        /// </summary>
        /// <param name="sender">The object which has modified the instance.</param>
        /// <param name="field">The name of the modified property, if only one property has been modified.</param>
        protected void OnModified(object sender, string field)
        {
            Modified?.Invoke(sender, new ModifiedEventArgs { ModifiedItem = this, ModifiedField = field });
        }

        /// <summary>
        /// The latest entry in the <see cref="TrainTimes" /> list.
        /// </summary>
        public TrainTime LastTrainTime
        {
            get
            {
                TrainTime last = null;
                foreach (TrainLocationTime tlt in TrainTimes)
                {
                    if (tlt.LastTime > last)
                    {
                        last = tlt.LastTime;
                    }
                }
                return last;
            }
        }

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
            if (footnoteDictionary is null)
            {
                throw new ArgumentNullException(nameof(footnoteDictionary));
            }
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
        /// Creates a partially-deep copy of this train, changing the times of all timing points by a fixed offset.
        /// </summary>
        /// <param name="offsetMinutes">The number of minutes to change the timings points by (negative for earlier, positive for later).</param>
        /// <returns>A copy of this instance with times edited.</returns>
        public Train Copy(int offsetMinutes)
        {
            Train t = Copy();
            foreach (TrainLocationTime locationTime in t.TrainTimes)
            {
                locationTime.OffsetTimes(offsetMinutes);
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

        /// <summary>
        /// Reverse the direction of a train by reflecting its timing points around the final one.  In other words, a train which arrives at its destination at 4pm will become a train
        /// which departs from that location at 4pm in the opposite direction and has its section times and dwell times unchanged.
        /// </summary>
        public void Reverse()
        {
            TimeOfDay reflectAbout = LastTrainTime?.Time;
            if (reflectAbout == null)
            {
                return;
            }
            for (int i = 0; i < TrainTimes.Count; ++i)
            {
                TrainTimes[i].Reflect(reflectAbout, i == 0 || i == TrainTimes.Count - 1);
            }
            TrainTimes.Sort(new TrainLocationArrivalTimeComparer());
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
