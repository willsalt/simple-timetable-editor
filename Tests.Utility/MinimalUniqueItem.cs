using System.Diagnostics.CodeAnalysis;
using Timetabler.CoreData.Interfaces;

namespace Tests.Utility
{
    [ExcludeFromCodeCoverage]
    public class MinimalUniqueItem : IUniqueItem
    {
        public string Id { get; set; }
    }
}
