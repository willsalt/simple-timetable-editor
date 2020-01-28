using System;
using System.Collections.Generic;
using System.Text;

namespace Timetabler.SerialData.Yaml
{
    public class LocationTemplateModel
    {
        public int? Version { get; set; }

        public List<NetworkMapModel> Maps { get; set; }

        public LocationTemplateModel()
        {
            Version = 3;
        }
    }
}
