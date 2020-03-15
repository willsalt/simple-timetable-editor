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
    }
}
