using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.Models;

namespace Timetabler.Tests.Unit.Models
{
    [TestClass]
    public class TrainLocationTimeEditFormModelUnitTests
    {
        [TestMethod]
        public void TrainLocationTimeEditFormModelClass_Constructor_SetsValidLocationsPropertyToEqualFirstParameter_IfFirstParameterIsNull()
        {
            LocationCollection testParam0 = null;
            List<Note> testParam1 = new List<Note>();

            TrainLocationTimeEditFormModel testOutput = new TrainLocationTimeEditFormModel(testParam0, testParam1);

            Assert.IsNull(testOutput.ValidLocations);
        }

        [TestMethod]
        public void TrainLocationTimeEditFormModelClass_Constructor_SetsValidLocationsPropertyToEqualFirstParameter_IfFirstParameterIsNotNull()
        {
            LocationCollection testParam0 = new LocationCollection();
            List<Note> testParam1 = new List<Note>();

            TrainLocationTimeEditFormModel testOutput = new TrainLocationTimeEditFormModel(testParam0, testParam1);

            Assert.AreSame(testParam0, testOutput.ValidLocations);
        }

        [TestMethod]
        public void TrainLocationTimeEditFormModelClass_Constructor_SetsValidNotesPropertyToEqualSecondParameter_IfSecondParameterIsNull()
        {
            LocationCollection testParam0 = new LocationCollection();
            List<Note> testParam1 = null;

            TrainLocationTimeEditFormModel testOutput = new TrainLocationTimeEditFormModel(testParam0, testParam1);

            Assert.IsNull(testOutput.ValidNotes);
        }

        [TestMethod]
        public void TrainLocationTimeEditFormModelClass_Constructor_SetsValidNotesPropertyToEqualSecondParameter_IfSecondParameterIsNotNull()
        {
            LocationCollection testParam0 = new LocationCollection();
            List<Note> testParam1 = new List<Note>();

            TrainLocationTimeEditFormModel testOutput = new TrainLocationTimeEditFormModel(testParam0, testParam1);

            Assert.AreSame(testParam1, testOutput.ValidNotes);
        }
    }
}
