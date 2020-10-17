using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;
using Timetabler.CoreData.Tests.Unit.Mocks;

namespace Timetabler.CoreData.Tests.Unit.Events
{
    [TestClass]
    public class ModifiedEventArgsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ModifiedEventArgsClass_Constructor_SetsModifiedItemPropertyToValueOfFirstParameter()
        {
            IWatchableItem testParam0 = new MockWatchableItem();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 20));

            ModifiedEventArgs testOutput = new ModifiedEventArgs(testParam0, testParam1);

            Assert.AreSame(testParam0, testOutput.ModifiedItem);
        }

        [TestMethod]
        public void ModifiedEventArgsClass_Constructor_SetsModifiedFieldPropertyToValueOfSecondParameter()
        {
            IWatchableItem testParam0 = new MockWatchableItem();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 20));

            ModifiedEventArgs testOutput = new ModifiedEventArgs(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.ModifiedField);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
