﻿using System;
using Unicorn.Interfaces;
using Unicorn.FontTools.Afm;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;

namespace Unicorn.FontTools
{
    /// <summary>
    /// A font descriptor for one of the PDF standard fonts.  Instances are created by calling <see cref="GetByName(string, double)"/>.
    /// </summary>
    public class PdfStandardFontDescriptor : IFontDescriptor
    {
        private readonly AfmFontMetrics _metrics;

        /// <summary>
        /// The point size of this font.
        /// </summary>
        public double PointSize { get; private set; }

        /// <summary>
        /// The height of the largest ascender above the baseline.  By convention the ascender of 'd' is used.
        /// </summary>
        public double Ascent => PointSizeTransform(_metrics.Ascender ?? 0m);

        /// <summary>
        /// The depth of the largest descender below the baseline.  By convention the descender of 'p' is used.
        /// </summary>
        public double Descent => PointSizeTransform(_metrics.Descender ?? 0m);

        /// <summary>
        /// Constructor.
        /// </summary>
        internal PdfStandardFontDescriptor(AfmFontMetrics metrics, double pointSize)
        {
            _metrics = metrics;
            PointSize = pointSize;
        }

        /// <summary>
        /// Create a <see cref="PdfStandardFontDescriptor" /> instance from a font name and point size.  This method can only create descriptors for fonts that 
        /// have been coded into the library: it assumes that the <see cref="StandardFontMetrics" /> class will have a static property which matches the paramter,
        /// once that name has been normalised by removing hyphens.
        /// </summary>
        /// <param name="name">The name of the font to load, such as "Times-Roman".</param>
        /// <param name="pointSize"></param>
        /// <returns></returns>
        public static PdfStandardFontDescriptor GetByName(string name, double pointSize)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new FontException(Resources.PdfStandardFontDescriptor_GetByName_EmptyStringParameter);
            }
            string typeName = NormaliseName(name);
            PropertyInfo property = typeof(StandardFontMetrics).GetProperty(typeName, BindingFlags.Public | BindingFlags.Static);
            if (property is null)
            {
                throw new FontException(string.Format(CultureInfo.CurrentCulture, Resources.PdfStandardFontDescriptor_GetByName_FontNotFoundByReflection, typeName));
            }
            return new PdfStandardFontDescriptor((AfmFontMetrics)property.GetValue(null), pointSize);
        }

        /// <summary>
        /// Returns an enumeration of the font names supported by the <see cref="GetByName(string, double)"/> method.  Only one form of each name is returned: 
        /// for example, the <see cref="GetByName(string, double)"/> method returns the same results for both "Times-Roman" and "TimesRoman", but only the 
        /// first is included in the output of this method, as that is the name described in the font's AFM file.
        /// </summary>
        /// <returns>An enumeration of strings that are valid standard font names.</returns>
        public static IEnumerable<string> GetSupportedFontNames()
        {
            return StandardFontMetrics.GetSupportedFontNames();
        }

        /// <summary>
        /// Get the width of a space character in this font, in a specific graphics context.
        /// </summary>
        /// <param name="context">The graphics context in which this should be measured.</param>
        /// <returns>The width of a space character in graphics context units.</returns>
        public double GetNormalSpaceWidth(IGraphicsContext context)
        {
            if (context is null)
            {
                return MeasureStringWidth(Resources.SpaceCharacter);
            }
            return context.MeasureString(Resources.SpaceCharacter, this).Width;
        }

        /// <summary>
        /// Measure the width of a string, in points.
        /// </summary>
        /// <param name="str">The string to measure.</param>
        /// <returns>The width of the string, in points.</returns>
        public double MeasureStringWidth(string str)
        {
            return PointSizeTransform(_metrics.MeasureStringWidth(str));
        }

        /// <summary>
        /// Measure the size of a string, in Unicorn points.
        /// </summary>
        /// <param name="str">The string to be measured.</param>
        /// <returns>A <see cref="UniSize" /> instance describing the size of the rendered string.</returns>
        public UniSize MeasureString(string str)
        {
            return new UniSize(MeasureStringWidth(str), PointSizeTransform((_metrics.Ascender ?? 0) + (_metrics.Descender ?? 0)));
        }

        private static string NormaliseName(string fontName)
        {
            return fontName.Replace("-", "");
        }

        private double PointSizeTransform(decimal fontUnitValue)
        {
            return (double)(fontUnitValue * (decimal)PointSize / 1000);
        }
    }
}
