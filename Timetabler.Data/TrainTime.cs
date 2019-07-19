using System.Collections.Generic;
using System.Linq;

namespace Timetabler.Data
{
    /// <summary>
    /// Represents a time in a timetable, plus any footnotes associated with it.
    /// </summary>
    public class TrainTime
    {
        /// <summary>
        /// The time.
        /// </summary>
        public TimeOfDay Time { get; set; }

        /// <summary>
        /// The footnotes that apply to this timing point.
        /// </summary>
        public List<Note> Footnotes { get; set; }

        /// <summary>
        /// The symbols of all the footnotes that apply to this timing point, concatenated into a single string, or a space if this timing point has no footnotes.
        /// </summary>
        public string FootnoteSymbols
        {
            get
            {
                return (Footnotes != null && Footnotes.Any()) ? string.Join(string.Empty, Footnotes.Select(n => n?.Symbol ?? "")) : "  ";
            }
        }
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainTime()
        {
            Footnotes = new List<Note>();
        }

        /// <summary>
        /// Attempt to populate the <see cref="Footnotes"/> property, 
        /// </summary>
        /// <param name="allFootnotes"></param>
        public void ResolveFootnotes(IDictionary<string, Note> allFootnotes)
        {
            List<string> currentIds = Footnotes.Select(n => n.Id).ToList();
            for (int i = 0; i < currentIds.Count; ++i)
            {
                if (allFootnotes.ContainsKey(currentIds[i]))
                {
                    Footnotes[i] = allFootnotes[currentIds[i]];
                }
            }
        }

        /// <summary>
        /// Create a copy of this instance.
        /// </summary>
        /// <returns></returns>
        public TrainTime Copy()
        {
            return new TrainTime
            {
                Time = Time?.Copy(),
                Footnotes = Footnotes.ToList(),
            };
        }
    }
}
