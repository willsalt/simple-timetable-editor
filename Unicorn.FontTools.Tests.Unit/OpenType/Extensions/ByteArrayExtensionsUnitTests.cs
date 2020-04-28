﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.Tests.Unit.OpenType.Extensions
{
    [TestClass]
    public class ByteArrayExtensionsUnitTests
    {
        private readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[1];
            int testParam1 = 0;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToUShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);

            ushort testOutput = testParam0.ToUShort(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            ushort testOutput = testParam0.ToUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(short.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            ushort testOutput = testParam0.ToUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            ushort expectedValue = (ushort)_rnd.Next(short.MaxValue, ushort.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            ushort testOutput = testParam0.ToUShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[1];
            int testParam1 = 0;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToShortMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsTwoOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToShort(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToShortMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = (short)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = (short)_rnd.Next(short.MaxValue);
            testParam0[testParam1] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsMinus1()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = -1;
            testParam0[testParam1] = 0xff;
            testParam0[testParam1 + 1] = 0xff;

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUShortMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(2, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 1);
            short expectedValue = (short)_rnd.Next(short.MinValue, 0);
            testParam0[testParam1] = (byte)((unchecked((ushort)expectedValue) & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(expectedValue & 0xff);

            short testOutput = testParam0.ToShort(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToUIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToUInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(0u, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next(short.MaxValue);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = (uint)_rnd.Next();
            testParam0[testParam1] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToUIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            uint expectedValue = ((uint)_rnd.Next()) * 2 + (uint)_rnd.Next(2);
            testParam0[testParam1] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            uint testOutput = testParam0.ToUInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToIntMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToInt(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(short.MaxValue);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveAndWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next();
            testParam0[testParam1] = (byte)(unchecked(expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsMinusOne()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = -1;
            testParam0[testParam1] = 0xff;
            testParam0[testParam1 + 1] = 0xff;
            testParam0[testParam1 + 2] = 0xff;
            testParam0[testParam1 + 3] = 0xff;

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToIntMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeAndWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            int expectedValue = _rnd.Next(int.MinValue, 0);
            testParam0[testParam1] = (byte)(unchecked(expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(expectedValue & 0xff);

            int testOutput = testParam0.ToInt(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToThreeAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 3)];
            int testParam1 = 0;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToFixedMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsFourOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToFixed(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToFixedMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveInteger()
        {
            short valueData = _rnd.NextShort();
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            decimal expectedValue = valueData;
            testParam0[testParam1] = (byte)((valueData & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(valueData & 0xff);

            decimal testOutput = testParam0.ToFixed(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToFixedMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeInteger()
        {
            short valueData = (short)_rnd.Next(short.MinValue, 0);
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            decimal expectedValue = valueData;
            testParam0[testParam1] = (byte)(unchecked((ushort)valueData & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(valueData & 0xff);

            decimal testOutput = testParam0.ToFixed(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToFixedMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsPositiveReal()
        {
            short valueData0 = _rnd.NextShort();
            ushort valueData1 = _rnd.NextUShort();
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            decimal expectedValue = valueData0 + (valueData1 / 65536m);
            testParam0[testParam1] = (byte)((valueData0 & 0xff00) >> 8);
            testParam0[testParam1 + 1] = (byte)(valueData0 & 0xff);
            testParam0[testParam1 + 2] = (byte)((valueData1 & 0xff00) >> 8);
            testParam0[testParam1 + 3] = (byte)(valueData1 & 0xff);

            decimal testOutput = testParam0.ToFixed(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToFixedMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsNegativeReal()
        {
            decimal expectedValue = _rnd.Next(int.MinValue, 0) / 65536m;
            byte[] testParam0 = new byte[_rnd.Next(4, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 3);
            testParam0[testParam1] = (byte)((unchecked((uint)(int)(expectedValue * 65536)) & 0xff000000) >> 24);
            testParam0[testParam1 + 1] = (byte)((unchecked((uint)(int)(expectedValue * 65536)) & 0xff0000) >> 16); ;
            testParam0[testParam1 + 2] = (byte)((unchecked((uint)(int)(expectedValue * 65536)) & 0xff00) >> 8); ;
            testParam0[testParam1 + 3] = (byte)(unchecked((uint)(int)(expectedValue * 65536)) & 0xff); ;

            decimal testOutput = testParam0.ToFixed(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsZeroAndSecondParameterIsZero()
        {
            byte[] testParam0 = Array.Empty<byte>();
            int testParam1 = 0;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsOneToSevenAndSecondParameterIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(1, 7)];
            int testParam1 = 0;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsIndexOutOfRangeException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsLessThanZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = -_rnd.Next();

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsGreaterThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length + 1, int.MaxValue);

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsEqualToLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsOneLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 1;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsTwoLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 2;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsThreeLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 3;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFourLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 4;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsFiveLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 5;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSixLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 6;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ByteArrayExtensionsClass_ToULongMethod_ThrowsInvalidOperationException_IfFirstParameterLengthIsEightOrGreaterAndSecondParameterIsSevenLessThanLengthOfFirstParameter()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = testParam0.Length - 7;

            _ = testParam0.ToULong(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToULongMethod_ReturnsZero_IfParametersAreValidAndInputDataIsZero()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);

            ulong testOutput = testParam0.ToULong(testParam1);

            Assert.AreEqual(0u, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToULongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfByte()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            ulong expectedValue = (ulong)_rnd.Next(byte.MaxValue);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            ulong testOutput = testParam0.ToULong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToULongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfShort()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            ulong expectedValue = (ulong)_rnd.Next(short.MaxValue);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            ulong testOutput = testParam0.ToULong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToULongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            ulong expectedValue = (ulong)_rnd.Next();
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            ulong testOutput = testParam0.ToULong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToULongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfUInt()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            ulong expectedValue = _rnd.NextUInt();
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            ulong testOutput = testParam0.ToULong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void ByteArrayExtensionsClass_ToULongMethod_ReturnsCorrectValue_IfParametersAreValidAndExpectedValueIsWithinRangeOfULong()
        {
            byte[] testParam0 = new byte[_rnd.Next(8, 64)];
            int testParam1 = _rnd.Next(testParam0.Length - 7);
            ulong expectedValue = _rnd.NextULong();
            testParam0[testParam1] = (byte)((expectedValue & 0xff00000000000000) >> 56);
            testParam0[testParam1 + 1] = (byte)((expectedValue & 0xff000000000000) >> 48);
            testParam0[testParam1 + 2] = (byte)((expectedValue & 0xff0000000000) >> 40);
            testParam0[testParam1 + 3] = (byte)((expectedValue & 0xff00000000) >> 32);
            testParam0[testParam1 + 4] = (byte)((expectedValue & 0xff000000) >> 24);
            testParam0[testParam1 + 5] = (byte)((expectedValue & 0xff0000) >> 16);
            testParam0[testParam1 + 6] = (byte)((expectedValue & 0xff00) >> 8);
            testParam0[testParam1 + 7] = (byte)(expectedValue & 0xff);

            ulong testOutput = testParam0.ToULong(testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
