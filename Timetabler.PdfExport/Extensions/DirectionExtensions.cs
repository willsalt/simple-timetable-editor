using Timetabler.CoreData;

namespace Timetabler.PdfExport.Extensions
{
    public static class DirectionExtensions
    {
        public static Direction Opposite(this Direction d)
        {
            switch (d)
            {
                case Direction.Down:
                    return Direction.Up;
                case Direction.Up:
                    return Direction.Down;
                default:
                    return d;
            }
        }
    }
}
