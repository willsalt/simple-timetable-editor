using System;

namespace Unicorn.Interfaces.Tests.Utility.Extensions
{
    public static class RandomExtensions
    {
        private static readonly UniDashStyle[] _dashStyles = 
            new[] { UniDashStyle.Solid, UniDashStyle.Dash, UniDashStyle.Dot, UniDashStyle.DashDot, UniDashStyle.DashDotDot };

        public static UniDashStyle NextUniDashStyle(this Random rnd)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }

            return _dashStyles[rnd.Next(_dashStyles.Length)];
        }

        public static UniFontStyles NextUniFontStyles(this Random rnd)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }
            return (UniFontStyles)rnd.Next(16);
        }

        public static UniSize NextUniSize(this Random rnd)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }
            return new UniSize(rnd.NextDouble() * 1000, rnd.NextDouble() * 1000);
        }

        public static UniTextSize NextUniTextSize(this Random rnd)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }
            return new UniTextSize(rnd.NextDouble() * 500, rnd.NextDouble() * 500, rnd.NextDouble() * 500, rnd.NextDouble() * 500, rnd.NextDouble() * 500);
        }

        private static readonly PhysicalPageSize[] _physicalPageSizes 
            = new[] { PhysicalPageSize.A1, PhysicalPageSize.A2, PhysicalPageSize.A3, PhysicalPageSize.A4, PhysicalPageSize.A5, PhysicalPageSize.A6 };

        public static PhysicalPageSize NextPhysicalPageSize(this Random rnd)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }
            return _physicalPageSizes[rnd.Next(_physicalPageSizes.Length)];
        }

        private static readonly PageOrientation[] _pageOrientations = new[] { PageOrientation.Portrait, PageOrientation.Landscape, PageOrientation.Arbitrary };

        public static PageOrientation NextPageOrientation(this Random rnd)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }
            return _pageOrientations[rnd.Next(_pageOrientations.Length)];
        }
    }
}
