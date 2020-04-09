using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// The contents of an AFM file.
    /// </summary>
    public class AfmFontMetrics
    {

        public string FontName { get; private set; }

        public string FamilyName { get; private set; }

        public string FullName { get; private set; }

        public string Weight { get; private set; }

        public BoundingBox FontBoundingBox { get; private set; }

        public string Version { get; private set; }

        public string Notice { get; private set; }

        public string EncodingScheme { get; private set; }

        public int MappingScheme { get; private set; }

        public int EscapeCharacter { get; private set; }

        public string CharacterSet { get; private set; }

        public int CharacterCount { get; private set; }

        public bool IsBaseFont { get; private set; }

        public Vector VVector { get; private set; }

        public bool IsFixedV { get; private set; }

        public decimal CapHeight { get; private set; }

        public decimal XHeight { get; private set; }

        public decimal Ascender { get; private set; }

        public decimal Descender { get; private set; }

        public IDictionary<string, Character> CharactersByName { get; } = new Dictionary<string, Character>();

        public IDictionary<short, Character> CharactersByCode { get; } = new Dictionary<short, Character>();

    }
}
