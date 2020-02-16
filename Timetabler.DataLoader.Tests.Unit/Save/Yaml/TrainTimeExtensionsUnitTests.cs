using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Data.Tests.Utility.Extensions;
using Timetabler.DataLoader.Save.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
{
    [TestClass]
    public class TrainTimeExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

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

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TrainTimeExtensionsClass_ToYamlTrainTimeModelMethod_ThrowsNullReferenceException_WhenParameterIsNull()
        {
            TrainTime testParam = null;

            _ = testParam.ToYamlTrainTimeModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToYamlTrainTimeModelMethod_ReturnsObjectWithAtPropertyWithCorrectTimeProperty_WhenParameterHasTimePropertyThatIsNotNull()
        {
            TrainTime testParam = GetTestObject();

            TrainTimeModel testOutput = testParam.ToYamlTrainTimeModel();

            string expectedValue = testParam.Time.Hours24.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                testParam.Time.Minutes.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                testParam.Time.Seconds.ToString("d2", CultureInfo.InvariantCulture);
            Assert.AreEqual(expectedValue, testOutput.At.Time);
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToYamlTrainTimeModelMethod_ReturnsObjectWithAtPropertyThatIsNull_WhenParameterHasTimePropertyThatIsNull()
        {
            TrainTime testParam = GetTestObject();
            testParam.Time = null;

            TrainTimeModel testOutput = testParam.ToYamlTrainTimeModel();

            Assert.IsNull(testOutput.At);
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToYamlTrainTimeModelMethod_ReturnsObjectWithFootnoteIdsPropertyOfCorrectLength_WhenParameterIsNotNull()
        {
            TrainTime testParam = GetTestObject();

            TrainTimeModel testOutput = testParam.ToYamlTrainTimeModel();

            Assert.AreEqual(testParam.Footnotes.Count, testOutput.FootnoteIds.Count);
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToYamlTrainTimeModelMethod_ReturnsObjectWithFootnoteIdsPropertyContainingCorrectValues_WhenParameterIsNotNull()
        {
            TrainTime testParam = GetTestObject();

            TrainTimeModel testOutput = testParam.ToYamlTrainTimeModel();

            for (int i = 0; i < testParam.Footnotes.Count; ++i)
            {
                Assert.AreEqual(testParam.Footnotes[i].Id, testOutput.FootnoteIds[i]);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
