using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Comparers
{
    [TestClass]
    public class TrainSegmentModelComparerUnitTests
    {
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfBothParametersAreNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(null, null);

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfBothParametersAreNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(null, null);

            Assert.IsNull(testOutput.Item2);
        }
    }
}
