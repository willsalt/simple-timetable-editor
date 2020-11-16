using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tests.Utility.Providers;
using Timetabler.CoreData.Helpers;
using Timetabler.CoreData.Tests.Unit.Mocks;

namespace Timetabler.CoreData.Tests.Unit.Helpers
{
    [TestClass]
    public class GeneralHelperUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static List<string> GetTestStrings()
        {
            int count = _rnd.Next(25);
            List<string> data = new List<string>();
            for (int i = 0; i < count; ++i)
            {
                string n;
                do
                {
                    n = _rnd.Next().ToString("x8", CultureInfo.InvariantCulture);
                } while (data.Contains(n));
                data.Add(n);
            }
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfTParameter_ReturnsIdNotAlreadyInParameterContent()
        {
            int itemCount = _rnd.Next(1, 500);
            List<MockUniqueItem> testData = new List<MockUniqueItem>(itemCount);

            for (int i = 0; i < itemCount; ++i)
            {
                MockUniqueItem newItem = new MockUniqueItem { Id = GeneralHelper.GetNewId(testData) };
                Assert.IsFalse(testData.Select(o => o.Id).Contains(newItem.Id));
                testData.Add(newItem);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfTParameter_ThrowsArgumentNullExceptionIfParameterIsNull()
        {
            List<MockUniqueItem> testParam = null;

            _ = GeneralHelper.GetNewId(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfTParameter_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfParameterIsNull()
        {
            List<MockUniqueItem> testParam = null;

            try
            {
                _ = GeneralHelper.GetNewId(testParam);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("existingItems", ex.ParamName);
            }
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfTParameter_DoesNotThrowException_IfParameterContainsElementsWhoseIdPropertyIsNull()
        {
            List<MockUniqueItem> testParam = new List<MockUniqueItem> { new MockUniqueItem { Id = null } };

            string testOutput = GeneralHelper.GetNewId(testParam);

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfStringAndIntParameters_ReturnsCorrectNumberOfItemsInEnumeration_IfFirstParameterIsNull()
        {
            List<string> testParam0 = null;
            int testParam1 = _rnd.Next(25);

            IEnumerable<string> testOutput = GeneralHelper.GetNewId(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Count());
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfStringAndIntParameters_ReturnsEmptyEnumeration_IfFirstParameterIsNullAndSecondParameterIsZero()
        {
            List<string> testParam0 = null;
            int testParam1 = 0;

            IEnumerable<string> testOutput = GeneralHelper.GetNewId(testParam0, testParam1);

            Assert.AreEqual(0, testOutput.Count());
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfStringAndIntParameters_ReturnsUniqueItems_IfFirstParameterIsNull()
        {
            List<string> testParam0 = null;
            int testParam1 = _rnd.Next(25);

            IEnumerable<string> testOutput = GeneralHelper.GetNewId(testParam0, testParam1);
            List<string> testOutputList = testOutput.ToList();

            foreach (string outputItem in testOutputList)
            {
                Assert.AreEqual(1, testOutputList.Count(s => s == outputItem));
            }
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfStringAndIntParameters_ReturnsCorrectNumberOfItemsInEnumeration_IfFirstParameterIsNotNull()
        {
            List<string> testParam0 = GetTestStrings();
            int testParam1 = _rnd.Next(25);

            IEnumerable<string> testOutput = GeneralHelper.GetNewId(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Count());
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfStringAndIntParameters_ReturnsUniqueItems_IfFirstParameterIsNotNull()
        {
            List<string> testParam0 = GetTestStrings();
            int testParam1 = _rnd.Next(25);

            IEnumerable<string> testOutput = GeneralHelper.GetNewId(testParam0, testParam1);
            List<string> testOutputList = testOutput.ToList();

            foreach (string outputItem in testOutputList)
            {
                Assert.AreEqual(1, testOutputList.Count(s => s == outputItem));
            }
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethodWithIEnumerableOfStringAndIntParameters_ReturnsItemsNotInFirstParameter_IfFirstParameterIsNotNull()
        {
            List<string> testParam0 = GetTestStrings();
            int testParam1 = _rnd.Next(25);

            IEnumerable<string> testOutput = GeneralHelper.GetNewId(testParam0, testParam1);
            List<string> testOutputList = testOutput.ToList();

            foreach (string outputItem in testOutputList)
            {
                Assert.IsFalse(testParam0.Contains(outputItem));
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
