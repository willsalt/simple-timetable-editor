using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class SignalboxModelExtensions
    {
        public static Signalbox ToSignalbox(this SignalboxModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            return new Signalbox
            {
                Id = model.Id,
                Code = model.Code,
                EditorDisplayName = model.EditorDisplayName,
                ExportDisplayName = model.TimetableDisplayName,
            };
        }
    }
}
