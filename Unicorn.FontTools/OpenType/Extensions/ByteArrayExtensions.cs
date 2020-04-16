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
        /// <returns>A <see cref="ushort" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter contains less than two elements.</exception>
        public static ushort ToUShort(this byte[] arr)
        {
            if (arr is null)
            {
                throw new NullReferenceException();
            }
            if (arr.Length < 2)
            {
                throw new InvalidOperationException();
            }
            return (ushort)((arr[0] << 8) | arr[1]);
        }

        /// <summary>
        /// Convert four bytes into a <see cref="uint" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <returns>A <see cref="uint" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter's length is less than four.</exception>
        public static uint ToUInt(this byte[] arr)
        {
            if (arr is null)
            {
                throw new NullReferenceException();
            }
            if (arr.Length < 4)
            {
                throw new InvalidOperationException();
            }
            return (uint)((arr[0] << 24) | (arr[1] << 16) | (arr[2] << 8) | arr[3]);
        }
    }
}
