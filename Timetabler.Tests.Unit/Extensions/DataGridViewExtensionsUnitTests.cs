using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tests.Utility.Providers;
using Timetabler.Data.Collections;
using Timetabler.Data.Display;
using Timetabler.Extensions;

namespace Timetabler.Tests.Unit.Extensions
{
    [TestClass]
    public class DataGridViewExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_ClearGridMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            int testParam1 = _rnd.Next();

            testObject.ClearGrid(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_ClearGridMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            int testParam1 = _rnd.Next();

            try
            {
                testObject.ClearGrid(testParam1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("grid", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_AddStartingRowsMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            int testParam1 = _rnd.Next();

            testObject.AddStartingRows(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_AddStartingRowsMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            int testParam1 = _rnd.Next();

            try
            {
                testObject.AddStartingRows(testParam1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("grid", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_AddColumnsForSegmentsMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            IEnumerable<TrainSegmentModel> testParam1 = Array.Empty<TrainSegmentModel>();
            int testParam2 = _rnd.Next();
            int testParam3 = _rnd.Next();
            int testParam4 = _rnd.Next();
            int testParam5 = _rnd.Next();
            int testParam6 = _rnd.Next();
            int testParam7 = _rnd.Next();

            testObject.AddColumnsForSegments(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);

            Assert.Fail();
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_AddColumnsForSegmentsMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            IEnumerable<TrainSegmentModel> testParam1 = Array.Empty<TrainSegmentModel>();
            int testParam2 = _rnd.Next();
            int testParam3 = _rnd.Next();
            int testParam4 = _rnd.Next();
            int testParam5 = _rnd.Next();
            int testParam6 = _rnd.Next();
            int testParam7 = _rnd.Next();

            try
            {
                testObject.AddColumnsForSegments(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("grid", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_AddColumnsForSegmentsMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            using (DataGridView testObject = new DataGridView())
            {
                IEnumerable<TrainSegmentModel> testParam1 = null;
                int testParam2 = _rnd.Next();
                int testParam3 = _rnd.Next();
                int testParam4 = _rnd.Next();
                int testParam5 = _rnd.Next();
                int testParam6 = _rnd.Next();
                int testParam7 = _rnd.Next();

                testObject.AddColumnsForSegments(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_AddColumnsForSegmentsMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            using (DataGridView testObject = new DataGridView())
            {
                IEnumerable<TrainSegmentModel> testParam1 = null;
                int testParam2 = _rnd.Next();
                int testParam3 = _rnd.Next();
                int testParam4 = _rnd.Next();
                int testParam5 = _rnd.Next();
                int testParam6 = _rnd.Next();
                int testParam7 = _rnd.Next();

                try
                {
                    testObject.AddColumnsForSegments(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("segments", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_AddAndPopulateLocationRowsMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            IEnumerable<LocationDisplayModel> testParam1 = Array.Empty<LocationDisplayModel>();
            TrainSegmentModelCollection testParam2 = new TrainSegmentModelCollection();
            int testParam3 = _rnd.Next();
            int testParam4 = _rnd.Next();
            int testParam5 = _rnd.Next();
            using (Font testParam6 = new Font("Arial", 8))
            using (Font testParam7 = new Font("Arial", 10))
            {
                testObject.AddAndPopulateLocationRows(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_AddAndPopulateLocationRowsMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            IEnumerable<LocationDisplayModel> testParam1 = Array.Empty<LocationDisplayModel>();
            TrainSegmentModelCollection testParam2 = new TrainSegmentModelCollection();
            int testParam3 = _rnd.Next();
            int testParam4 = _rnd.Next();
            int testParam5 = _rnd.Next();
            using (Font testParam6 = new Font("Arial", 8))
            using (Font testParam7 = new Font("Arial", 10))
            {
                try
                {
                    testObject.AddAndPopulateLocationRows(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("grid", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_AddAndPopulateLocationRowsMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            IEnumerable<LocationDisplayModel> testParam1 = null;
            TrainSegmentModelCollection testParam2 = new TrainSegmentModelCollection();
            int testParam3 = _rnd.Next();
            int testParam4 = _rnd.Next();
            int testParam5 = _rnd.Next();
            using (Font testParam6 = new Font("Arial", 8))
            using (Font testParam7 = new Font("Arial", 10))
            using (DataGridView testObject = new DataGridView())
            {
                testObject.AddAndPopulateLocationRows(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_AddAndPopulateLocationRowsMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            IEnumerable<LocationDisplayModel> testParam1 = null;
            TrainSegmentModelCollection testParam2 = new TrainSegmentModelCollection();
            int testParam3 = _rnd.Next();
            int testParam4 = _rnd.Next();
            int testParam5 = _rnd.Next();
            using (Font testParam6 = new Font("Arial", 8))
            using (Font testParam7 = new Font("Arial", 10))
            using (DataGridView testObject = new DataGridView())
            {
                try
                {
                    testObject.AddAndPopulateLocationRows(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("locations", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_AddAndPopulateLocationRowsMethod_ThrowsArgumentNullException_IfThirdParameterIsNull()
        {
            IEnumerable<LocationDisplayModel> testParam1 = Array.Empty<LocationDisplayModel>();
            TrainSegmentModelCollection testParam2 = null;
            int testParam3 = _rnd.Next();
            int testParam4 = _rnd.Next();
            int testParam5 = _rnd.Next();
            using (Font testParam6 = new Font("Arial", 8))
            using (Font testParam7 = new Font("Arial", 10))
            using (DataGridView testObject = new DataGridView())
            {
                testObject.AddAndPopulateLocationRows(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_AddAndPopulateLocationRowsMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfThirdParameterIsNull()
        {
            IEnumerable<LocationDisplayModel> testParam1 = Array.Empty<LocationDisplayModel>();
            TrainSegmentModelCollection testParam2 = null;
            int testParam3 = _rnd.Next();
            int testParam4 = _rnd.Next();
            int testParam5 = _rnd.Next();
            using (Font testParam6 = new Font("Arial", 8))
            using (Font testParam7 = new Font("Arial", 10))
            using (DataGridView testObject = new DataGridView())
            {
                try
                {
                    testObject.AddAndPopulateLocationRows(testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("segments", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_AddAndPopulateToWorkRowMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            TrainSegmentModelCollection testParam1 = new TrainSegmentModelCollection();
            int testParam2 = _rnd.Next();
            int testParam3 = _rnd.Next();
            using (Font testParam4 = new Font("Arial", 10))
            {
                testObject.AddAndPopulateToWorkRow(testParam1, testParam2, testParam3, testParam4);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_AddAndPopulateToWorkRowMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            DataGridView testObject = null;
            TrainSegmentModelCollection testParam1 = new TrainSegmentModelCollection();
            int testParam2 = _rnd.Next();
            int testParam3 = _rnd.Next();
            using (Font testParam4 = new Font("Arial", 10))
            {
                try
                {
                    testObject.AddAndPopulateToWorkRow(testParam1, testParam2, testParam3, testParam4);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("grid", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataGridViewExtensionsClass_AddAndPopulateToWorkRowMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            TrainSegmentModelCollection testParam1 = null;
            int testParam2 = _rnd.Next();
            int testParam3 = _rnd.Next();
            using (Font testParam4 = new Font("Arial", 10))
            using (DataGridView testObject = new DataGridView())
            {
                testObject.AddAndPopulateToWorkRow(testParam1, testParam2, testParam3, testParam4);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void DataGridViewExtensionsClass_AddAndPopulateToWorkRowMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            TrainSegmentModelCollection testParam1 = null;
            int testParam2 = _rnd.Next();
            int testParam3 = _rnd.Next();
            using (Font testParam4 = new Font("Arial", 10))
            using (DataGridView testObject = new DataGridView())
            {
                try
                {
                    testObject.AddAndPopulateToWorkRow(testParam1, testParam2, testParam3, testParam4);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("segments", ex.ParamName);
                }
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
