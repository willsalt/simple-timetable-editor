using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.PdfExport.Extensions;

namespace Timetabler.PdfExport.Tests.Unit.Extensions
{
    [TestClass]
    public class DirectionExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DirectionExtensionsClass_OppositeMethod_ReturnsUp_IfParameterEqualsDown()
        {
            Direction testParam = Direction.Down;

            Direction testOutput = testParam.Opposite();

            Assert.AreEqual(Direction.Up, testOutput);
        }

        [TestMethod]
        public void DirectionExtensionsClass_OppositeMethod_ReturnsDown_IfParameterEqualsUp()
        {
            Direction testParam = Direction.Up;

            Direction testOutput = testParam.Opposite();

            Assert.AreEqual(Direction.Down, testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void DirectionExtensionsClass_OppositeMethod_ReturnsValueEqualToParameter_IfParameterIsNotAValidDirectionValue()
        {
            Direction testParam;
            do
            {
                testParam = (Direction)_rnd.Next();
            } while (testParam == Direction.Down || testParam == Direction.Up);
            Direction expectedValue = testParam;

            Direction testOutput = testParam.Opposite();

            Assert.AreEqual(expectedValue, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
