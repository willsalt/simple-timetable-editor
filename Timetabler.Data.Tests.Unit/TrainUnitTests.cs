using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TrainUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        private Train GetTrain(bool? withToWork = null, bool? withLocoToWork = null, int? minutesBeforeMidnight = null)
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
                TrainTimes = GetTrainLocationTimeList(2, 20, beforeMidnight),
            };
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

        private TrainClass GetTrainClass()
        {
            return new TrainClass
            {
                Description = _rnd.NextString(_rnd.Next(1, 50)),
                Id = _rnd.NextHexString(8),
                TableCode = _rnd.NextString(2),
            };
        }

        private ToWork GetToWork()
        {
            return new ToWork
            {
                AtTime = _rnd.NextTimeOfDay(),
                Text = _rnd.NextBoolean() ? _rnd.NextString(_rnd.Next(4)) : null,
            };
        }

        private GraphTrainProperties GetGraphTrainProperties()
        {
            return new GraphTrainProperties
            {
                Colour = _rnd.NextColor(),
                DashStyle = _rnd.NextDashStyle(),
                Width = (float)(_rnd.NextDouble() * _rnd.Next(1, 4)),
            };
        }

        private List<TrainLocationTime> GetTrainLocationTimeList(int min, int max, TimeOfDay beforeTime)
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

        private TrainLocationTime GetTrainLocationTime(TimeOfDay beforeTime)
        {
            return new TrainLocationTime
            {
                ArrivalTime = GetTrainTime(beforeTime),
                DepartureTime = GetTrainTime(beforeTime),
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

        private TrainTime GetTrainTime(TimeOfDay beforeTime)
        {
            TrainTime tt = new TrainTime
            {
                Time = _rnd.NextTimeOfDayBefore(beforeTime),
            };
            int noteCount = _rnd.Next(3);
            for (int i = 0; i < noteCount; ++i)
            {
                tt.Footnotes.Add(NoteHelpers.GetNote());
            }
            return tt;
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithSameHeadcodeProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Headcode, testOutput.Headcode);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithSameLocoDiagramProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocoDiagram, testOutput.LocoDiagram);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithSameTrainClassProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreSame(testObject.TrainClass, testOutput.TrainClass);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithSameTrainClassIdProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TrainClassId, testOutput.TrainClassId);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithSameIncludeSeparatorAboveProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IncludeSeparatorAbove, testOutput.IncludeSeparatorAbove);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithSameIncludeSeparatorBelowProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IncludeSeparatorBelow, testOutput.IncludeSeparatorBelow);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithSameInlineNoteProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.InlineNote, testOutput.InlineNote);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithGraphPropertiesPropertyWithSameColourProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphProperties.Colour, testOutput.GraphProperties.Colour);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithGraphPropertiesPropertyWithSameDashStyleProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphProperties.DashStyle, testOutput.GraphProperties.DashStyle);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithGraphPropertiesPropertyWithSameWidthProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphProperties.Width, testOutput.GraphProperties.Width);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithCorrectToWorkPropertyIfToWorkPropertyIsNull()
        {
            Train testObject = GetTrain(false);

            Train testOutput = testObject.Copy();

            Assert.IsNull(testOutput.ToWork);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithToWorkPropertyThatIsNotTheSameObjectIfToWorkIsNotNull()
        {
            Train testObject = GetTrain(true);

            Train testOutput = testObject.Copy();

            Assert.AreNotSame(testObject.ToWork, testOutput.ToWork);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithToWorkPropertyWithCorrectAtTimePropertyIfToWorkIsNotNull()
        {
            Train testObject = GetTrain(true);

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ToWork.AtTime, testOutput.ToWork.AtTime);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithToWorkPropertyWithCorrectTextPropertyIfToWorkIsNotNull()
        {
            Train testObject = GetTrain(true);

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ToWork.Text, testOutput.ToWork.Text);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithCorrectLocoToWorkPropertyIfLocoToWorkPropertyIsNull()
        {
            Train testObject = GetTrain(_rnd.NextBoolean(), false);

            Train testOutput = testObject.Copy();

            Assert.IsNull(testOutput.LocoToWork);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithLocoToWorkPropertyThatIsNotTheSameObjectIfLocoToWorkIsNotNull()
        {
            Train testObject = GetTrain(_rnd.NextBoolean(), true);

            Train testOutput = testObject.Copy();

            Assert.AreNotSame(testObject.LocoToWork, testOutput.LocoToWork);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithLocoToWorkPropertyWithCorrectAtTimePropertyIfLocoToWorkIsNotNull()
        {
            Train testObject = GetTrain(_rnd.NextBoolean(), true);

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocoToWork.AtTime, testOutput.LocoToWork.AtTime);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithLocoToWorkPropertyWithCorrectTextPropertyIfLocoToWorkIsNotNull()
        {
            Train testObject = GetTrain(_rnd.NextBoolean(), true);

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocoToWork.Text, testOutput.LocoToWork.Text);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyOfCorrectLength()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TrainTimes.Count, testOutput.TrainTimes.Count);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimeWithCorrectTimeProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].ArrivalTime.Time, testOutput.TrainTimes[i].ArrivalTime.Time);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimePropertyWithCorrectNumberOfFootnotes()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].ArrivalTime.Footnotes.Count, testOutput.TrainTimes[i].ArrivalTime.Footnotes.Count);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimePropertyWithSameFootnotes()
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
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimeWithCorrectTimeProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].DepartureTime.Time, testOutput.TrainTimes[i].DepartureTime.Time);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimePropertyWithCorrectNumberOfFootnotes()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].DepartureTime.Footnotes.Count, testOutput.TrainTimes[i].DepartureTime.Footnotes.Count);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimePropertyWithSameFootnotes()
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
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingSameLocationProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreSame(testObject.TrainTimes[i].Location, testOutput.TrainTimes[i].Location);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPassProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Pass, testOutput.TrainTimes[i].Pass);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPathProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Path, testOutput.TrainTimes[i].Path);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPlatformProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Platform, testOutput.TrainTimes[i].Platform);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualLineProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].Line, testOutput.TrainTimes[i].Line);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualFormattingStringsProperty()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.TrainTimes.Count; ++i)
            {
                Assert.AreEqual(testObject.TrainTimes[i].FormattingStrings, testOutput.TrainTimes[i].FormattingStrings);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithFootnotesPropertyOfCorrectLength()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Footnotes.Count, testOutput.Footnotes.Count);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithNoParametersReturnsObjectWithFootnotesPropertyWithCorrectContents()
        {
            Train testObject = GetTrain();

            Train testOutput = testObject.Copy();

            for (int i = 0; i < testObject.Footnotes.Count; ++i)
            {
                Assert.AreSame(testObject.Footnotes[i], testOutput.Footnotes[i]);
            }
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithSameHeadcodeProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.Headcode, testOutput.Headcode);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithSameLocoDiagramProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.LocoDiagram, testOutput.LocoDiagram);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithSameTrainClassProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreSame(testObject.TrainClass, testOutput.TrainClass);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithSameTrainClassIdProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.TrainClassId, testOutput.TrainClassId);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithSameIncludeSeparatorAboveProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.IncludeSeparatorAbove, testOutput.IncludeSeparatorAbove);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithSameIncludeSeparatorBelowProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.IncludeSeparatorBelow, testOutput.IncludeSeparatorBelow);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithSameInlineNoteProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.InlineNote, testOutput.InlineNote);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithGraphPropertiesPropertyWithSameColourProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.GraphProperties.Colour, testOutput.GraphProperties.Colour);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithGraphPropertiesPropertyWithSameDashStyleProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.GraphProperties.DashStyle, testOutput.GraphProperties.DashStyle);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithGraphPropertiesPropertyWithSameWidthProperty()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.GraphProperties.Width, testOutput.GraphProperties.Width);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithCorrectToWorkPropertyIfToWorkPropertyIsNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(false, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.IsNull(testOutput.ToWork);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithToWorkPropertyThatIsNotTheSameObjectIfToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(true, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreNotSame(testObject.ToWork, testOutput.ToWork);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithToWorkPropertyWithCorrectAtTimePropertyIfToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(true, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.ToWork.AtTime, testOutput.ToWork.AtTime);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithToWorkPropertyWithCorrectTextPropertyIfToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(true, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.ToWork.Text, testOutput.ToWork.Text);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithCorrectLocoToWorkPropertyIfLocoToWorkPropertyIsNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, false, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.IsNull(testOutput.LocoToWork);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithLocoToWorkPropertyThatIsNotTheSameObjectIfLocoToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, true, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreNotSame(testObject.LocoToWork, testOutput.LocoToWork);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithLocoToWorkPropertyWithCorrectAtTimePropertyIfLocoToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, true, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.LocoToWork.AtTime, testOutput.LocoToWork.AtTime);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithLocoToWorkPropertyWithCorrectTextPropertyIfLocoToWorkIsNotNull()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, true, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.LocoToWork.Text, testOutput.LocoToWork.Text);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyOfCorrectLength()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.TrainTimes.Count, testOutput.TrainTimes.Count);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimeWithCorrectTimeProperty()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimePropertyWithCorrectNumberOfFootnotes()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingArrivalTimePropertyWithSameFootnotes()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimeWithCorrectTimeProperty()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimePropertyWithCorrectNumberOfFootnotes()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingDepartureTimePropertyWithSameFootnotes()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingSameLocationProperty()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPassProperty()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPathProperty()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualPlatformProperty()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualLineProperty()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithTrainTimesPropertyWithEachObjectHavingEqualFormattingStringsProperty()
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
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithFootnotesPropertyOfCorrectLength()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            Assert.AreEqual(testObject.Footnotes.Count, testOutput.Footnotes.Count);
        }

        [TestMethod]
        public void TrainClassCopyMethodWithIntParameterReturnsObjectWithFootnotesPropertyWithCorrectContents()
        {
            int offsetMinutes = _rnd.Next(23 * 60);
            Train testObject = GetTrain(null, null, offsetMinutes);

            Train testOutput = testObject.Copy(offsetMinutes);

            for (int i = 0; i < testObject.Footnotes.Count; ++i)
            {
                Assert.AreSame(testObject.Footnotes[i], testOutput.Footnotes[i]);
            }
        }
    }
}
