﻿using System;
using System.Collections.Generic;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Afm2Code.Extensions;

namespace Unicorn.FontTools.Afm2Code
{
    internal class FontMetricsCoder
    {
        internal static IEnumerable<string> FontMetricsToCode(AfmFontMetrics metrics, int indentLen)
        {
            const string tab = "    ";
            string indent = new string(' ', indentLen);

            Func<AfmFontMetrics, string>[] constructorFuncs = new Func<AfmFontMetrics, string>[]
            {
                m => "AfmFontMetrics metrics = new AfmFontMetrics(",
                m => tab + m.FontName.ToCode() + ",",
                m => tab + m.FamilyName.ToCode() + ",",
                m => tab + m.Weight.ToCode() + ",",
                m => tab + m.FontBoundingBox.ToCode() + ",",
                m => tab + m.Version.ToCode() + ",",
                m => tab + m.Notice.ToCode() + ",",
                m => tab + m.EncodingScheme.ToCode() + ",",
                m => tab + m.MappingScheme.ToCode() + ",",
                m => tab + m.EscapeCharacter.ToCode() + ",",
                m => tab + m.CharacterSet.ToCode() + ",",
                m => tab + m.CharacterCount.ToCode() + ",",
                m => tab + m.IsBaseFont.ToCode() + ",",
                m => tab + m.VVector.ToCode() + ",",
                m => tab + m.IsFixedV.ToCode() + ",",
                m => tab + m.IsCIDFont.ToCode() + ",",
                m => tab + m.CapHeight.ToCode() + ",",
                m => tab + m.XHeight.ToCode() + ",",
                m => tab + m.Ascender.ToCode() + ",",
                m => tab + m.Descender.ToCode() + ",",
                m => tab + m.StdHW.ToCode() + ",",
                m => tab + m.StdVW.ToCode() + ",",
                m => tab + m.Direction0Metrics.ToCode() + ",",
                m => tab + m.Direction1Metrics.ToCode() + ");",
            };
            foreach (Func<AfmFontMetrics, string> fn in constructorFuncs)
            {
                yield return indent + fn(metrics);
            }
            foreach (Character c in metrics.Characters)
            {
                yield return indent + $"metrics.AddChar({c.ToCode()});";
            }
            foreach (Character c in metrics.Characters)
            { 
                foreach (KerningPair kp in c.KerningPairs)
                {
                    yield return indent + $"metrics.AddKerningPair(new KerningPair({CharacterLookup(c, "metrics")}, {CharacterLookup(kp.Second, "metrics")}, " +
                        $"{kp.KerningVector.ToCode()});";
                }
            }

            yield return indent + "metrics.ProcessLigatures();";
            yield return indent + "return metrics;";
        }

        private static string CharacterLookup(Character c, string varName)
        {
            if (!string.IsNullOrWhiteSpace(c.Name))
            {
                return $" {varName}.CharactersByName[{c.Name.ToCode()}]";
            }
            if (c.Code.HasValue)
            {
                return $" {varName}.CharactersByCode[({c.Code.ToCode()}).Value]";
            }
            return " (Unicorn.FontTools.Afm.Character)null ";
        }
    }
}
