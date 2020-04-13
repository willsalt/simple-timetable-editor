using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Interfaces;
using Unicorn.FontTools.Afm;
using System.Reflection;

namespace Unicorn.FontTools
{
    public class PdfStandardFontDescriptor : IFontDescriptor
    {
        private AfmFontMetrics _metrics;

        public double PointSize { get; private set; }

        public double Ascent => throw new NotImplementedException();

        public double Descent => throw new NotImplementedException();

        private PdfStandardFontDescriptor()
        {
        }

        public static PdfStandardFontDescriptor GetByName(string name, double pointSize)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new FontException("No font name specified.");
            }
            string typeName = NormaliseName(name);
            PropertyInfo property = typeof(StandardFontMetrics).GetProperty(typeName, BindingFlags.Static);
            if (property is null)
            {
                throw new FontException(string.Format("Built-in font property StandardFontMetrics.{0} not found.", typeName));
            }
            PdfStandardFontDescriptor descriptor = new PdfStandardFontDescriptor();
            descriptor._metrics = (AfmFontMetrics)property.GetValue(null);
            descriptor.PointSize = pointSize;
            return descriptor;
        }

        public double GetNormalSpaceWidth(IGraphicsContext context)
        {
            throw new NotImplementedException();
        }

        private static string NormaliseName(string fontName)
        {
            return fontName.Replace("-", "");
        }
    }
}
