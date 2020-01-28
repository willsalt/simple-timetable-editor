using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class DocumentOptionsExtensions
    {
        public static DocumentOptionsModel ToYamlDocumentOptionsModel(this DocumentOptions options)
        {
            if (options is null)
            {
                throw new NullReferenceException();
            }

            return new DocumentOptionsModel
            {
                ClockTypeName = Enum.GetName(typeof(ClockType), options.ClockType),
                DisplayTrainLabelsOnGraphs = options.DisplayTrainLabelsOnGraphs,
                GraphEditStyle = Enum.GetName(typeof(GraphEditStyle), options.GraphEditStyle),
            };
        }
    }
}
