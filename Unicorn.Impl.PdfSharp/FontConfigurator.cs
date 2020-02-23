using NLog;
using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Unicorn.Interfaces;

namespace Unicorn.Impl.PdfSharp
{
    /// <summary>
    /// This class is used to set up the PdfSharp font contiguration.  This is a slightly awkward and restricted process, prone to making your program explode if it is done wrongly or
    /// at the wrong time.
    /// 
    /// Code using the Unicorn library should create a single static instance of the font resolver at static class initialisation time, passing in all the necessary configuration at that point,
    /// and should not try to alter the configuration later.  If you do try to alter the configuration later, you are liable to have problems.
    /// 
    /// The awkwardness of font handling in PDFSharp is one reason I am planning to introduce a native PDF-writing implementation which is not subject to the same restrictions.
    /// </summary>
    public class FontConfigurator : IFontResolver
    {
        private static readonly ILogger _log = LogManager.GetCurrentClassLogger();

        private readonly Dictionary<string, byte[]> _faceData = new Dictionary<string, byte[]>();
        private readonly Dictionary<string, List<FontFamilyMap>> _faceMap = new Dictionary<string, List<FontFamilyMap>>();

        /// <summary>
        /// Construct a new FontConfigurator, setting it up with font configuration data.
        /// </summary>
        /// <param name="fontInfo">The objects describing the configuration of each font.</param>
        public FontConfigurator(IEnumerable<FontConfigurationData> fontInfo)
        {
            string fontCode = "0000";
            if (fontInfo is null)
            {
                throw new ArgumentNullException(nameof(fontInfo));
            }
            foreach (FontConfigurationData fontData in fontInfo)
            {
                fontCode = SetUpFont(fontData, fontCode);
            }
            GlobalFontSettings.FontResolver = this;
        }

        private string SetUpFont(FontConfigurationData fontData, string lastFontCode)
        {
            string fontCode = Increment(lastFontCode);
            _faceData.Add(fontCode, GetFontFile(fontData.Filename));
            if (!_faceMap.TryGetValue(fontData.Name, out List<FontFamilyMap> familyList))
            {
                familyList = new List<FontFamilyMap>();
                _faceMap.Add(fontData.Name, familyList);
            }
            familyList.Add(new FontFamilyMap { Style = fontData.Style, FaceCode = fontCode });
            return fontCode;
        }

        private static string Increment(string lastFontCode)
        {
            int val = int.Parse(lastFontCode, CultureInfo.InvariantCulture);
            return (val + 1).ToString("D4", CultureInfo.InvariantCulture);
        }

        private static byte[] GetFontFile(string fn)
        {
            try
            {
                using (FileStream fs = new FileStream(fn, FileMode.Open, FileAccess.Read))
                {
                    return ReadEntireStream(fs);
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                _log.Error(ex, "Failed to load font file {0}", fn);
                return null;
            }
        }

        private static byte[] ReadEntireStream(Stream str)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                str.CopyTo(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Returns the raw data for a font, given the face code.
        /// </summary>
        /// <param name="faceName">The code for the font face</param>
        /// <returns>The raw data for the font</returns>
        public byte[] GetFont(string faceName)
        {
            return _faceData[faceName];
        }

        /// <summary>
        /// Returns the face code for a font with a given family and style.
        /// </summary>
        /// <param name="familyName">The font family</param>
        /// <param name="isBold">Whether to look for a boldface font</param>
        /// <param name="isItalic">Whether to look for an italic font</param>
        /// <returns>A class encapsulating the font code</returns>
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (!_faceMap.TryGetValue(familyName, out List<FontFamilyMap> familyMembers))
            {
                return null;
            }
            string faceCode = null;
            if ((!isBold) && (!isItalic))
            {
                faceCode = familyMembers.OrderBy(m => m.Style).FirstOrDefault()?.FaceCode;
            }
            else if (isBold && isItalic)
            {
                faceCode = familyMembers.FirstOrDefault(m => m.Style == (UniFontStyles.Bold | UniFontStyles.Italic))?.FaceCode ??
                    familyMembers.FirstOrDefault(m => (m.Style & UniFontStyles.Bold) != 0 && (m.Style & UniFontStyles.Italic) != 0)?.FaceCode ??
                    familyMembers.FirstOrDefault()?.FaceCode;
            }
            else if (isBold)
            {
                faceCode = familyMembers.Where(m => (m.Style & UniFontStyles.Bold) != 0).OrderBy(m => m.Style).FirstOrDefault()?.FaceCode;
            }
            else if (isItalic)
            {
                faceCode = familyMembers.Where(m => (m.Style & UniFontStyles.Italic) != 0).OrderBy(m => m.Style).FirstOrDefault()?.FaceCode;
            }
            if (faceCode == null)
            {
                return null;
            }
            return new FontResolverInfo(faceCode);
        }
    }
}
