using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.CoreData.Exceptions;

namespace Timetabler.CoreData.Tests.Unit.Exceptions
{
    [TestClass]
    public class TimetableLoaderExceptionUnitTests
    {
        private readonly Random _rnd = new Random();

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimetableLoaderExceptionClass_IsAnExceptionClass()
        {
            Assert.IsTrue(typeof(Exception).IsAssignableFrom(typeof(TimetableLoaderException)));
        }

        [TestMethod]
        public void TimetableLoaderExceptionClass_ConstructorWithNoParameters_SetsMessagePropertyToNonEmptyString()
        {
            TimetableLoaderException testException = new TimetableLoaderException();

            Assert.IsFalse(string.IsNullOrWhiteSpace(testException.Message));
        }

        [TestMethod]
        public void TimetableLoaderExceptionClass_ConstructorWithOneParameter_SetsMessagePropertyToParameter()
        {
            string testMessage = _rnd.NextString(_rnd.Next(1, 100));

            TimetableLoaderException testException = new TimetableLoaderException(testMessage);

            Assert.AreEqual(testMessage, testException.Message);
        }

        [TestMethod]
        public void TimetableLoaderExceptionClass_ConstructorWithTwoParameters_SetsMessagePropertyToFirstParameter()
        {
            string testMessage = _rnd.NextString(_rnd.Next(1, 100));
            Exception inner = new Exception();

            TimetableLoaderException testException = new TimetableLoaderException(testMessage, inner);

            Assert.AreEqual(testMessage, testException.Message);
        }

        [TestMethod]
        public void TimetableLoaderExceptionClass_ConstructorWithTwoParameters_SetsInnerExceptionPropertyToSecondParameter()
        {
            string testMessage = _rnd.NextString(_rnd.Next(1, 100));
            Exception inner = new Exception();

            TimetableLoaderException testException = new TimetableLoaderException(testMessage, inner);

            Assert.AreSame(inner, testException.InnerException);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
