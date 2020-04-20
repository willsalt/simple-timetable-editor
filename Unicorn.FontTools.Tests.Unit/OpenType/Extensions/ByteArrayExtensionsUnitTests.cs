using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
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

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
