using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Extensions;

namespace Timetabler.Tests.Unit.Extensions
{
    [TestClass]
    public class ClockTypeExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void ClockTypeExtensionsClass_SetControlsVisibleIn12HourModeMethod_DoesNotCrash_IfSecondParameterIsNull()
        {
            ClockType testValue = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;
            IList<Control> testParam1 = null;

            testValue.SetControlsVisibleIn12HourMode(testParam1);
        }
    }
}
