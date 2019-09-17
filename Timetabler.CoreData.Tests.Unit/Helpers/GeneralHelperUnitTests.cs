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
        public void GeneralHelperClassGetNewIdMethodReturnsIdNotAlreadyInParameterContent()
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
    }
}
