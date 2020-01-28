using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class SignalboxExtensions
    {
        public static SignalboxModel ToYamlSignalboxModel(this Signalbox box)
        {
            if (box is null)
            {
                throw new NullReferenceException();
            }

            return new SignalboxModel
            {
                Id = box.Id,
                Code = box.Code,
                EditorDisplayName = box.EditorDisplayName,
                TimetableDisplayName = box.ExportDisplayName,
            };
        }
    }
}
