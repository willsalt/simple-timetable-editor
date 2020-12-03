using System;
using System.Diagnostics.CodeAnalysis;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Utility.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class SignalboxHoursHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

        public static SignalboxHours GetSignalboxHours(Signalbox box) => new SignalboxHours
        {
            Signalbox = box,
            StartTime = _rnd.NextTimeOfDay(),
            EndTime = _rnd.NextTimeOfDay(),
            TokenBalanceWarning = _rnd.NextBoolean(),
        };
    }
}
