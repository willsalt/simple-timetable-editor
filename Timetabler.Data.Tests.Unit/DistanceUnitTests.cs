using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DistanceUnitTests
    {
        //private readonly static Random _rnd = RandomProvider.Default;

        //private static void AssertEqual(Distance d1, Distance d2)
        //{
        //    //if (d1 is null)
        //    //{
        //    //    Assert.IsNull(d2);
        //    //}
        //    Assert.AreEqual(d1.Mileage, d2.Mileage);
        //    Assert.AreEqual(d1.Chainage, d2.Chainage);
        //}

        private static void AssertEqual(Distance p0, Distance p1, Distance t)
        {
            //if (p0 is null && p1 is null)
            //{
            //    Assert.IsNull(t);
            //}
            //if (p0 is null)
            //{
            //    AssertEqual(p1, t);
            //}
            //if (p1 is null)
            //{
            //    AssertEqual(p0, t);
            //}

            Assert.AreEqual(p0.Mileage + p1.Mileage + ((int)(p0.Chainage + p1.Chainage) / 80), t.Mileage);
            Assert.AreEqual((p0.Chainage + p1.Chainage) % 80, t.Chainage);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores
        
        [TestMethod]
        public void DistanceClass_MajorLabelProperty_HasCorrectValue()
        {
            Assert.AreEqual(Resources.Distance_MileageLabel, Distance.MajorLabel);
        }

        [TestMethod]
        public void DistanceClass_MinorLabelProperty_HasCorrectValue()
        {
            Assert.AreEqual(Resources.Distance_ChainageLabel, Distance.MinorLabel);
        }

        //[TestMethod]
        //public void DistanceClass_AddMethod_ReturnsNull_IfBothParametersAreNull()
        //{
        //    Distance testParam0 = null;
        //    Distance testParam1 = null;

        //    Distance testOutput = Distance.Add(testParam0, testParam1);

        //    Assert.IsNull(testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_AddMethod_ReturnsNewObjectIfFirstParameterIsNullAndSecondParameterIsNotNull()
        //{
        //    Distance testParam0 = null;
        //    Distance testParam1 = GetDistance();

        //    Distance testOutput = Distance.Add(testParam0, testParam1);

        //    Assert.AreNotSame(testParam1, testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_AddMethod_ReturnsObjectEqualToSecondParameterIfFirstParameterIsNullAndSecondParameterIsNotNull()
        //{
        //    Distance testParam0 = null;
        //    Distance testParam1 = GetDistance();

        //    Distance testOutput = Distance.Add(testParam0, testParam1);

        //    AssertEqual(testParam1, testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_AddMethod_ReturnsNewObjectIfFirstParameterIsNotNullAndSecondParameterIsNull()
        //{
        //    Distance testParam0 = GetDistance();
        //    Distance testParam1 = null;

        //    Distance testOutput = Distance.Add(testParam0, testParam1);

        //    Assert.AreNotSame(testParam0, testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_AddMethod_ReturnsObjectEqualToFirstParameterIfFirstParameterIsNotNullAndSecondParameterIsNull()
        //{
        //    Distance testParam0 = GetDistance();
        //    Distance testParam1 = null;

        //    Distance testOutput = Distance.Add(testParam0, testParam1);

        //    AssertEqual(testParam0, testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_AddMethod_ReturnsNewObject_IfParametersAreNotNull()
        //{
        //    Distance testParam0 = DistanceHelpers.GetDistance();
        //    Distance testParam1 = DistanceHelpers.GetDistance();

        //    Distance testOutput = Distance.Add(testParam0, testParam1);

        //    Assert.AreNotSame(testParam0, testOutput);
        //    Assert.AreNotSame(testParam1, testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_AddMethod_ReturnsNewObjectEqualToSumOfParameters_IfParametersAreNotNull()
        //{
        //    Distance testParam0 = GetDistance();
        //    Distance testParam1 = GetDistance();

        //    Distance testOutput = Distance.Add(testParam0, testParam1);

        //    AssertEqual(testParam0, testParam1, testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_DifferenceMethod_ReturnsNull_IfBothParametersAreNull()
        //{
        //    Distance testParam0 = null;
        //    Distance testParam1 = null;

        //    Distance testOutput = Distance.Difference(testParam0, testParam1);

        //    Assert.IsNull(testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_DifferenceMethod_ReturnsNull_IfFirstParameterIsNull()
        //{
        //    Distance testParam0 = null;
        //    Distance testParam1 = GetDistance();

        //    Distance testOutput = Distance.Difference(testParam0, testParam1);

        //    Assert.IsNull(testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_DifferenceMethod_ReturnsNull_IfSecondParameterIsNull()
        //{
        //    Distance testParam0 = GetDistance();
        //    Distance testParam1 = null;

        //    Distance testOutput = Distance.Difference(testParam0, testParam1);

        //    Assert.IsNull(testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_DifferenceMethod_ReturnsDistanceEqualToZero_IfParametersAreEqual()
        //{
        //    Distance testParam0 = GetDistance();
        //    Distance testParam1 = new Distance { Mileage = testParam0.Mileage, Chainage = testParam0.Chainage };
        //    Distance expectedResult = new Distance { Mileage = 0, Chainage = 0 };

        //    Distance testOutput = Distance.Difference(testParam0, testParam1);

        //    AssertEqual(expectedResult, testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_DifferenceMethod_ReturnsCorrectResult_IfSecondParameterIsGreaterThanFirstParameter()
        //{
        //    Distance testParam0 = GetDistance();
        //    Distance expectedResult = GetDistance();
        //    Distance testParam1 = testParam0 + expectedResult;

        //    Distance testOutput = Distance.Difference(testParam0, testParam1);

        //    AssertEqual(expectedResult, testOutput);
        //}

        //[TestMethod]
        //public void DistanceClass_DifferenceMethod_ReturnsCorrectResult_IfFirstParameterIsGreaterThanSecondParameter()
        //{
        //    Distance testParam1 = GetDistance();
        //    Distance expectedResult = GetDistance();
        //    Distance testParam0 = testParam1 + expectedResult;

        //    Distance testOutput = Distance.Difference(testParam0, testParam1);

        //    AssertEqual(expectedResult, testOutput);
        //}

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
