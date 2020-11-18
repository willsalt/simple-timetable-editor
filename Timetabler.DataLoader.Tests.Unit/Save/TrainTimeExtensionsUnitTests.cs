using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Data.Tests.Utility.Extensions;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class TrainTimeExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static TrainTime GetTestObject()
        {
            int noteCount = _rnd.Next(4);
            List<Note> notes = new List<Note>(noteCount);
            for (int i = 0; i < noteCount; ++i)
            {
                notes.Add(_rnd.NextNote());
            }
            TrainTime tt = new TrainTime { Time = _rnd.NextTimeOfDay(), };
            tt.Footnotes.AddRange(notes);
            return tt;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainTimeExtensionsClass_ToTrainTimeModelMethod_ThrowsArgumentNullException_WhenParameterIsNull()
        {
            TrainTime testParam = null;

            _ = testParam.ToTrainTimeModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToTrainTimeModelMethod_ReturnsObjectWithAtPropertyWithCorrectTimeProperty_WhenParameterHasTimePropertyThatIsNotNull()
        {
            TrainTime testParam = GetTestObject();

            TrainTimeModel testOutput = testParam.ToTrainTimeModel();

            string expectedValue = testParam.Time.Hours24.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                testParam.Time.Minutes.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                testParam.Time.Seconds.ToString("d2", CultureInfo.InvariantCulture);
            Assert.AreEqual(expectedValue, testOutput.At.Time);
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToTrainTimeModelMethod_ReturnsObjectWithAtPropertyThatIsNull_WhenParameterHasTimePropertyThatIsNull()
        {
            TrainTime testParam = GetTestObject();
            testParam.Time = null;

            TrainTimeModel testOutput = testParam.ToTrainTimeModel();

            Assert.IsNull(testOutput.At);
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToTrainTimeModelMethod_ReturnsObjectWithFootnoteIdsPropertyOfCorrectLength_WhenParameterIsNotNull()
        {
            TrainTime testParam = GetTestObject();

            TrainTimeModel testOutput = testParam.ToTrainTimeModel();

            Assert.AreEqual(testParam.Footnotes.Count, testOutput.FootnoteIds.Count);
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToTrainTimeModelMethod_ReturnsObjectWithFootnoteIdsPropertyContainingCorrectValues_WhenParameterIsNotNull()
        {
            TrainTime testParam = GetTestObject();

            TrainTimeModel testOutput = testParam.ToTrainTimeModel();

            string[] outputIds = testOutput.FootnoteIds.ToArray();
            for (int i = 0; i < testParam.Footnotes.Count; ++i)
            {
                Assert.AreEqual(testParam.Footnotes[i].Id, outputIds[i]);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
