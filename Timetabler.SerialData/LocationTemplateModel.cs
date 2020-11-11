using System.Collections.Generic;

namespace Timetabler.SerialData
{
    /// <summary>
    /// Class describing a template consisting only of locations, in serialisable form.
    /// </summary>
    public class LocationTemplateModel
    {
        /// <summary>
        /// The version number of the template file.
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// The list of maps that makes up the template.
        /// </summary>
        public List<NetworkMapModel> Maps { get; } = new List<NetworkMapModel>();

        /// <summary>
        /// Constructor.  Sets the file version number to 3.
        /// </summary>
        public LocationTemplateModel()
        {
            Version = 3;
        }
    }
}
