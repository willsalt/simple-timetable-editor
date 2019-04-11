using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Timetabler.CoreData.Exceptions;

namespace Timetabler.CoreData.Tests.Unit.Exceptions
{
    [TestClass]
    public class TimetableLoaderExceptionUnitTests
    {
        private Random _random = new Random();

        [TestMethod]
        public void TimetableLoaderExceptionClassIsAnExceptionClass()
        {
            Assert.IsTrue(typeof(Exception).IsAssignableFrom(typeof(TimetableLoaderException)));
        }

        [TestMethod]
        public void TimetableLoaderExceptionClassConstructorWithOneParameterSetsMessagePropertyToParameter()
        {
            string testMessage = _random.NextString(_random.Next(1, 100));

            TimetableLoaderException testException = new TimetableLoaderException(testMessage);

            Assert.AreEqual(testMessage, testException.Message);
        }

        [TestMethod]
        public void TimetableLoaderExceptionClassConstructorWithTwoParametersSetsMessagePropertyToFirstParameter()
        {
            string testMessage = _random.NextString(_random.Next(1, 100));
            Exception inner = new Exception();

            TimetableLoaderException testException = new TimetableLoaderException(testMessage, inner);

            Assert.AreEqual(testMessage, testException.Message);
        }

        [TestMethod]
        public void TimetableLoaderExceptionClassConstructorWithTwoParametersSetsInnerExceptionPropertyToSecondParameter()
        {
            string testMessage = _random.NextString(_random.Next(1, 100));
            Exception inner = new Exception();

            TimetableLoaderException testException = new TimetableLoaderException(testMessage, inner);

            Assert.AreSame(inner, testException.InnerException);
        }
    }
}
