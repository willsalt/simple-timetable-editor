using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfString : IPdfPrimitiveObject
    {
        private readonly string _val;
        private string cachedEscaped = null;

        public string Value => _val;

        public PdfString(string val)
        {
            _val = val;
        }

        public int WriteTo(Stream stream)
        {
            if (cachedEscaped == null)
            {
                GenerateEscapedString();
            }
            byte[] output = Encoding.UTF8.GetBytes(cachedEscaped);
            stream.Write(output, 0, output.Length);
            return output.Length;
        }

        private void GenerateEscapedString()
        {
            StringBuilder sb = new StringBuilder(_val);
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
            cachedEscaped = sb.ToString();
        }

        private bool EscapeParenthesesNeeded()
        {
            int diff = 0;
            bool open = false;
            foreach (char c in _val)
            {
                if (c == '(')
                {
                    open = true;
                    diff++;
                }
                if (c == ')')
                {
                    if (!open)
                    {
                        return true;
                    }
                    diff--;
                }
            }
            return diff != 0;
        }
    }
}
