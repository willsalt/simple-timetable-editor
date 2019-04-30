using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class GenericEntryModelUnitTests
    {
        private static Random _rnd = new Random();

        [TestMethod]
        public void GenericEntryModelClassDisplayAdapterPropertyDisplayChangedMethodIsCalledWhenSetMethodIsCalled()
        {
            Mock<ILocationEntryDisplayAdapter> mockDisplayAdapter = new Mock<ILocationEntryDisplayAdapter>();
            GenericEntryModel testObject = new GenericEntryModel();

            testObject.DisplayAdapter = mockDisplayAdapter.Object;

            mockDisplayAdapter.Verify(m => m.DisplayedTextChanged(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void GenericEntryModelClassDisplayAdapterPropertyDisplayChangedMethodIsCalledWithCorrectParameterWhenSetMethodIsCalled()
        {
            Mock<ILocationEntryDisplayAdapter> mockDisplayAdapter = new Mock<ILocationEntryDisplayAdapter>();
            string testValue = _rnd.NextString(_rnd.Next(20) + 1);
            GenericEntryModel testObject = new GenericEntryModel { DisplayedText = testValue };

            testObject.DisplayAdapter = mockDisplayAdapter.Object;

            mockDisplayAdapter.Verify(m => m.DisplayedTextChanged(testValue), Times.Once());
        }

        [TestMethod]
        public void GenericEntryModelClassDisplayAdapterPropertyDisplayChangedMethodIsCalledWhenDisplayedTextPropertySetMethodIsCalled()
        {
            Mock<ILocationEntryDisplayAdapter> mockDisplayAdapter = new Mock<ILocationEntryDisplayAdapter>();
            string testValue = _rnd.NextString(_rnd.Next(20) + 1);
            GenericEntryModel testObject = new GenericEntryModel { DisplayAdapter = mockDisplayAdapter.Object };
            mockDisplayAdapter.Reset();

            testObject.DisplayedText = testValue;

            mockDisplayAdapter.Verify(m => m.DisplayedTextChanged(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void GenericEntryModelClassDisplayAdapterPropertyDisplayChangedMethodIsCalledWithCorrectParameterWHenDisplayedTextPropertySetMethodIsCalled()
        {
            Mock<ILocationEntryDisplayAdapter> mockDisplayAdapter = new Mock<ILocationEntryDisplayAdapter>();
            string testValue = _rnd.NextString(_rnd.Next(20) + 1);
            GenericEntryModel testObject = new GenericEntryModel { DisplayAdapter = mockDisplayAdapter.Object };
            mockDisplayAdapter.Reset();

            testObject.DisplayedText = testValue;

            mockDisplayAdapter.Verify(m => m.DisplayedTextChanged(testValue), Times.Once());
        }
    }
}
