using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Tests.Unit.Comparers
{
    [TestClass]
    public class TrainSegmentModelComparerUnitTests
    {
        private void UpdateTimingsIndex(TrainSegmentModel segment)
        {
            segment.TimingsIndex = segment.Timings.ToDictionary(t => t.LocationKey, t => t);
        }

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

        // Case 1: test the following simple case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 10:00:00 | 10:00:00 |
        // +---+----------+----------+
        //
        // Should return (0, null)
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase1()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel> { new LocationDisplayModel { LocationKey = "A" } });
            TrainSegmentModel testParam0 = new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) } } };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) } } };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput.Item1);
            Assert.IsNull(testOutput.Item2);
        }

        // Case 2: test the following case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 10:00:00 | 10:00:00 |
        // +---+----------+----------+
        // | B | 10:07:00 | 10:07:00 |
        // +---+----------+----------+
        // | C | 10:33:00 | 10:33:00 |
        // +---+----------+----------+
        // | D | 10:38:15 | 10:38:15 |
        // +---+----------+----------+
        //
        // Should return (0, null)
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase2()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>
            {
                new LocationDisplayModel { LocationKey = "A" },
                new LocationDisplayModel { LocationKey = "B" },
                new LocationDisplayModel { LocationKey = "C" },
                new LocationDisplayModel { LocationKey = "D" },
            });
            TrainSegmentModel testParam0 = new TrainSegmentModel { Timings = new List<ILocationEntry>
            {
                new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33) },
                new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
            } };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel { Timings = new List<ILocationEntry>
            {
                new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33) },
                new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
            } };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput.Item1);
            Assert.IsNull(testOutput.Item2);
        }

        // Case 3: test the following simple case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 09:59:59 | 10:00:00 |
        // +---+----------+----------+
        //
        // Should return (-1, null)
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase3()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel> { new LocationDisplayModel { LocationKey = "A" } });
            TrainSegmentModel testParam0 = new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(9, 59, 59) } } };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) } } };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput.Item1);
            Assert.IsNull(testOutput.Item2);
        }

        // Case 4: test the following simple case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 09:59:59 | 09:59:50 |
        // +---+----------+----------+
        //
        // Should return (1, null)
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase4()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel> { new LocationDisplayModel { LocationKey = "A" } });
            TrainSegmentModel testParam0 = new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(9, 59, 59) } } };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel { Timings = new List<ILocationEntry> { new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(9, 59, 50) } } };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput.Item1);
            Assert.IsNull(testOutput.Item2);
        }

        // Case 5: test the following case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 10:00:00 | 10:07:00 |
        // +---+----------+----------+
        // | B | 10:07:00 | 10:12:15 |
        // +---+----------+----------+
        // | C | 10:33:00 | 10:33:01 |
        // +---+----------+----------+
        // | D | 10:38:15 | 10:38:59 |
        // +---+----------+----------+
        //
        // Should return (-1, null)
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase5()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>
            {
                new LocationDisplayModel { LocationKey = "A" },
                new LocationDisplayModel { LocationKey = "B" },
                new LocationDisplayModel { LocationKey = "C" },
                new LocationDisplayModel { LocationKey = "D" },
            });
            TrainSegmentModel testParam0 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
                }
            };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 12, 15) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33, 1) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 59) },
                }
            };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput.Item1);
            Assert.IsNull(testOutput.Item2);
        }

        // Case 6: test the following case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 10:00:00 | 09:00:00 |
        // +---+----------+----------+
        // | B | 10:07:00 | 09:45:15 |
        // +---+----------+----------+
        // | C | 10:33:00 | 10:30:00 |
        // +---+----------+----------+
        // | D | 10:38:15 | 10:38:14 |
        // +---+----------+----------+
        //
        // Should return (1, null)
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase6()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>
            {
                new LocationDisplayModel { LocationKey = "A" },
                new LocationDisplayModel { LocationKey = "B" },
                new LocationDisplayModel { LocationKey = "C" },
                new LocationDisplayModel { LocationKey = "D" },
            });
            TrainSegmentModel testParam0 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
                }
            };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(9, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(9, 45, 15) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 30) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 14) },
                }
            };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput.Item1);
            Assert.IsNull(testOutput.Item2);
        }

        // Case 7: test the following case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 10:00:00 | 10:00:00 |
        // +---+----------+----------+
        // | B | 10:07:00 | 10:07:00 |
        // +---+----------+----------+
        // | C | 10:35:00 | 10:33:01 |
        // +---+----------+----------+
        // | D | 10:38:15 | 10:38:59 |
        // +---+----------+----------+
        //
        // Should return (-1, null)
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase7()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>
            {
                new LocationDisplayModel { LocationKey = "A" },
                new LocationDisplayModel { LocationKey = "B" },
                new LocationDisplayModel { LocationKey = "C" },
                new LocationDisplayModel { LocationKey = "D" },
            });
            TrainSegmentModel testParam0 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
                }
            };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33, 1) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 59) },
                }
            };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput.Item1);
            Assert.IsNull(testOutput.Item2);
        }

        // Case 8: test the following case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 10:00:00 | 09:00:00 |
        // +---+----------+----------+
        // | B | 10:07:00 | 09:45:15 |
        // +---+----------+----------+
        // | C | 10:33:00 | 10:33:00 |
        // +---+----------+----------+
        // | D | 10:38:15 | 10:38:15 |
        // +---+----------+----------+
        //
        // Should return (1, null)
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase8()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>
            {
                new LocationDisplayModel { LocationKey = "A" },
                new LocationDisplayModel { LocationKey = "B" },
                new LocationDisplayModel { LocationKey = "C" },
                new LocationDisplayModel { LocationKey = "D" },
            });
            TrainSegmentModel testParam0 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
                }
            };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(9, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(9, 45, 15) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 33) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
                }
            };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput.Item1);
            Assert.IsNull(testOutput.Item2);
        }

        // Case 9: test the following case:
        //
        // +---+----------+----------+
        // |   |  Param 0 |  Param 1 |
        // +---+----------+----------+
        // | A | 10:00:00 | 10:07:00 |
        // +---+----------+----------+
        // | B | 10:07:00 | 10:12:00 |
        // +---+----------+----------+
        // | C | 10:35:00 | 10:17:01 |
        // +---+----------+----------+
        // | D | 10:38:15 | 10:22:59 |
        // +---+----------+----------+
        //
        // Should return (-1, <object>) to effectively give the following result:
        //
        // +---+----------+----------+----------+
        // |   |  Param 0 |  Param 1 |  Item 2  |
        // +---+----------+----------+----------+
        // | A | 10:00:00 | 10:07:00 |   <<<<   |
        // +---+----------+----------+----------+
        // | B | 10:07:00 | 10:12:00 | 10:07:00 |
        // +---+----------+----------+----------+
        // | C | 10:35:00 | 10:17:01 | 10:35:00 |
        // +---+----------+----------+----------+
        // | D |   >>>>   | 10:22:59 | 10:38:15 |
        // +---+----------+----------+----------+
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase9()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>
            {
                new LocationDisplayModel { LocationKey = "A" },
                new LocationDisplayModel { LocationKey = "B" },
                new LocationDisplayModel { LocationKey = "C" },
                new LocationDisplayModel { LocationKey = "D" },
            });
            TrainSegmentModel testParam0 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 35) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
                }
            };
            UpdateTimingsIndex(testParam0);
            TrainSegmentModel testParam1 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 12) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 17, 1) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 22, 59) },
                }
            };
            UpdateTimingsIndex(testParam1);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(-1, testOutput.Item1);
            Assert.IsNotNull(testOutput.Item2);
            Assert.AreEqual(3, testParam0.Timings.Count);
            Assert.AreEqual(new TimeOfDay(10, 0), (testParam0.Timings[0] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("A", testParam0.Timings[0].LocationKey);
            Assert.AreEqual(new TimeOfDay(10, 7), (testParam0.Timings[1] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("B", testParam0.Timings[1].LocationKey);
            Assert.AreEqual(new TimeOfDay(10, 35), (testParam0.Timings[2] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("C", testParam0.Timings[2].LocationKey);
            Assert.IsTrue(testParam0.ContinuesLater);
            Assert.AreEqual(3, testOutput.Item2.Timings.Count);
            Assert.AreEqual(new TimeOfDay(10, 7), (testOutput.Item2.Timings[0] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("B", testOutput.Item2.Timings[0].LocationKey);
            Assert.AreEqual(new TimeOfDay(10, 35), (testOutput.Item2.Timings[1] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("C", testOutput.Item2.Timings[1].LocationKey);
            Assert.AreEqual(new TimeOfDay(10, 38, 15), (testOutput.Item2.Timings[2] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("D", testOutput.Item2.Timings[2].LocationKey);
            Assert.IsTrue(testOutput.Item2.ContinuationFromEarlier);
        }

        // Case 10: test the following case:
        //
        // +---+----------+----------+
        // |   |  Param 1 |  Param 0 |
        // +---+----------+----------+
        // | A | 10:00:00 | 10:07:00 |
        // +---+----------+----------+
        // | B | 10:07:00 | 10:12:00 |
        // +---+----------+----------+
        // | C | 10:35:00 | 10:17:01 |
        // +---+----------+----------+
        // | D | 10:38:15 | 10:22:59 |
        // +---+----------+----------+
        //
        // Should return (1, <object>) to effectively give the following result:
        //
        // +---+----------+----------+----------+
        // |   |  Param 1 |  Param 0 |  Item 2  |
        // +---+----------+----------+----------+
        // | A | 10:00:00 | 10:07:00 |   <<<<   |
        // +---+----------+----------+----------+
        // | B | 10:07:00 | 10:12:00 | 10:07:00 |
        // +---+----------+----------+----------+
        // | C | 10:35:00 | 10:17:01 | 10:35:00 |
        // +---+----------+----------+----------+
        // | D |   >>>>   | 10:22:59 | 10:38:15 |
        // +---+----------+----------+----------+
        [TestMethod]
        public void TrainSegmentModelComparerClassCompareMethodWithCommonLocationsCase10()
        {
            TrainSegmentModelComparer testObject = new TrainSegmentModelComparer(new List<LocationDisplayModel>
            {
                new LocationDisplayModel { LocationKey = "A" },
                new LocationDisplayModel { LocationKey = "B" },
                new LocationDisplayModel { LocationKey = "C" },
                new LocationDisplayModel { LocationKey = "D" },
            });
            TrainSegmentModel testParam1 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 0) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 35) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 38, 15) },
                }
            };
            UpdateTimingsIndex(testParam1);
            TrainSegmentModel testParam0 = new TrainSegmentModel
            {
                Timings = new List<ILocationEntry>
                {
                    new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(10, 7) },
                    new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(10, 12) },
                    new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(10, 17, 1) },
                    new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(10, 22, 59) },
                }
            };
            UpdateTimingsIndex(testParam0);

            Tuple<int, TrainSegmentModel> testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(1, testOutput.Item1);
            Assert.IsNotNull(testOutput.Item2);
            Assert.AreEqual(3, testParam1.Timings.Count);
            Assert.AreEqual(new TimeOfDay(10, 0), (testParam1.Timings[0] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("A", testParam1.Timings[0].LocationKey);
            Assert.AreEqual(new TimeOfDay(10, 7), (testParam1.Timings[1] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("B", testParam1.Timings[1].LocationKey);
            Assert.AreEqual(new TimeOfDay(10, 35), (testParam1.Timings[2] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("C", testParam1.Timings[2].LocationKey);
            Assert.IsTrue(testParam1.ContinuesLater);
            Assert.AreEqual(3, testOutput.Item2.Timings.Count);
            Assert.AreEqual(new TimeOfDay(10, 7), (testOutput.Item2.Timings[0] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("B", testOutput.Item2.Timings[0].LocationKey);
            Assert.AreEqual(new TimeOfDay(10, 35), (testOutput.Item2.Timings[1] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("C", testOutput.Item2.Timings[1].LocationKey);
            Assert.AreEqual(new TimeOfDay(10, 38, 15), (testOutput.Item2.Timings[2] as TrainLocationTimeModel).ActualTime);
            Assert.AreEqual("D", testOutput.Item2.Timings[2].LocationKey);
            Assert.IsTrue(testOutput.Item2.ContinuationFromEarlier);
        }
    }
}
