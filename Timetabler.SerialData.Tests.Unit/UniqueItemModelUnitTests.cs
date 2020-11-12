using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tests.Utility.Providers;
using Timetabler.SerialData.Tests.Unit.Mocks;

namespace Timetabler.SerialData.Tests.Unit
{
    [TestClass]
    public class UniqueItemModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static MockUniqueItemModel[] GetTestData(bool withBlanks)
        {
            int baseCount = _rnd.Next(1, 25);
            List<MockUniqueItemModel> data = new List<MockUniqueItemModel>(baseCount);
            for (int i = 0; i < baseCount; ++i)
            {
                if (withBlanks && _rnd.Next(2) == 0)
                {
                    data.Add(new MockUniqueItemModel { Id = null });
                }
                else
                {
                    string n;
                    do
                    {
                        n = _rnd.Next().ToString("x8", CultureInfo.InvariantCulture);
                    } while (data.Any(i => i.Id == n));
                    data.Add(new MockUniqueItemModel { Id = n });
                }
            }
            if (withBlanks && data.All(i => i.Id != null))
            {
                data.Add(new MockUniqueItemModel { Id = null });
            }
            return data.ToArray();
        }

        private static MockUniqueItemModel[] CopyTestData(IList<MockUniqueItemModel> data)
        {
            MockUniqueItemModel[] copy = new MockUniqueItemModel[data.Count];
            for (int i = 0; i < copy.Length; ++i)
            {
                copy[i] = new MockUniqueItemModel { Id = data[i].Id };
            }
            return copy;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniqueItemModelClass_DoesNotThrowException_IfParameterIsNull()
        {
            MockUniqueItemModel[] testParam0 = null;

            UniqueItemModel.PopulateMissingIds(testParam0);

            Assert.IsNull(testParam0);
        }

        [TestMethod]
        public void UniqueItemModelClass_DoesNotModifyDataInParameter_IfAllItemsInParameterHaveIdPropertyPopulated()
        {
            MockUniqueItemModel[] testParam0 = GetTestData(false);
            MockUniqueItemModel[] testParam0Copy = CopyTestData(testParam0);

            UniqueItemModel.PopulateMissingIds(testParam0);

            for (int i = 0; i < testParam0.Length; ++i)
            {
                Assert.AreEqual(testParam0Copy[i].Id, testParam0[i].Id);
            }
        }

        [TestMethod]
        public void UniqueItemModelClass_DoesNotModifyNonNullDataInParameter()
        {
            MockUniqueItemModel[] testParam0 = GetTestData(true);
            MockUniqueItemModel[] testParam0Copy = CopyTestData(testParam0);

            UniqueItemModel.PopulateMissingIds(testParam0);

            for (int i = 0; i < testParam0.Length; ++i)
            {
                if (testParam0Copy[i].Id != null)
                {
                    Assert.AreEqual(testParam0Copy[i].Id, testParam0[i].Id);
                }
            }
        }

        [TestMethod]
        public void UniqueItemModelClass_ReplacesNullDataInParameterWithNonNullValues()
        {
            MockUniqueItemModel[] testParam0 = GetTestData(true);
            MockUniqueItemModel[] testParam0Copy = CopyTestData(testParam0);

            UniqueItemModel.PopulateMissingIds(testParam0);

            for (int i = 0; i < testParam0.Length; ++i)
            {
                if (testParam0Copy[i].Id == null)
                {
                    Assert.IsNotNull(testParam0[i].Id);
                }
            }
        }

        [TestMethod]
        public void UniqueItemModelClass_ReplacesNullDataInParameterWithValuesNotInOriginalData()
        {
            MockUniqueItemModel[] testParam0 = GetTestData(true);
            MockUniqueItemModel[] testParam0Copy = CopyTestData(testParam0);

            UniqueItemModel.PopulateMissingIds(testParam0);

            for (int i = 0; i < testParam0.Length; ++i)
            {
                if (testParam0Copy[i].Id == null)
                {
                    Assert.IsFalse(testParam0Copy.Any(x => x.Id == testParam0[i].Id));
                }
            }
        }

        [TestMethod]
        public void UniqueItemModelClass_ReplacesNullDataInParameterWithUniqueValues()
        {
            MockUniqueItemModel[] testParam0 = GetTestData(true);

            UniqueItemModel.PopulateMissingIds(testParam0);

            for (int i = 0; i < testParam0.Length; ++i)
            {
                Assert.AreEqual(1, testParam0.Count(x => x.Id == testParam0[i].Id));
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
