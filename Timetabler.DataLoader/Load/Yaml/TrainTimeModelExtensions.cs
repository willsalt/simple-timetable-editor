using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class TrainTimeModelExtensions
    {
        public static TrainTime ToTrainTime(this TrainTimeModel model, Dictionary<string, Note> notes)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            TrainTime tt = new TrainTime { Time = model.At?.ToTimeOfDay() };

            foreach (string noteId in model.FootnoteIds)
            {
                tt.Footnotes.Add(notes?[noteId]);
            }

            return tt;
        }
    }
}
