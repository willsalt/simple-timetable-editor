using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DistanceUnitTests
    {
        private readonly static Random _rnd = RandomProvider.Default;

        private static Distance GetDistance()
        {
            return new Distance { Mileage = _rnd.Next(512), Chainage = _rnd.Next(80) };
        }

        private static void AssertEqual(Distance d1, Distance d2)
        {
            if (d1 is null)
            {
                Assert.IsNull(d2);
            }
            Assert.AreEqual(d1.Mileage, d2.Mileage);
            Assert.AreEqual(d1.Chainage, d2.Chainage);
        }

        private static void AssertEqual(Distance p0, Distance p1, Distance t)
        {
            if (p0 is null && p1 is null)
            {
                Assert.IsNull(t);
            }
            if (p0 is null)
            {
                AssertEqual(p1, t);
            }
            if (p1 is null)
            {
                AssertEqual(p0, t);
            }

            Assert.AreEqual(p0.Mileage + p1.Mileage + ((int)(p0.Chainage + p1.Chainage) / 80), t.Mileage);
            Assert.AreEqual((p0.Chainage + p1.Chainage) % 80, t.Chainage);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores
        
        [TestMethod]
        public void DistanceClass_AddMethod_ReturnsNull_IfBothParametersAreNull()
        {
            Distance testParam0 = null;
            Distance testParam1 = null;

            Distance testOutput = Distance.Add(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void DistanceClass_AddMethod_ReturnsNewObject_IfFirstParameterIsNullAndSecondParameterIsNotNull()
        {
            Distance testParam0 = null;
            Distance testParam1 = GetDistance();

            Distance testOutput = Distance.Add(testParam0, testParam1);

            Assert.AreNotSame(testParam1, testOutput);
        }

        [TestMethod]
        public void DistanceClass_AddMethod_ReturnsObjectEqualToSecondParameter_IfFirstParameterIsNullAndSecondParameterIsNotNull()
        {
            Distance testParam0 = null;
            Distance testParam1 = GetDistance();

            Distance testOutput = Distance.Add(testParam0, testParam1);

            AssertEqual(testParam1, testOutput);
        }

        [TestMethod]
        public void DistanceClass_AddMethod_ReturnsNewObject_IfFirstParameterIsNotNullAndSecondParameterIsNull()
        {
            Distance testParam0 = GetDistance();
            Distance testParam1 = null;

            Distance testOutput = Distance.Add(testParam0, testParam1);

            Assert.AreNotSame(testParam0, testOutput);
        }

        [TestMethod]
        public void DistanceClass_AddMethod_ReturnsObjectEqualToFirstParameter_IfFirstParameterIsNotNullAndSecondParameterIsNull()
        {
            Distance testParam0 = GetDistance();
            Distance testParam1 = null;

            Distance testOutput = Distance.Add(testParam0, testParam1);

            AssertEqual(testParam0, testOutput);
        }

        [TestMethod]
        public void DistanceClass_AddMethod_ReturnsNewObject_IfParametersAreNotNull()
        {
            Distance testParam0 = GetDistance();
            Distance testParam1 = GetDistance();

            Distance testOutput = Distance.Add(testParam0, testParam1);

            Assert.AreNotSame(testParam0, testOutput);
            Assert.AreNotSame(testParam1, testOutput);
        }

        [TestMethod]
        public void DistanceClass_AddMethod_ReturnsNewObjectEqualToSumOfParameters_IfParametersAreNotNull()
        {
            for (int i = 0; i < 100000; ++i)
            {
                Distance testParam0 = GetDistance();
                Distance testParam1 = GetDistance();

                Distance testOutput = Distance.Add(testParam0, testParam1);

                AssertEqual(testParam0, testParam1, testOutput);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
