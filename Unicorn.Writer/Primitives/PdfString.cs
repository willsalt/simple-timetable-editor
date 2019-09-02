using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfString : IPdfPrimitiveObject, IEquatable<PdfString>
    {
        private byte[] cachedBytes = null;

        public string Value { get; }

        public int ByteLength
        {
            get
            {
                if (cachedBytes == null)
                {
                    GenerateEscapedString();
                }
                return cachedBytes.Length;
            }
        }

        public PdfString(string val)
        {
            Value = val;
        }

        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (cachedBytes == null)
            {
                GenerateEscapedString();
            }
            stream.Write(cachedBytes, 0, cachedBytes.Length);
            return cachedBytes.Length;
        }

        public int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (cachedBytes == null)
            {
                GenerateEscapedString();
            }
            list.AddRange(cachedBytes);
            return cachedBytes.Length;
        }

        private void GenerateEscapedString()
        {
            StringBuilder sb = new StringBuilder(Value);
            sb.Replace("\\", @"\\");
            sb.Replace("\xa", @"\n");
            sb.Replace("\xd", @"\r");
            sb.Replace("\t", @"\t");
            sb.Replace("\b", @"\b");
            sb.Replace("\f", @"\f");
            if (EscapeParenthesesNeeded())
            {
                sb.Replace("(", @"\(");
                sb.Replace(")", @"\)");
            }
            sb.Insert(0, "(");
            sb.Append(")");
            for (int i = 253; i < sb.Length; i += 253)
            {
                sb.Insert(i, "\\\n");
            }
            cachedBytes = Encoding.UTF8.GetBytes(sb.ToString());
        }

        private bool EscapeParenthesesNeeded()
        {
            int diff = 0;
            foreach (char c in Value)
            {
                if (c == '(')
                {
                    diff++;
                }
                else if (c == ')')
                {
                    diff--;
                    if (diff < 0)
                    {
                        return true;
                    }
                }
            }
            return diff != 0;
        }

        public bool Equals(PdfString other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PdfBoolean);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(PdfString a, PdfString b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a == null || b == null)
            {
                return false;
            }
            return a.Value == b.Value;
        }

        public static bool operator !=(PdfString a, PdfString b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            if (a == null || b == null)
            {
                return true;
            }
            return a.Value != b.Value;
        }
    }
}
