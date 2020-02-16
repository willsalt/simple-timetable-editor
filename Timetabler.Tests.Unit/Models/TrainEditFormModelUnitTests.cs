using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.Models;

namespace Timetabler.Tests.Unit.Models
{
    [TestClass]
    public class TrainEditFormModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private IEnumerable<Note> GetNotes()
        {
            int count = _rnd.Next(20);
            List<Note> data = new List<Note>(count);
            for (int i = 0; i < count; ++i)
            {
                data.Add(new Note());
            }
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainEditFormModelClass_Constructor_SetsValidLocationsPropertyToFirstParameter()
        {
            LocationCollection testParam0 = new LocationCollection();
            TrainClassCollection testParam1 = new TrainClassCollection();
            IEnumerable<Note> testParam2 = GetNotes();
            IEnumerable<Note> testParam3 = GetNotes();

            TrainEditFormModel testOutput = new TrainEditFormModel(testParam0, testParam1, testParam2, testParam3);

            Assert.AreSame(testParam0, testOutput.ValidLocations);
        }

        [TestMethod]
        public void TrainEditFormModelClass_Constructor_SetsValidClassesPropertyToSecondParameter()
        {
            LocationCollection testParam0 = new LocationCollection();
            TrainClassCollection testParam1 = new TrainClassCollection();
            IEnumerable<Note> testParam2 = GetNotes();
            IEnumerable<Note> testParam3 = GetNotes();

            TrainEditFormModel testOutput = new TrainEditFormModel(testParam0, testParam1, testParam2, testParam3);

            Assert.AreSame(testParam1, testOutput.ValidClasses);
        }

        [TestMethod]
        public void TrainEditFormModelClass_Constructor_SetsValidTrainNotesToEmptyList_IfThirdParameterIsNull()
        {
            LocationCollection testParam0 = new LocationCollection();
            TrainClassCollection testParam1 = new TrainClassCollection();
            IEnumerable<Note> testParam2 = null;
            IEnumerable<Note> testParam3 = GetNotes();

            TrainEditFormModel testOutput = new TrainEditFormModel(testParam0, testParam1, testParam2, testParam3);

            Assert.IsNotNull(testOutput.ValidTrainNotes);
            Assert.AreEqual(0, testOutput.ValidTrainNotes.Count);
        }

        [TestMethod]
        public void TrainEditFormModelClass_Constructor_SetsValidTrainNotesToListContainingSameDataAsThirdParameter_IfThirdParameterIsNotNull()
        {
            LocationCollection testParam0 = new LocationCollection();
            TrainClassCollection testParam1 = new TrainClassCollection();
            IEnumerable<Note> testParam2 = GetNotes();
            IEnumerable<Note> testParam3 = GetNotes();

            TrainEditFormModel testOutput = new TrainEditFormModel(testParam0, testParam1, testParam2, testParam3);

            Note[] testParamData = testParam2.ToArray();
            Assert.AreEqual(testParamData.Length, testOutput.ValidTrainNotes.Count);
            for (int i = 0; i < testParamData.Length; ++i)
            {
                Assert.AreSame(testParamData[i], testOutput.ValidTrainNotes[i]);
            }
        }

        [TestMethod]
        public void TrainEditFormModelClass_Constructor_SetsValidTimingPointNotesToEmptyList_IfFourthParameterIsNull()
        {
            LocationCollection testParam0 = new LocationCollection();
            TrainClassCollection testParam1 = new TrainClassCollection();
            IEnumerable<Note> testParam2 = GetNotes();
            IEnumerable<Note> testParam3 = null;

            TrainEditFormModel testOutput = new TrainEditFormModel(testParam0, testParam1, testParam2, testParam3);

            Assert.IsNotNull(testOutput.ValidTimingPointNotes);
            Assert.AreEqual(0, testOutput.ValidTimingPointNotes.Count);
        }

        [TestMethod]
        public void TrainEditFormModelClass_Constructor_SetsValidTimingPointNotesToListContainingSameDataAsThirdParameter_IfFourthParameterIsNotNull()
        {
            LocationCollection testParam0 = new LocationCollection();
            TrainClassCollection testParam1 = new TrainClassCollection();
            IEnumerable<Note> testParam2 = GetNotes();
            IEnumerable<Note> testParam3 = GetNotes();

            TrainEditFormModel testOutput = new TrainEditFormModel(testParam0, testParam1, testParam2, testParam3);

            Note[] testParamData = testParam3.ToArray();
            Assert.AreEqual(testParamData.Length, testOutput.ValidTimingPointNotes.Count);
            for (int i = 0; i < testParamData.Length; ++i)
            {
                Assert.AreSame(testParamData[i], testOutput.ValidTimingPointNotes[i]);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
