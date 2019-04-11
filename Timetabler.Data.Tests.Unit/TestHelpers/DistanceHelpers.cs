using System;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class DistanceHelpers
    {
        private static Random rnd = new Random();

        public static Distance GetDistance()
        {
            return new Distance { Mileage = rnd.Next(short.MaxValue), Chainage = rnd.Next(80) };
        }

        public static Distance GetDistanceGreaterThan(Distance d)
        {
            return d + GetDistance();
        }
    }
}
