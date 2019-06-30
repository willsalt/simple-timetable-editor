using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;

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

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfFirstParameterIsNullAndSecondParameterHasTimingsPropertyEqualToNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(null, new TrainSegmentModel { Timings = null });

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterIsNullAndSecondParameterHasTimingsPropertyEqualToNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(null, new TrainSegmentModel { Timings = null });

            Assert.AreEqual(null, testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfFirstParameterIsNullAndSecondParameterHasNoTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(null, new TrainSegmentModel { Timings = new List<ILocationEntry>() });

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterIsNullAndSecondParameterHasNoTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(null, new TrainSegmentModel { Timings = new List<ILocationEntry>() });

            Assert.AreEqual(null, testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfFirstParameterHasNullTimingsPropertyAndSecondParameterIsNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = null }, null);

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasNullTimingsPropertyAndSecondParameterIsNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = null }, null);

            Assert.AreEqual(null, testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfFirstParameterHasNullTimingsPropertyAndSecondParameterHasNullTimingsProperty()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = null }, new TrainSegmentModel { Timings = null });

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasNullTimingsPropertyAndSecondParameterHasNullTimingsProperty()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = null }, new TrainSegmentModel { Timings = null });

            Assert.AreEqual(null, testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfFirstParameterHasNullTimingsPropertyAndSecondParameterHasNoTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = null }, new TrainSegmentModel { Timings = new List<ILocationEntry>() });

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasNullTimingsPropertyAndSecondParameterHasNoTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = null }, new TrainSegmentModel { Timings = new List<ILocationEntry>() });

            Assert.AreEqual(null, testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfFirstParameterHasNoTimingsAndSecondParameterIsNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry>() }, null);

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasNoTimingsAndSecondParameterIsNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry>() }, null);

            Assert.AreEqual(null, testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfFirstParameterHasNoTimingsAndSecondParameterHasNullTimingsProperty()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry>() }, new TrainSegmentModel { Timings = null });

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasNoTimingsAndSecondParameterHasNullTimingsProperty()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry>() }, new TrainSegmentModel { Timings = null });

            Assert.AreEqual(null, testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToZeroIfFirstParameterHasNoTimingsAndSecondParameterHasNoTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry>() }, 
                new TrainSegmentModel { Timings = new List<ILocationEntry>() });

            Assert.AreEqual(0, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasNoTimingsAndSecondParameterHasNoTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry>() }, 
                new TrainSegmentModel { Timings = new List<ILocationEntry>() });

            Assert.AreEqual(null, testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualTo1IfFirstParameterHasTimingsAndSecondParameterIsNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } }, null);

            Assert.AreEqual(1, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasTimingsAndSecondParameterIsNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } }, null);

            Assert.IsNull(testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualTo1IfFirstParameterHasTimingsAndSecondParameterHasTimingsPropertyNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } }, 
                new TrainSegmentModel { Timings = null });

            Assert.AreEqual(1, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasTimingsAndSecondParameterHasTimingsPropertyNull()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } },
                new TrainSegmentModel { Timings = null });

            Assert.IsNull(testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualTo1IfFirstParameterHasTimingsAndSecondParameterHasNoTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } },
                new TrainSegmentModel { Timings = new List<ILocationEntry>() });

            Assert.AreEqual(1, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasTimingsAndSecondParameterHasNoTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } },
                new TrainSegmentModel { Timings = new List<ILocationEntry>() });

            Assert.IsNull(testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToMinus1IfFirstParameterIsNullAndSecondParameterHasTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(null, new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } });

            Assert.AreEqual(-1, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterIsNullAndSecondParameterHasTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(null, new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } });

            Assert.IsNull(testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToMinus1IfFirstParameterHasTimingsPropertyNullAndSecondParameterHasTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = null }, 
                new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } });

            Assert.AreEqual(-1, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasTimingsPropertyNullAndSecondParameterHasTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = null },
                new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } });

            Assert.IsNull(testOutput.Item2);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem1EqualToMinus1IfFirstParameterHasNoTimingsAndSecondParameterHasTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry>() },
                new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } });

            Assert.AreEqual(-1, testOutput.Item1);
        }

        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodReturnsObjectWithItem2EqualToNullIfFirstParameterHasNoTimingsAndSecondParameterHasTimings()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>());

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(new TrainSegmentModel { Timings = new List<ILocationEntry>() },
                new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel() } });

            Assert.IsNull(testOutput.Item2);
        }
    }
}
