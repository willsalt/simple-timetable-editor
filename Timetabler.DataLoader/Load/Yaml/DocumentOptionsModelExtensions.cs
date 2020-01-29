using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class DocumentOptionsModelExtensions
    {
        public static DocumentOptions ToDocumentOptions(this DocumentOptionsModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            DocumentOptions options = new DocumentOptions
            {
                DisplayTrainLabelsOnGraphs = model.DisplayTrainLabelsOnGraphs ?? true
            };

            if (Enum.TryParse(model.ClockTypeName, out ClockType ct))
            {
                options.ClockType = ct;
            }

            if (Enum.TryParse(model.GraphEditStyle, out GraphEditStyle ges))
            {
                options.GraphEditStyle = ges;
            }

            return options;
        }
    }
}
