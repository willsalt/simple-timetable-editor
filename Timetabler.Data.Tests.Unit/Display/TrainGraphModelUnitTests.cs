using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;
using Timetabler.Data.Events;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TrainGraphModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TrainGraphModel GetTrainGraphModel()
        {
            return new TrainGraphModel(null, null)
            {
                DisplayTrainLabels = _rnd.NextBoolean(),
                GraphEditStyle = _rnd.NextBoolean() ? GraphEditStyle.Free : GraphEditStyle.PreserveSectionTimes,
                TooltipFormattingString = _rnd.NextString(_rnd.Next(5)),
            };
        }

        private static DocumentOptions GetDocumentOptions()
        {
            return new DocumentOptions
            {
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean(),
                ClockType = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock,
                GraphEditStyle = _rnd.NextBoolean() ? GraphEditStyle.Free : GraphEditStyle.PreserveSectionTimes
            };
        }

        [TestMethod]
        public void TrainGraphModelClassSetPropertiesFromDocumentOptionsMethodSetsDisplayTrainLabelsPropertyToEqualDisplayTrainLabelsOnGraphsPropertyOfParameter()
        {
            DocumentOptions testSource = GetDocumentOptions();
            TrainGraphModel testObject = GetTrainGraphModel();

            testObject.SetPropertiesFromDocumentOptions(testSource);

            Assert.AreEqual(testSource.DisplayTrainLabelsOnGraphs, testObject.DisplayTrainLabels);
        }

        [TestMethod]
        public void TrainGraphModelClassSetPropertiesFromDocumentOptionsMethodDoesNotCrashIfParameterIsNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();

            testObject.SetPropertiesFromDocumentOptions(null);
        }

        [TestMethod]
        public void TrainGraphModelClassSetPropertiesFromDocumentOptionsMethodDoesNotChangeDisplayTrainLabelsPropertyIfParameterIsNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            bool displayLabels = testObject.DisplayTrainLabels;

            testObject.SetPropertiesFromDocumentOptions(null);

            Assert.AreEqual(displayLabels, testObject.DisplayTrainLabels);
        }

        [TestMethod]
        public void TrainGraphModelClassSetPropertiesFromDocumentOptionsMethodDoesNotChangeGraphEditStylePropertyIfParameterIsNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            GraphEditStyle graphEditStyle = testObject.GraphEditStyle;

            testObject.SetPropertiesFromDocumentOptions(null);

            Assert.AreEqual(graphEditStyle, testObject.GraphEditStyle);
        }

        [TestMethod]
        public void TrainGraphModelClassSetPropertiesFromDocumentOptionsMethodDoesNotChangeTooltipFormattingStringPropertyIfParameterIsNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            string ttf = testObject.TooltipFormattingString;

            testObject.SetPropertiesFromDocumentOptions(null);

            Assert.AreEqual(ttf, testObject.TooltipFormattingString);
        }

        [TestMethod]
        public void TrainGraphModelClassSetPropertiesFromDocumentOptionsMethodSetsGraphEditStylePropertyToEqualGraphEditStylePropertyOfParameter()
        {
            DocumentOptions testSource = GetDocumentOptions();
            TrainGraphModel testObject = GetTrainGraphModel();

            testObject.SetPropertiesFromDocumentOptions(testSource);

            Assert.AreEqual(testSource.GraphEditStyle, testObject.GraphEditStyle);
        }

        [TestMethod]
        public void TrainGraphModelClassSetPropertiesFromDocumentOptionsMethodSetsTooltipFormattingStringPropertyToEqualTooltipPropertyOfFormattingStringsPropertyOfParameter()
        {
            DocumentOptions testSource = GetDocumentOptions();
            TrainGraphModel testObject = GetTrainGraphModel();

            testObject.SetPropertiesFromDocumentOptions(testSource);

            Assert.AreEqual(testSource.FormattingStrings.Tooltip, testObject.TooltipFormattingString);
        }

        [TestMethod]
        public void TrainGraphModelClassSelectedTrainPropertyHasConventionalPersistence()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            Train testSelection = new Train();

            testObject.SelectedTrain = testSelection;
            Train testOutput = testObject.SelectedTrain;

            Assert.AreSame(testSelection, testOutput);
        }

        [TestMethod]
        public void TrainGraphModelClassSelectedTrainPropertySetMethodFiresEventWhenPropertyIsSetToDifferentValue()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            List<TrainEventArgs> capturedEventArgs = new List<TrainEventArgs>();
            List<object> capturedSenders = new List<object>();
            testObject.SelectedTrainChanged += (s, e) => { capturedSenders.Add(s); capturedEventArgs.Add(e); };
            Train testSelection = new Train();

            testObject.SelectedTrain = testSelection;

            Assert.AreEqual(1, capturedSenders.Count);
            Assert.AreSame(testObject, capturedSenders[0]);
            Assert.AreEqual(1, capturedEventArgs.Count);
            Assert.AreSame(testSelection, capturedEventArgs[0].Train);
        }

        [TestMethod]
        public void TrainGraphModelClassSelectedTrainPropertySetMethodDoesNotFireEventWhenPropertyIsSetToSameValue()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            List<TrainEventArgs> capturedEventArgs = new List<TrainEventArgs>();
            List<object> capturedSenders = new List<object>();
            Train testSelection = new Train();
            testObject.SelectedTrain = testSelection;
            testObject.SelectedTrainChanged += (s, e) => { capturedSenders.Add(s); capturedEventArgs.Add(e); };
            
            testObject.SelectedTrain = testSelection;

            Assert.AreEqual(0, capturedSenders.Count);
            Assert.AreEqual(0, capturedEventArgs.Count);
        }

        [TestMethod]
        public void TrainGraphModelClassSelectedTrainPropertySetMethodFiresEventWhenPropertyIsNotNullAndIsSetToNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            List<TrainEventArgs> capturedEventArgs = new List<TrainEventArgs>();
            List<object> capturedSenders = new List<object>();
            Train testSelection = new Train();
            testObject.SelectedTrain = testSelection;
            testObject.SelectedTrainChanged += (s, e) => { capturedSenders.Add(s); capturedEventArgs.Add(e); };

            testObject.SelectedTrain = null;

            Assert.AreEqual(1, capturedSenders.Count);
            Assert.AreSame(testObject, capturedSenders[0]);
            Assert.AreEqual(1, capturedEventArgs.Count);
            Assert.IsNull(capturedEventArgs[0].Train);
        }

        [TestMethod]
        public void TrainGraphModelClassSelectedTrainPropertySetMethodDoesNotFireEventWhenPropertyIsNullAndIsSetToNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            List<TrainEventArgs> capturedEventArgs = new List<TrainEventArgs>();
            List<object> capturedSenders = new List<object>();
            testObject.SelectedTrainChanged += (s, e) => { capturedSenders.Add(s); capturedEventArgs.Add(e); };

            testObject.SelectedTrain = null;

            Assert.AreEqual(0, capturedSenders.Count);
            Assert.AreEqual(0, capturedEventArgs.Count);
        }
    }
}
