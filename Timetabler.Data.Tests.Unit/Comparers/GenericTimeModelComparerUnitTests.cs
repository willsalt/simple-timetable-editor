using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Providers;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.Comparers
{
    [TestClass]
    public class GenericTimeModelComparerUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenBothParametersAreNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = null;
            GenericTimeModel testParam1 = null;

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenFirstParameterIsNullAndSecondParameterIsObjectWithActualTimePropertyEqualToNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = null;
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = null };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenFirstParameterIsObjectWithActualTimePropertyEqualToNullAndSecondParameterIsNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = null };
            GenericTimeModel testParam1 = null;

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void GenericTimeModelComparerClassCompareMethodReturnsZeroWhenBothParametersAreObjectsWithActualTimePropertyEqualToNull()
        {
            GenericTimeModelComparer testObject = GenericTimeModelComparer.Default;
            GenericTimeModel testParam0 = new GenericTimeModel { ActualTime = null };
            GenericTimeModel testParam1 = new GenericTimeModel { ActualTime = null };

            int testOutput = testObject.Compare(testParam0, testParam1);

            Assert.AreEqual(0, testOutput);
        }
    }
}
