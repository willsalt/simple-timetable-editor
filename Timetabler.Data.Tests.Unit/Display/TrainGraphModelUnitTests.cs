using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TrainGraphModelUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        private TrainGraphModel GetTrainGraphModel()
        {
            return new TrainGraphModel
            {
                DisplayTrainLabels = _rnd.NextBoolean(),
                GraphEditStyle = _rnd.NextBoolean() ? GraphEditStyle.Free : GraphEditStyle.PreserveSectionTimes,
                TooltipFormattingString = _rnd.NextString(_rnd.Next(5)),
            };
        }

        private DocumentOptions GetDocumentOptions()
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
    }
}
