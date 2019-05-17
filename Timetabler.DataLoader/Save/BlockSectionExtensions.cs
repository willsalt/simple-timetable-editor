using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
{
    public static class BlockSectionExtensions
    {
        public static BlockSectionModel ToBlockSectionModel(this BlockSection section)
        {
            if (section == null)
            {
                return null;
            }

            return new BlockSectionModel
            {
                Id = section.Id,
                Capacity = section.Capacity,
                MinimumSectionTime = section.MinimumTravelTime,
                StartLocationId = section.StartLocation?.Id,
                EndLocationId = section.EndLocation?.Id,
            };
        }
    }
}
