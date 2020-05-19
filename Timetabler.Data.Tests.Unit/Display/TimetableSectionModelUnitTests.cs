using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Collections;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TimetableSectionModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TimetableSectionModel GetTimetableSectionModel()
        {
            return new TimetableSectionModel(_rnd.NextBoolean() ? Direction.Down : Direction.Up, new LocationCollection());
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimetableSectionModelClass_AddMethod_ThrowsArgumentNullExceptionIfParameterIsNull()
        {
            TimetableSectionModel testObject = GetTimetableSectionModel();

            testObject.Add(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TimetableSectionModelClass_AddMethod_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfParameterIsNull()
        {
            TimetableSectionModel testObject = GetTimetableSectionModel();

            try
            {
                testObject.Add(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("segment", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
