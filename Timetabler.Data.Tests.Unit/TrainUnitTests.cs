using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Tests.Unit.TestHelpers;
using Timetabler.Data.Tests.Unit.TestHelpers.Extensions;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TrainUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static Train GetTrain(bool? withToWork = null, bool? withLocoToWork = null, int? minutesBeforeMidnight = null)
        {
            TimeOfDay beforeMidnight;
            if (!minutesBeforeMidnight.HasValue)
            {
                beforeMidnight = new TimeOfDay(86399);
            }
            else
            {
                beforeMidnight = new TimeOfDay(86399 - (minutesBeforeMidnight.Value * 60));
            }
            Train t = new Train
            {
                Headcode = _rnd.NextString(_rnd.Next(2, 5)),
                LocoDiagram = _rnd.NextString(_rnd.Next(2, 5)),
                TrainClass = GetTrainClass(),
                IncludeSeparatorAbove = _rnd.NextBoolean(),
                IncludeSeparatorBelow = _rnd.NextBoolean(),
                InlineNote = _rnd.NextString(_rnd.Next(100)),
                GraphProperties = GetGraphTrainProperties(),
            };
            t.TrainTimes.AddRange(GetTrainLocationTimeList(2, 20, beforeMidnight));
            t.TrainClassId = t.TrainClass.Id;
            if (withToWork ?? _rnd.NextBoolean())
            {
                t.ToWork = GetToWork();
            }
            if (withLocoToWork ?? _rnd.NextBoolean())
            {
                t.LocoToWork = GetToWork();
            }
            return t;
        }

        private static TrainClass GetTrainClass()
        {
            return new TrainClass
            {
                Description = _rnd.NextString(_rnd.Next(1, 50)),
                Id = _rnd.NextHexString(8),
                TableCode = _rnd.NextString(2),
            };
        }

        private static ToWork GetToWork()
        {
            return new ToWork
            {
                AtTime = _rnd.NextTimeOfDay(),
                Text = _rnd.NextBoolean() ? _rnd.NextString(_rnd.Next(4)) : null,
            };
        }

        private static GraphTrainProperties GetGraphTrainProperties()
        {
            return new GraphTrainProperties
            {
                Colour = _rnd.NextColor(),
                DashStyle = _rnd.NextDashStyle(),
                Width = (float)(_rnd.NextDouble() * _rnd.Next(1, 4)),
            };
        }

        private static List<TrainLocationTime> GetTrainLocationTimeList(int min, int max, TimeOfDay beforeTime)
        {
            int count = _rnd.Next(min, max);
            List<TrainLocationTime> items = new List<TrainLocationTime>(count);
            for (int i = 0; i < count; ++i)
            {
                TrainLocationTime item = GetTrainLocationTime(beforeTime);
                items.Add(item);
            }
            return items;
        }

        private static TrainLocationTime GetTrainLocationTime(TimeOfDay beforeTime)
        {
            return new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTimeBefore(beforeTime),
                DepartureTime = TrainTimeHelpers.GetTrainTimeBefore(beforeTime),
                FormattingStrings = new TimeDisplayFormattingStrings
                {
                    Complete = "h{0}mmf",
                    Hours = "h",
                    Minutes = "mmf",
                    TimeWithoutFootnotes = "h mmf",
                },
                Line = _rnd.NextString(_rnd.Next(2)),
                Location = new Location(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithSameHeadcodeProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Headcode, testOutput.Headcode);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithSameLocoDiagramProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocoDiagram, testOutput.LocoDiagram);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithSameTrainClassProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreSame(testObject.TrainClass, testOutput.TrainClass);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithSameTrainClassIdProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TrainClassId, testOutput.TrainClassId);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithSameIncludeSeparatorAboveProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IncludeSeparatorAbove, testOutput.IncludeSeparatorAbove);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithSameIncludeSeparatorBelowProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IncludeSeparatorBelow, testOutput.IncludeSeparatorBelow);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithSameInlineNoteProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.InlineNote, testOutput.InlineNote);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithGraphPropertiesPropertyWithSameColourProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphProperties.Colour, testOutput.GraphProperties.Colour);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithGraphPropertiesPropertyWithSameDashStyleProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphProperties.DashStyle, testOutput.GraphProperties.DashStyle);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithGraphPropertiesPropertyWithSameWidthProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphProperties.Width, testOutput.GraphProperties.Width);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithCorrectToWorkProperty_IfToWorkPropertyIsNull()
        {
            Train testObject = GetTrain(false);

            Train testOutput = testObject.Copy();

            Assert.IsNull(testOutput.ToWork);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithToWorkPropertyThatIsNotTheSameObject_IfToWorkIsNotNull()
        {
            Train testObject = GetTrain(true);

            Train testOutput = testObject.Copy();

            Assert.AreNotSame(testObject.ToWork, testOutput.ToWork);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithToWorkPropertyWithCorrectAtTimeProperty_IfToWorkIsNotNull()
        {
            Train testObject = GetTrain(true);

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ToWork.AtTime, testOutput.ToWork.AtTime);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithToWorkPropertyWithCorrectTextProperty_IfToWorkIsNotNull()
        {
            Train testObject = GetTrain(true);

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ToWork.Text, testOutput.ToWork.Text);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithCorrectLocoToWorkProperty_IfLocoToWorkPropertyIsNull()
        {
            Train testObject = GetTrain(_rnd.NextBoolean(), false);

            Train testOutput = testObject.Copy();

            Assert.IsNull(testOutput.LocoToWork);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithLocoToWorkPropertyThatIsNotTheSameObject_IfLocoToWorkIsNotNull()
        {
            Train testObject = GetTrain(_rnd.NextBoolean(), true);

            Train testOutput = testObject.Copy();

            Assert.AreNotSame(testObject.LocoToWork, testOutput.LocoToWork);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithLocoToWorkPropertyWithCorrectAtTimeProperty_IfLocoToWorkIsNotNull()
        {
            Train testObject = GetTrain(_rnd.NextBoolean(), true);

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocoToWork.AtTime, testOutput.LocoToWork.AtTime);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithLocoToWorkPropertyWithCorrectTextProperty_IfLocoToWorkIsNotNull()
        {
            Train testObject = GetTrain(_rnd.NextBoolean(), true);

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocoToWork.Text, testOutput.LocoToWork.Text);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyOfCorrectLength()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TrainTimes.Count, testOutput.TrainTimes.Count);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimeWithCorrectTimeProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].ArrivalTime.Time, testOutput.TrainTimes[i].ArrivalTime.Time);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimePropertyWithCorrectNumberOfFootnotes()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].ArrivalTime.Footnotes.Count, testOutput.TrainTimes[i].ArrivalTime.Footnotes.Count);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimePropertyWithSameFootnotes()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                for (int j = 0; j < testOutput.TrainTimes[i].ArrivalTime.Footnotes.Count; ++j)
                {
                    Assert.AreSame(testObject.TrainTimes[i].ArrivalTime.Footnotes[j], testOutput.TrainTimes[i].ArrivalTime.Footnotes[j]);
                }
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimeWithCorrectTimeProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].DepartureTime.Time, testOutput.TrainTimes[i].DepartureTime.Time);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimePropertyWithCorrectNumberOfFootnotes()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].DepartureTime.Footnotes.Count, testOutput.TrainTimes[i].DepartureTime.Footnotes.Count);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimePropertyWithSameFootnotes()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                for (int j = 0; j < testOutput.TrainTimes[i].DepartureTime.Footnotes.Count; ++j)
                {
                    Assert.AreSame(testObject.TrainTimes[i].DepartureTime.Footnotes[j], testOutput.TrainTimes[i].DepartureTime.Footnotes[j]);
                }
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingSameLocationProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreSame(testObject.TrainTimes[i].Location, testOutput.TrainTimes[i].Location);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPassProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Pass, testOutput.TrainTimes[i].Pass);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPathProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Path, testOutput.TrainTimes[i].Path);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPlatformProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Platform, testOutput.TrainTimes[i].Platform);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualLineProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Line, testOutput.TrainTimes[i].Line);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualFormattingStringsProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].FormattingStrings, testOutput.TrainTimes[i].FormattingStrings);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithFootnotesPropertyOfCorrectLength()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Footnotes.Count, testOutput.Footnotes.Count);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithNoParameters_ReturnsObjectWithFootnotesPropertyWithCorrectContents()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testObject.Footnotes.Count; ++i)
            {
                Assert.AreSame(testObject.Footnotes[i], testOutput.Footnotes[i]);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithSameHeadcodeProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.Headcode, testOutput.Headcode);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithSameLocoDiagramProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.LocoDiagram, testOutput.LocoDiagram);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithSameTrainClassProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreSame(testObject.TrainClass, testOutput.TrainClass);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithSameTrainClassIdProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.TrainClassId, testOutput.TrainClassId);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithSameIncludeSeparatorAboveProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.IncludeSeparatorAbove, testOutput.IncludeSeparatorAbove);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithSameIncludeSeparatorBelowProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.IncludeSeparatorBelow, testOutput.IncludeSeparatorBelow);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithSameInlineNoteProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.InlineNote, testOutput.InlineNote);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithGraphPropertiesPropertyWithSameColourProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.GraphProperties.Colour, testOutput.GraphProperties.Colour);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithGraphPropertiesPropertyWithSameDashStyleProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.GraphProperties.DashStyle, testOutput.GraphProperties.DashStyle);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithGraphPropertiesPropertyWithSameWidthProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.GraphProperties.Width, testOutput.GraphProperties.Width);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithCorrectToWorkProperty_IfToWorkPropertyIsNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(false, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.IsNull(testOutput.ToWork);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithToWorkPropertyThatIsNotTheSameObject_IfToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(true, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreNotSame(testObject.ToWork, testOutput.ToWork);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithToWorkPropertyWithCorrectAtTimeProperty_IfToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(true, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.ToWork.AtTime, testOutput.ToWork.AtTime);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithToWorkPropertyWithCorrectTextProperty_IfToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(true, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.ToWork.Text, testOutput.ToWork.Text);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithCorrectLocoToWorkProperty_IfLocoToWorkPropertyIsNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, false, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.IsNull(testOutput.LocoToWork);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithLocoToWorkPropertyThatIsNotTheSameObject_IfLocoToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, true, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreNotSame(testObject.LocoToWork, testOutput.LocoToWork);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithLocoToWorkPropertyWithCorrectAtTimeProperty_IfLocoToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, true, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.LocoToWork.AtTime, testOutput.LocoToWork.AtTime);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithLocoToWorkPropertyWithCorrectTextProperty_IfLocoToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, true, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.LocoToWork.Text, testOutput.LocoToWork.Text);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyOfCorrectLength()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.TrainTimes.Count, testOutput.TrainTimes.Count);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimeWithCorrectTimeProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].ArrivalTime.Time + new TimeSpan(0, offsetMinutes, 0), testOutput.TrainTimes[i].ArrivalTime.Time);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimePropertyWithCorrectNumberOfFootnotes()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].ArrivalTime.Footnotes.Count, testOutput.TrainTimes[i].ArrivalTime.Footnotes.Count);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimePropertyWithSameFootnotes()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                for (int j = 0; j < testOutput.TrainTimes[i].ArrivalTime.Footnotes.Count; ++j)
                {
                    Assert.AreSame(testObject.TrainTimes[i].ArrivalTime.Footnotes[j], testOutput.TrainTimes[i].ArrivalTime.Footnotes[j]);
                }
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimeWithCorrectTimeProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].DepartureTime.Time + new TimeSpan(0, offsetMinutes, 0), testOutput.TrainTimes[i].DepartureTime.Time);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimePropertyWithCorrectNumberOfFootnotes()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].DepartureTime.Footnotes.Count, testOutput.TrainTimes[i].DepartureTime.Footnotes.Count);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimePropertyWithSameFootnotes()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                for (int j = 0; j < testOutput.TrainTimes[i].DepartureTime.Footnotes.Count; ++j)
                {
                    Assert.AreSame(testObject.TrainTimes[i].DepartureTime.Footnotes[j], testOutput.TrainTimes[i].DepartureTime.Footnotes[j]);
                }
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingSameLocationProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreSame(testObject.TrainTimes[i].Location, testOutput.TrainTimes[i].Location);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPassProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Pass, testOutput.TrainTimes[i].Pass);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPathProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Path, testOutput.TrainTimes[i].Path);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPlatformProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Platform, testOutput.TrainTimes[i].Platform);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualLineProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Line, testOutput.TrainTimes[i].Line);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualFormattingStringsProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].FormattingStrings, testOutput.TrainTimes[i].FormattingStrings);
            }
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithFootnotesPropertyOfCorrectLength()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.Footnotes.Count, testOutput.Footnotes.Count);
        }

        [TestMethod]
        public void TrainClass_CopyMethodWithIntParameter_ReturnsObjectWithFootnotesPropertyWithCorrectContents()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testObject.Footnotes.Count; ++i)
            {
                Assert.AreSame(testObject.Footnotes[i], testOutput.Footnotes[i]);
            }
        }

        [TestMethod]
        public void TrainClass_LastTrainTimeProperty_IsNull_IfObjectTrainTimesPropertyIsEmpty()
        {
            Train testObject = GetTrain();
            testObject.TrainTimes.Clear();

            TrainTime testOutput = testObject.LastTrainTime;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainClass_LastTrainTimeProperty_IsLaterThanOrEqualToAllArrivalTimes()
        {
            Train testObject = GetTrain();

            TrainTime testOutput = testObject.LastTrainTime;

            foreach (TrainLocationTime tlt in testObject.TrainTimes)
            {
                Assert.IsTrue(tlt.ArrivalTime?.Time == null || tlt.ArrivalTime.Time <= testOutput.Time);
            }
        }

        [TestMethod]
        public void TrainClass_LastTrainTimeProperty_IsLaterThanOrEqualToAllDepartureTimes()
        {
            Train testObject = GetTrain();

            TrainTime testOutput = testObject.LastTrainTime;

            foreach (TrainLocationTime tlt in testObject.TrainTimes)
            {
                Assert.IsTrue(tlt.DepartureTime?.Time == null || tlt.DepartureTime.Time <= testOutput.Time);
            }
        }

        [TestMethod]
        public void TrainClass_ReverseMethod_DoesNotChangeNumberOfTimingPoints()
        {
            Train testObject = GetTrain();
            int originalTimingPointCount = testObject.TrainTimes.Count;

            testObject.Reverse();

            Assert.AreEqual(originalTimingPointCount, testObject.TrainTimes.Count);
        }

        [TestMethod]
        public void TrainClass_ReverseMethod_DoesNotChangeObjectReferencesContainedInTrainTimesProperty()
        {
            Train testObject = GetTrain();
            List<TrainLocationTime> originalTrainTimes = testObject.TrainTimes.ToList();

            testObject.Reverse();

            foreach (TrainLocationTime tlt in testObject.TrainTimes)
            {
                Assert.IsTrue(originalTrainTimes.Contains(tlt));
                originalTrainTimes.Remove(tlt);
            }
        }

        [TestMethod]
        public void TrainClass_ReverseMethod_ChangesAllTrainTimesNotEqualToTheLatestTrainTime()
        {
            Train testObject = GetTrain();
            TrainTime originalLastTrainTime = testObject.LastTrainTime.Copy();
            List<TimeOfDay> allTimes = new List<TimeOfDay>();
            allTimes.AddRange(testObject.TrainTimes.Select(tlt => tlt.ArrivalTime.Time));
            allTimes.AddRange(testObject.TrainTimes.Select(tlt => tlt.DepartureTime.Time));

            testObject.Reverse();

            foreach (TrainLocationTime tlt in testObject.TrainTimes)
            {
                Assert.IsTrue(originalLastTrainTime.Time == tlt.ArrivalTime.Time || !allTimes.Contains(tlt.ArrivalTime.Time));
                Assert.IsTrue(originalLastTrainTime.Time == tlt.DepartureTime.Time || !allTimes.Contains(tlt.DepartureTime.Time));
            }
        }

        [TestMethod]
        public void TrainClass_ReverseMethod_ChangesAllTrainTimesToBeLaterThanTheOriginallyLastTrainTime()
        {
            Train testObject = GetTrain();
            TrainTime originalLastTrainTime = testObject.LastTrainTime.Copy();

            testObject.Reverse();

            foreach (TrainLocationTime tlt in testObject.TrainTimes)
            {
                Assert.IsTrue(originalLastTrainTime.Time <= tlt.ArrivalTime.Time);
                Assert.IsTrue(originalLastTrainTime.Time <= tlt.DepartureTime.Time);
            }
        }

        [TestMethod]
        public void TrainClass_ReverseMethod_LeavesAllTrainTimesOrderedByArrivalTime()
        {
            Train testObject = GetTrain();

            testObject.Reverse();

            for (int i = 1; i < testObject.TrainTimes.Count; ++i)
            {
                Assert.IsTrue(testObject.TrainTimes[i].ArrivalTime.Time >= testObject.TrainTimes[i - 1].ArrivalTime.Time);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainClass_ResolveFootnotesMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Train testObject = GetTrain();

            testObject.ResolveFootnotes(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainClass_ResolveFootnotesMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Train testObject = GetTrain();

            try
            {
                testObject.ResolveFootnotes(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("footnoteDictionary", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
