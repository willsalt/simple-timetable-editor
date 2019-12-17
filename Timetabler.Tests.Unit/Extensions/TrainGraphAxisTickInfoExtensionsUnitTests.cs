using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;
using Timetabler.Extensions;

namespace Timetabler.Tests.Unit.Extensions
{
    [TestClass]
    public class TrainGraphAxisTickInfoExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TrainGraphAxisTickInfo GetTrainGraphAxisTickInfo()
        {
            return new TrainGraphAxisTickInfo(_rnd.NextString(_rnd.Next(1, 5)), _rnd.NextDouble());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            TrainGraphAxisTickInfo testObject = null;
            using (Font testParam2 = new Font("Arial", 10))
            using (Bitmap dummyBitmap = new Bitmap(1, 1))
            {
                Graphics testParam1 = Graphics.FromImage(dummyBitmap);

                testObject.PopulateSize(testParam1, testParam2);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            TrainGraphAxisTickInfo testObject = null;
            using (Font testParam2 = new Font("Arial", 10))
            using (Bitmap dummyBitmap = new Bitmap(1, 1))
            {
                Graphics testParam1 = Graphics.FromImage(dummyBitmap);

                try
                {
                    testObject.PopulateSize(testParam1, testParam2);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("tickInfo", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            TrainGraphAxisTickInfo testObject = GetTrainGraphAxisTickInfo();
            Graphics testParam1 = null;
            using (Font testParam2 = new Font("Arial", 10))
            {
                testObject.PopulateSize(testParam1, testParam2);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            TrainGraphAxisTickInfo testObject = GetTrainGraphAxisTickInfo();
            Graphics testParam1 = null;
            using (Font testParam2 = new Font("Arial", 10))
            {
                try
                {
                    testObject.PopulateSize(testParam1, testParam2);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("graphicsContext", ex.ParamName);
                }
            }
        }
    }
}
