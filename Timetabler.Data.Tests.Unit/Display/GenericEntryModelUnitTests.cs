using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class GenericEntryModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void GenericEntryModelClass_DisplayAdapterPropertyDisplayChangedMethod_IsCalledWhenSetMethodIsCalled()
        {
            Mock<ILocationEntryDisplayAdapter> mockDisplayAdapter = new Mock<ILocationEntryDisplayAdapter>();
            GenericEntryModel testObject = new GenericEntryModel();

            testObject.DisplayAdapter = mockDisplayAdapter.Object;

            mockDisplayAdapter.Verify(m => m.DisplayedTextChanged(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void GenericEntryModelClass_DisplayAdapterPropertyDisplayChangedMethod_IsCalledWithCorrectParameterWhenSetMethodIsCalled()
        {
            Mock<ILocationEntryDisplayAdapter> mockDisplayAdapter = new Mock<ILocationEntryDisplayAdapter>();
            string testValue = _rnd.NextString(_rnd.Next(20) + 1);
            GenericEntryModel testObject = new GenericEntryModel { DisplayedText = testValue };

            testObject.DisplayAdapter = mockDisplayAdapter.Object;

            mockDisplayAdapter.Verify(m => m.DisplayedTextChanged(testValue), Times.Once());
        }

        [TestMethod]
        public void GenericEntryModelClass_DisplayAdapterPropertyDisplayChangedMethod_IsCalledWhenDisplayedTextPropertySetMethodIsCalled()
        {
            Mock<ILocationEntryDisplayAdapter> mockDisplayAdapter = new Mock<ILocationEntryDisplayAdapter>();
            string testValue = _rnd.NextString(_rnd.Next(20) + 1);
            GenericEntryModel testObject = new GenericEntryModel { DisplayAdapter = mockDisplayAdapter.Object };
            mockDisplayAdapter.Reset();

            testObject.DisplayedText = testValue;

            mockDisplayAdapter.Verify(m => m.DisplayedTextChanged(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void GenericEntryModelClass_DisplayAdapterPropertyDisplayChangedMethod_IsCalledWithCorrectParameterWhenDisplayedTextPropertySetMethodIsCalled()
        {
            Mock<ILocationEntryDisplayAdapter> mockDisplayAdapter = new Mock<ILocationEntryDisplayAdapter>();
            string testValue = _rnd.NextString(_rnd.Next(20) + 1);
            GenericEntryModel testObject = new GenericEntryModel { DisplayAdapter = mockDisplayAdapter.Object };
            mockDisplayAdapter.Reset();

            testObject.DisplayedText = testValue;

            mockDisplayAdapter.Verify(m => m.DisplayedTextChanged(testValue), Times.Once());
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
