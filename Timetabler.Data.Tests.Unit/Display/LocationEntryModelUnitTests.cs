using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;
using Timetabler.Data.Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class LocationEntryModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static LocationEntryModel GetTestObject() => new LocationEntryModel
        {
            DisplayedText = _rnd.NextString(_rnd.Next(20)),
            EntryType = _rnd.NextTrainLocationTimeEntryType(),
            LocationKey = _rnd.NextString(_rnd.Next(1, 10)),
            LocationId = _rnd.NextHexString(8),
        };

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LocationEntryModelClass_CopyMethodForClass_ReturnsObjectWithCorrectDisplayedTextProperty()
        {
            LocationEntryModel testObject = GetTestObject();
            string expectedResult = testObject.DisplayedText;

            LocationEntryModel testOutput = testObject.Copy();

            Assert.AreEqual(expectedResult, testOutput.DisplayedText);
        }

        [TestMethod]
        public void LocationEntryModelClass_CopyMethodForClass_ReturnsObjectWithCorrectEntryTypeProperty()
        {
            LocationEntryModel testObject = GetTestObject();
            TrainLocationTimeEntryType expectedResult = testObject.EntryType;

            LocationEntryModel testOutput = testObject.Copy();

            Assert.AreEqual(expectedResult, testOutput.EntryType);
        }

        [TestMethod]
        public void LocationEntryModelClass_CopyMethodForClass_ReturnsObjectWithCorrectLocationKeyProperty()
        {
            LocationEntryModel testObject = GetTestObject();
            string expectedResult = testObject.LocationKey;

            LocationEntryModel testOutput = testObject.Copy();

            Assert.AreEqual(expectedResult, testOutput.LocationKey);
        }

        [TestMethod]
        public void LocationEntryModelClass_CopyMethodForClass_ReturnsObjectWithCorrectLocationIdProperty()
        {
            LocationEntryModel testObject = GetTestObject();
            string expectedResult = testObject.LocationId;

            LocationEntryModel testOutput = testObject.Copy();

            Assert.AreEqual(expectedResult, testOutput.LocationId);
        }

        [TestMethod]
        public void LocationEntryModelClass_CopyMethodForILocationEntryInterface_ReturnsObjectWithCorrectDisplayedTextProperty()
        {
            ILocationEntry testObject = GetTestObject();
            string expectedResult = testObject.DisplayedText;

            ILocationEntry testOutput = testObject.Copy();

            Assert.AreEqual(expectedResult, testOutput.DisplayedText);
        }

        [TestMethod]
        public void LocationEntryModelClass_CopyMethodForILocationEntryInterface_ReturnsObjectWithCorrectEntryTypeProperty()
        {
            ILocationEntry testObject = GetTestObject();
            TrainLocationTimeEntryType expectedResult = testObject.EntryType;

            ILocationEntry testOutput = testObject.Copy();

            Assert.AreEqual(expectedResult, testOutput.EntryType);
        }

        [TestMethod]
        public void LocationEntryModelClass_CopyMethodForILocationEntryInterface_ReturnsObjectWithCorrectLocationKeyProperty()
        {
            LocationEntryModel originalTestObject = GetTestObject();
            string expectedResult = originalTestObject.LocationKey;
            ILocationEntry testObject = originalTestObject;

            ILocationEntry testOutput = testObject.Copy();

            Assert.AreEqual(expectedResult, (testOutput as LocationEntryModel).LocationKey);
        }

        [TestMethod]
        public void LocationEntryModelClass_CopyMethodForILocationEntryInterface_ReturnsObjectWithCorrectLocationIdProperty()
        {
            LocationEntryModel originalTestObject = GetTestObject();
            string expectedResult = originalTestObject.LocationId;
            ILocationEntry testObject = originalTestObject;

            ILocationEntry testOutput = testObject.Copy();

            Assert.AreEqual(expectedResult, (testOutput as LocationEntryModel).LocationId);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
