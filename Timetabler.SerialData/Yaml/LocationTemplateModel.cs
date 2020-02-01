using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    public class LocationTemplateModel
    {
        public int? Version { get; set; }

        public List<NetworkMapModel> Maps { get; } = new List<NetworkMapModel>();

        public LocationTemplateModel()
        {
            Version = 3;
        }
    }
}
