using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class IndexedTrainLocationTimeModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void IndexedTrainLocationTimeModelClass_ModelProperty_ReturnsSameObjectAsEntryProperty_IfTypeOfObjectIsTrainLocationTimeModel()
        {
            IndexedTrainLocationTimeModel testObject = new IndexedTrainLocationTimeModel { Entry = new TrainLocationTimeModel() };

            TrainLocationTimeModel testOutput = testObject.Model;

            Assert.AreSame(testObject.Entry, testOutput);
        }

        [TestMethod]
        public void IndexedTrainLocationTimeModelClass_ModelProperty_IsNull_IfTypeOfEntryPropertyIsNotTrainLocationTimeModel()
        {
            IndexedTrainLocationTimeModel testObject = new IndexedTrainLocationTimeModel { Entry = new LocationEntryModel() };

            TrainLocationTimeModel testOutput = testObject.Model;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void IndexedTrainLocationTimeModelClass_ModelProperty_IsNull_IfEntryPropertyIsNull()
        {
            IndexedTrainLocationTimeModel testObject = new IndexedTrainLocationTimeModel { Entry = null };

            TrainLocationTimeModel testOutput = testObject.Model;

            Assert.IsNull(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
