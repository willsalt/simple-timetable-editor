using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Providers;
using Timetabler.CoreData.Extensions;
using Timetabler.CoreData.Tests.Unit.Mocks;

namespace Timetabler.CoreData.Tests.Unit.Extensions
{
    [TestClass]
    public class IEnumerableExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static MockUniqueItem[] GetTestData()
        {
            int count = _rnd.Next(25);
            MockUniqueItem[] arr = new MockUniqueItem[count];
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = new MockUniqueItem();
            }
            return arr;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IEnumerableExtensionsClass_ForEachMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            MockUniqueItem[] testParam0 = null;
            static void testParam1(MockUniqueItem u, int i) => u.Id += i.ToString(CultureInfo.InvariantCulture);

            testParam0.ForEach(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IEnumerableExtensionsClass_ForEachMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            MockUniqueItem[] testParam0 = GetTestData();
            Action<MockUniqueItem, int> testParam1 = null;

            testParam0.ForEach(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void IEnumerableExtensionsClass_ForEachMethod_CallsSecondParameterOnceForEachMemberOfTheFirstParameter_IfParametersAreNotNull()
        {
            MockUniqueItem[] testParam0 = GetTestData();
            int callCount = 0;
            void testParam1(MockUniqueItem u, int i)
            {
                u.Id = i.ToString(CultureInfo.InvariantCulture);
                callCount++;
            }

            testParam0.ForEach(testParam1);

            Assert.AreEqual(testParam0.Length, callCount);
            for (int i = 0; i < testParam0.Length; ++i)
            {
                Assert.AreEqual(i.ToString(CultureInfo.InvariantCulture), testParam0[i].Id);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
