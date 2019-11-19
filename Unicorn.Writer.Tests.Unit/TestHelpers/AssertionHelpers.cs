using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.TestHelpers
{
    public class AssertionHelpers
    {
        public static void AssertSameElements(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
            {
                return;
            }
            Assert.AreEqual(a.Length, b.Length);
            for (int i = 0; i < a.Length; ++i)
            {
                Assert.AreEqual(a[i], b[i]);
            }
        }

        public static void AssertSameElements(List<byte> a, List<byte> b)
        {
            if (ReferenceEquals(a, b))
            {
                return;
            }
            AssertSameElements(a.ToArray(), b.ToArray());
        }

        public static void AssertSameElements(MemoryStream a, MemoryStream b)
        {
            if (ReferenceEquals(a, b))
            {
                return;
            }
            Assert.AreEqual(a.Length, b.Length);
            byte[] arrA = a.ToArray();
            byte[] arrB = b.ToArray();
            AssertSameElements(arrA, arrB);
        }

        public static void AssertSameElements(List<byte> a, PdfStream b)
        {
            if (a == null && b == null)
            {
                return;
            }
            AssertSameElements(a, b.Contents);
        }
    }
}
