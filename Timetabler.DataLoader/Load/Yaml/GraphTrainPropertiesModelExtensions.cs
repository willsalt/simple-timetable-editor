using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class GraphTrainPropertiesModelExtensions
    {
        public static GraphTrainProperties ToGraphTrainProperties(this GraphTrainPropertiesModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            GraphTrainProperties gtp = new GraphTrainProperties { Width = model.Width ?? 1f };

            if (int.TryParse(model.Colour, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int col))
            {
                gtp.Colour = Color.FromArgb(col);
            }

            if (Enum.TryParse(model.DashStyleName, out DashStyle style))
            {
                gtp.DashStyle = style;
            }

            return gtp;
        }
    }
}
