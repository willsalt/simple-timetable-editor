using System.Collections.Generic;

namespace Timetabler.SerialData
{
    /// <summary>
    /// Class representing a train, in serialisable form.
    /// </summary>
    public class TrainModel : UniqueItemModel
    {
        /// <summary>
        /// The headcode, diagram or reporting number of this train.
        /// </summary>
        public string Headcode { get; set; }

        /// <summary>
        /// The locomotive diagram or reporting number for this train.
        /// </summary>
        public string LocoDiagram { get; set; }

        /// <summary>
        /// The unique ID of the type of train.
        /// </summary>
        public string TrainClassId { get; set; }

        /// <summary>
        /// The properties used for drawing this train's line on the train graph.
        /// </summary>
        public GraphTrainPropertiesModel GraphProperties { get; set; }

        /// <summary>
        /// The data relating to this train at each location it passes or calls at.
        /// </summary>
        public ICollection<TrainLocationTimeModel> TrainTimes { get; } = new List<TrainLocationTimeModel>();

        /// <summary>
        /// The IDs of footnotes to be displayed in the train's column header(s).
        /// </summary>
        public ICollection<string> FootnoteIds { get; } = new List<string>();

        /// <summary>
        /// Whether or not to include a separator line above the first calling point of this train.
        /// </summary>
        public bool? IncludeSeparatorAbove { get; set; }

        /// <summary>
        /// Whether or not to include a separator line below the last calling point of this train.
        /// </summary>
        public bool? IncludeSeparatorBelow { get; set; }

        /// <summary>
        /// Inline footnote to be displayed either in spare space in the train's column (or one of them), or alongside it.
        /// </summary>
        public string InlineNote { get; set; }

        /// <summary>
        /// The next action of the train set.
        /// </summary>
        public ToWorkModel SetToWork { get; set; }

        /// <summary>
        /// The next action of the locomotive, if different to the train set.
        /// </summary>
        public ToWorkModel LocoToWork { get; set; }
    }
}
