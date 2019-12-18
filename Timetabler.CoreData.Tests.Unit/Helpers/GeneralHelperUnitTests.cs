using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethod_ReturnsIdNotAlreadyInParameterContent()
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
        public void GeneralHelperClass_GetNewIdMethod_ThrowsArgumentNullExceptionIfParameterIsNull()
        {
            List<MockUniqueItem> testParam = null;

            _ = GeneralHelper.GetNewId(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void GeneralHelperClass_GetNewIdMethod_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfParameterIsNull()
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
    }
}
