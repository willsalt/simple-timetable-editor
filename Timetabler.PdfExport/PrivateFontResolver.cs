using NLog;
using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.IO;


namespace Timetabler.PdfExport
{
    internal class PrivateFontResolver : IFontResolver
    {
        private static ILogger _log = LogManager.GetCurrentClassLogger();

        private Dictionary<string, byte[]> _faceData;

        private const string SerifRomanFaceCode = "FR";
        private const string SerifItalicFaceCode = "FI";
        private const string SerifRomanBoldFaceCode = "FB";
        private const string SerifItalicBoldFaceCode = "FX";

        private const string SansRomanFaceCode = "AR";
        private const string SansRomanBoldFaceCode = "AB";

        internal PrivateFontResolver()
        {
            _faceData = new Dictionary<string, byte[]>();
            _faceData.Add(SerifRomanFaceCode, GetFontFile(Properties.Settings.Default.SerifRomanFace));
            _faceData.Add(SerifItalicFaceCode, GetFontFile(Properties.Settings.Default.SerifItalicFace));
            _faceData.Add(SerifRomanBoldFaceCode, GetFontFile(Properties.Settings.Default.SerifBoldFace));
            _faceData.Add(SerifItalicBoldFaceCode, GetFontFile(Properties.Settings.Default.SerifBoldItalicFace));
            _faceData.Add(SansRomanFaceCode, GetFontFile(Properties.Settings.Default.SansRomanFace));
            _faceData.Add(SansRomanBoldFaceCode, GetFontFile(Properties.Settings.Default.SansBoldFace));

            _log.Info("Loaded {0} fonts: {1}", _faceData.Count, string.Join(", ", _faceData.Keys));
        }

        private byte[] GetFontFile(string fn)
        {
            try
            {
                using (FileStream fs = new FileStream(Path.Combine(Properties.Settings.Default.FontFolder, fn), FileMode.Open, FileAccess.Read))
                {
                    return ReadEntireStream(fs);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Failed to load font file {0}", fn);
                return null;
            }
        }

        private byte[] ReadEntireStream(Stream str)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                str.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public byte[] GetFont(string faceName)
        {
            return _faceData[faceName];
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName == "Serif")
            {
                if (!isBold)
                {
                    if (!isItalic)
                    {
                        return new FontResolverInfo(SerifRomanFaceCode);
                    }
                    return new FontResolverInfo(SerifItalicFaceCode);
                }
                if (!isItalic)
                {
                    return new FontResolverInfo(SerifRomanBoldFaceCode);
                }
                return new FontResolverInfo(SerifItalicBoldFaceCode);
            }
            if (familyName == "Sans")
            {
                if (isBold)
                {
                    return new FontResolverInfo(SansRomanBoldFaceCode);
                }
                return new FontResolverInfo(SansRomanFaceCode);
            }
            return null;
        }
    }
}
