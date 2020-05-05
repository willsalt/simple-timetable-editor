using System;

namespace Unicorn.FontTools.OpenType.Extensions
{
    /// <summary>
    /// Helper methods for loading OpenType fonts.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Convert a pair of bytes into a <see cref="ushort" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="ushort" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter contains less than two elements.</exception>
        /// <exception cref="IndexOutOfRangeException">Throw if the idx parameter is less than zero.</exception>
        public static ushort ToUShort(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new NullReferenceException();
            }
            if (arr.Length < idx + 2)
            {
                throw new InvalidOperationException();
            }
            return (ushort)((arr[idx] << 8) | arr[idx + 1]);
        }

        /// <summary>
        /// Convert a pair of bytes into a <see cref="short" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="short" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter contains less than two elements.</exception>
        public static short ToShort(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new NullReferenceException();
            }
            if (arr.Length < idx + 2)
            {
                throw new InvalidOperationException();
            }
            return unchecked((short)((arr[idx] << 8) | arr[idx + 1]));
        }

        /// <summary>
        /// Convert four bytes into a <see cref="uint" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="uint" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter's length is less than four.</exception>
        public static uint ToUInt(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new NullReferenceException();
            }
            if (arr.Length < idx + 4)
            {
                throw new InvalidOperationException();
            }
            return ((uint)arr[idx] << 24) | ((uint)arr[idx + 1] << 16) | ((uint)arr[idx + 2] << 8) | arr[idx + 3];
        }

        /// <summary>
        /// Convert four bytes into a <see cref="int" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="int" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter's length is less than four.</exception>
        public static int ToInt(this byte[] arr, int idx = 0)
        {
            return unchecked((int)ToUInt(arr, idx));
        }

        /// <summary>
        /// Convert four bytes to a "fixed" value, returned as decimal.  The fixed format is a signed 32-bit fixed-point format with 16 bits for the integral part and 
        /// 16 bits for the fractional part.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns></returns>
        public static decimal ToFixed(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new NullReferenceException();
            }
            if (arr.Length < idx + 4)
            {
                throw new InvalidOperationException();
            }
            
            return unchecked((arr[idx] << 24) | (arr[idx + 1] << 16) | (arr[idx + 2] << 8) | arr[idx + 3]) / 65536m;
        }

        /// <summary>
        /// Convert 8 bytes to an <see cref="ulong" /> value.
        /// </summary>
        /// <param name="arr">The array to convert.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>The value converted from the first 8 bytes of the array.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter contains fewer than 8 elements.</exception>
        public static ulong ToULong(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new NullReferenceException();
            }
            if (arr.Length < idx + 8)
            {
                throw new InvalidOperationException();
            }

            return ((ulong)arr[idx] << 56) | ((ulong)arr[idx + 1] << 48) | ((ulong)arr[idx + 2] << 40) | ((ulong)arr[idx + 3] << 32) | ((ulong)arr[idx + 4] << 24) | 
                ((ulong)arr[idx + 5] << 16) | ((ulong)arr[idx + 6] << 8) | arr[idx + 7];
        }

        /// <summary>
        /// Convert 8 bytes to an <see cref="long" /> value.
        /// </summary>
        /// <param name="arr">The array to convert.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>The value converted from the first 8 bytes of the array.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter contains fewer than 8 elements.</exception>
        public static long ToLong(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new NullReferenceException();
            }
            if (arr.Length < idx + 8)
            {
                throw new InvalidOperationException();
            }

            return unchecked(((long)arr[idx] << 56) | ((long)arr[idx + 1] << 48) | ((long)arr[idx + 2] << 40) | ((long)arr[idx + 3] << 32) | 
                ((long)arr[idx + 4] << 24) | ((long)arr[idx + 5] << 16) | ((long)arr[idx + 6] << 8) | arr[idx + 7]);
        }

        /// <summary>
        /// Convert 8 bytes to a <see cref="DateTime" /> value, by interpreting it as the number of seconds since the start of 1904.
        /// </summary>
        /// <param name="arr">The array of bytes to convert.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="DateTime" /> converted from the first 8 bytes of the parameter array.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter has fewer than 8 elements.</exception>
        public static DateTime ToDateTime(this byte[] arr, int idx = 0)
        {
            long offset = ToLong(arr, idx);
            // This is the number of seconds from 1st January 1904 (the epoch for the OpenType format) to 31st December 1999 
            // (the largest value representable by DateTime)
            if (offset > 255_485_232_000)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new DateTime(1904, 1, 1).AddTicks(offset * 10_000_000);
        }

        /// <summary>
        /// Convert 8 bytes to a <see cref="LowerUnicodeRangeFlags" /> value, by interpreting the first 4 bytes as an unsigned int containing the lower 32 bits
        /// of the value and the second 4 bytes as an unsigned int containing the upper 32 bits of the value.
        /// </summary>
        /// <param name="arr">The array of bytes to convert.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="LowerUnicodeRangeFlags" /> value converted from the 8 bytes of the parameter array starting with the offset.</returns>
        /// <exception cref="NullReferenceException">Thrown if the array parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the offset is less than 8 bytes before the end of the array.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if the offset is negative.</exception>
        public static LowerUnicodeRangeFlags ToLowerUnicodeRangeFlags(this byte[] arr, int idx = 0)
        {
            return (LowerUnicodeRangeFlags)ToULongBackwards(arr, idx);
        }

        /// <summary>
        /// Convert 8 bytes to a <see cref="UpperUnicodeRangeFlags" /> value, by interpreting the first 4 bytes as an unsigned int containing the lower 32 bits
        /// of the value and the second 4 bytes as an unsigned int containing the upper 32 bits of the value.
        /// </summary>
        /// <param name="arr">The array of bytes to convert.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="UpperUnicodeRangeFlags" /> value converted from the 8 bytes of the parameter array starting with the offset.</returns>
        /// <exception cref="NullReferenceException">Thrown if the array parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the offset is less than 8 bytes before the end of the array.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if the offset is negative.</exception>
        public static UpperUnicodeRangeFlags ToUpperUnicodeRangeFlags(this byte[] arr, int idx = 0)
        {
            return (UpperUnicodeRangeFlags)ToULongBackwards(arr, idx);
        }

        /// <summary>
        /// Convert 8 bytes to a <see cref="SupportedCodePageFlags" /> value, by interpreting the first 4 bytes as an unsigned int containing the lower 32 bits
        /// of the value and the second 4 bytes as an unsigned int containing the upper 32 bits of the value.
        /// </summary>
        /// <param name="arr">The array of bytes to convert.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="SupportedCodePageFlags" /> value converted from the 8 bytes of the parameter array starting with the offset.</returns>
        /// <exception cref="NullReferenceException">Thrown if the array parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the offset is less than 8 bytes before the end of the array.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if the offset is negative.</exception>
        public static SupportedCodePageFlags ToSupportedCodePageFlags(this byte[] arr, int idx = 0)
        {
            return (SupportedCodePageFlags)ToULongBackwards(arr, idx);
        }

        private static ulong ToULongBackwards(byte[] arr, int idx)
        {
            uint lower = arr.ToUInt(idx);
            uint upper = arr.ToUInt(idx + 4);
            return lower | ((ulong)upper << 32);
        }
    }
}
