using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData.Helpers;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class SignalboxHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

        public static Signalbox GetSignalbox()
        {
            return new Signalbox
            {
                Id = GeneralHelper.GetNewId(Array.Empty<Signalbox>()),
                Code = _rnd.NextString(_rnd.Next(1, 4)),
                EditorDisplayName = _rnd.NextString(_rnd.Next(128)),
                ExportDisplayName = _rnd.NextString(_rnd.Next(128))
            };
        }

        public static List<Signalbox> GetSignalboxList(int min, int max)
        {
            int count = _rnd.Next(min, max);
            List<Signalbox> output = new List<Signalbox>(count);
            for (int i = 0; i < count; ++i)
            {
                output.Add(GetSignalbox());
            }
            return output;
        }
    }
}
