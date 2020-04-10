using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Afm2Code.Extensions;

namespace Unicorn.FontTools.Afm2Code
{
    internal class FontMetricsCoder
    {
        internal static IEnumerable<string> FontMetricsToCode(AfmFontMetrics metrics)
        {
            yield return " AfmFontMetrics metrics = new AfmFontMetrics(";
            yield return metrics.FontName.ToCode() + ",";
            yield return metrics.FullName.ToCode() + ",";
            yield return metrics.FamilyName.ToCode() + ",";
            yield return metrics.Weight.ToCode() + ",";
            yield return metrics.FontBoundingBox.ToCode() + ",";
            yield return metrics.Version.ToCode() + ",";
            yield return metrics.Notice.ToCode() + ",";
            yield return metrics.EncodingScheme.ToCode() + ",";
            yield return metrics.MappingScheme.ToCode() + ",";
            yield return metrics.EscapeCharacter.ToCode() + ",";
            yield return metrics.CharacterSet.ToCode() + ",";
            yield return metrics.CharacterCount.ToCode() + ",";
            yield return metrics.IsBaseFont.ToCode() + ",";
            yield return metrics.VVector.ToCode() + ",";
            yield return metrics.IsFixedV.ToCode() + ",";
            yield return metrics.IsCIDFont.ToCode() + ",";
            yield return metrics.CapHeight.ToCode() + ",";
            yield return metrics.XHeight.ToCode() + ",";
            yield return metrics.Ascender.ToCode() + ",";
            yield return metrics.Descender.ToCode() + ",";
            yield return metrics.StdHW.ToCode() + ",";
            yield return metrics.StdVW.ToCode() + ",";
            yield return metrics.Direction0Metrics.ToCode() + ",";
            yield return metrics.Direction1Metrics.ToCode() + ");";
            foreach (Character c in metrics.Characters)
            {
                yield return $"metrics.AddChar({c.ToCode()});";
            }

            yield return "metrics.ProcessLigatures();";
            yield return "return metrics;";
        }
    }
}
