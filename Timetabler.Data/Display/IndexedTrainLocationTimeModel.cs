using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Display
{
    public class IndexedTrainLocationTimeModel
    {
        public ILocationEntry Entry { get; set; }

        public TrainLocationTimeModel Model { get => Entry as TrainLocationTimeModel; }

        public int Index { get; set; }
    }
}
