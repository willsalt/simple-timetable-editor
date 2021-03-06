﻿using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.FontTools.Afm2Code.Extensions;

namespace Unicorn.FontTools.Afm2Code
{
    internal class ClassCoder
    {
        private string Namespace { get; set; }

        private string ClassName { get; set; }

        private static readonly string _rn = Environment.NewLine;

        internal ClassCoder(string nameSpace, string className)
        {
            Namespace = nameSpace;
            ClassName = className;
        }

        internal string OutputStart(IEnumerable<string> fileNames)
        {
            string output = $"// This file was generated by {GetType().Assembly.FullName}{_rn}";
            if (fileNames != null)
            {
                string[] names = fileNames.ToArray();
                if (names.Length > 0)
                {
                    output += "// The code was generated from the following files:" + _rn;
                    foreach (string n in names)
                    {
                        output += $"//      {n}{_rn}";
                    }
                }
                output += "// Please regenerate this file instead of editing it by hand." + _rn + _rn;
            }
            return output + $"using System.Collections.Generic;{_rn}{_rn}namespace {Namespace}{_rn}{{{_rn}    /// <summary>{_rn}    " +
                $"/// Embedded font metrics generated from AFM files at or before build time.{_rn}    /// </summary>{_rn}" +
                $"    public static class {ClassName}{_rn}    {{{_rn}";
        }

        internal static string OutputSupportedFonts(IEnumerable<string> fontNames, int indentLen)
        {
            string indent = new string(' ', indentLen);
            const string tab = "    ";
            return $"{indent}/// <summary>{_rn}{indent}/// Lists the built-in font metrics.{_rn}{indent}/// </summary>{_rn}" + 
                $"{indent}/// <returns>An enumeration of the known font names (in the form defined in the AFM file.</returns>{_rn}" +
                $"{indent}public static IEnumerable<string> GetSupportedFontNames(){_rn}{indent}{{{_rn}{indent}{tab}return new [] {{ "
                + string.Join(", ", fontNames.Select(s => s.ToCode())) + $" }};{_rn}{indent}}}{_rn}{_rn}";
        }

        internal static string OutputEnd()
        {
            return $"    }}{_rn}}}{_rn}";
        }
    }
}
