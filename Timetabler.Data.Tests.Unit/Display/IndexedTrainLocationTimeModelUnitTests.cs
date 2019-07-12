using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class IndexedTrainLocationTimeModelUnitTests
    {
        [TestMethod]
        public void IndexedTrainLocationTimeModelClassModelPropertyReturnsSameObjectAsEntryPropertyIfTypeOfObjectIsTrainLocationTimeModel()
        {
            IndexedTrainLocationTimeModel testObject = new IndexedTrainLocationTimeModel { Entry = new TrainLocationTimeModel() };

            TrainLocationTimeModel testOutput = testObject.Model;

            Assert.AreSame(testObject.Entry, testOutput);
        }

        [TestMethod]
        public void IndexedTrainLocationTimeModelClassModelPropertyIsNullIfTypeOfEntryPropertyIsNotTrainLocationTimeModel()
        {
            IndexedTrainLocationTimeModel testObject = new IndexedTrainLocationTimeModel { Entry = new LocationEntryModel() };

            TrainLocationTimeModel testOutput = testObject.Model;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void IndexedTrainLocationTimeModelClassModelPropertyIsNullIfEntryPropertyIsNull()
        {
            IndexedTrainLocationTimeModel testObject = new IndexedTrainLocationTimeModel { Entry = null };

            TrainLocationTimeModel testOutput = testObject.Model;

            Assert.IsNull(testOutput);
        }
    }
}
