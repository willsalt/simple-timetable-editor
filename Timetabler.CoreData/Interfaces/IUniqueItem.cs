using System.Xml.Serialization;

namespace Timetabler.CoreData.Interfaces
{
    /// <summary>
    /// This interface describes a class which has an <see cref="Id"/> property intended to uniquely identify the instance.
    /// </summary>
    public interface IUniqueItem
    {
        /// <summary>
        /// A string value that uniquely identifies this instance.
        /// </summary>
        [XmlAttribute]
        string Id { get; set; }
    }
}
