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

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainGraphModelClass_SetPropertiesFromDocumentOptionsMethod_SetsDisplayTrainLabelsPropertyToEqualDisplayTrainLabelsOnGraphsPropertyOfParameter()
        {
            DocumentOptions testSource = GetDocumentOptions();
            TrainGraphModel testObject = GetTrainGraphModel();

            testObject.SetPropertiesFromDocumentOptions(testSource);

            Assert.AreEqual(testSource.DisplayTrainLabelsOnGraphs, testObject.DisplayTrainLabels);
        }

        [TestMethod]
        public void TrainGraphModelClass_SetPropertiesFromDocumentOptionsMethod_DoesNotCrash_IfParameterIsNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();

            testObject.SetPropertiesFromDocumentOptions(null);
        }

        [TestMethod]
        public void TrainGraphModelClass_SetPropertiesFromDocumentOptionsMethod_DoesNotChangeDisplayTrainLabelsProperty_IfParameterIsNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            bool displayLabels = testObject.DisplayTrainLabels;

            testObject.SetPropertiesFromDocumentOptions(null);

            Assert.AreEqual(displayLabels, testObject.DisplayTrainLabels);
        }

        [TestMethod]
        public void TrainGraphModelClass_SetPropertiesFromDocumentOptionsMethod_DoesNotChangeGraphEditStyleProperty_IfParameterIsNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            GraphEditStyle graphEditStyle = testObject.GraphEditStyle;

            testObject.SetPropertiesFromDocumentOptions(null);

            Assert.AreEqual(graphEditStyle, testObject.GraphEditStyle);
        }

        [TestMethod]
        public void TrainGraphModelClass_SetPropertiesFromDocumentOptionsMethod_DoesNotChangeTooltipFormattingStringProperty_IfParameterIsNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            string ttf = testObject.TooltipFormattingString;

            testObject.SetPropertiesFromDocumentOptions(null);

            Assert.AreEqual(ttf, testObject.TooltipFormattingString);
        }

        [TestMethod]
        public void TrainGraphModelClass_SetPropertiesFromDocumentOptionsMethod_SetsGraphEditStylePropertyToEqualGraphEditStylePropertyOfParameter()
        {
            DocumentOptions testSource = GetDocumentOptions();
            TrainGraphModel testObject = GetTrainGraphModel();

            testObject.SetPropertiesFromDocumentOptions(testSource);

            Assert.AreEqual(testSource.GraphEditStyle, testObject.GraphEditStyle);
        }

        [TestMethod]
        public void TrainGraphModelClass_SetPropertiesFromDocumentOptionsMethod_SetsTooltipFormattingStringPropertyToEqualTooltipPropertyOfFormattingStringsPropertyOfParameter()
        {
            DocumentOptions testSource = GetDocumentOptions();
            TrainGraphModel testObject = GetTrainGraphModel();

            testObject.SetPropertiesFromDocumentOptions(testSource);

            Assert.AreEqual(testSource.FormattingStrings.Tooltip, testObject.TooltipFormattingString);
        }

        [TestMethod]
        public void TrainGraphModelClass_SelectedTrainProperty_HasConventionalPersistence()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            Train testSelection = new Train();

            testObject.SelectedTrain = testSelection;
            Train testOutput = testObject.SelectedTrain;

            Assert.AreSame(testSelection, testOutput);
        }

        [TestMethod]
        public void TrainGraphModelClass_SelectedTrainPropertySetMethod_FiresEvent_IfPropertyIsSetToDifferentValue()
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
        public void TrainGraphModelClass_SelectedTrainPropertySetMethod_DoesNotFireEvent_IfPropertyIsSetToSameValue()
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
        public void TrainGraphModelClass_SelectedTrainPropertySetMethod_FiresEvent_IfPropertyIsNotNullAndIsSetToNull()
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
        public void TrainGraphModelClass_SelectedTrainPropertySetMethod_DoesNotFireEvent_IfPropertyIsNullAndIsSetToNull()
        {
            TrainGraphModel testObject = GetTrainGraphModel();
            List<TrainEventArgs> capturedEventArgs = new List<TrainEventArgs>();
            List<object> capturedSenders = new List<object>();
            testObject.SelectedTrainChanged += (s, e) => { capturedSenders.Add(s); capturedEventArgs.Add(e); };

            testObject.SelectedTrain = null;

            Assert.AreEqual(0, capturedSenders.Count);
            Assert.AreEqual(0, capturedEventArgs.Count);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
