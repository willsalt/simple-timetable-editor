using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class GraphTrainPropertiesExtensions
    {
        public static GraphTrainPropertiesModel ToYamlGraphTrainPropertiesModel(this GraphTrainProperties properties)
        {
            if (properties is null)
            {
                throw new NullReferenceException();
            }

            return new GraphTrainPropertiesModel
            {
                Colour = properties.Colour.ToArgb().ToString("X8", CultureInfo.InvariantCulture),
                DashStyleName = Enum.GetName(typeof(DashStyle), properties.DashStyle),
                Width = properties.Width,
            };
        }
    }
}
