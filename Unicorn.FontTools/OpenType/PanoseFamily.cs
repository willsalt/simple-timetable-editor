using System;

namespace Unicorn.FontTools.OpenType
{
    public struct PanoseFamily : IEquatable<PanoseFamily>
    {
        public byte FamilyType { get; private set; }

        public byte SerifStyle { get; private set; }

        public byte Weight { get; private set; }

        public byte Proportion { get; private set; }

        public byte Contrast { get; private set; }

        public byte StrokeVariation { get; private set; }

        public byte ArmStyle { get; private set; }

        public byte Letterform { get; private set; }

        public byte Midline { get; private set; }

        public byte XHeight { get; private set; }

        public PanoseFamily(byte famType, byte serifStyle, byte weight, byte proportion, byte contrast, byte strokeVar, byte armStyle, byte letterform,
            byte midline, byte xHeight)
        {
            FamilyType = famType;
            SerifStyle = serifStyle;
            Weight = weight;
            Proportion = proportion;
            Contrast = contrast;
            StrokeVariation = strokeVar;
            ArmStyle = armStyle;
            Letterform = letterform;
            Midline = midline;
            XHeight = xHeight;
        }

        public PanoseFamily(byte[] arr, int offset) : this(arr[offset], arr[offset + 1], arr[offset + 2], arr[offset + 3], arr[offset + 4], arr[offset + 5], 
            arr[offset + 6], arr[offset + 7], arr[offset + 8], arr[offset + 9])
        {
        }

        public bool Equals(PanoseFamily other) => this == other;

        public override bool Equals(object obj)
        {
            if (obj is PanoseFamily other)
            {
                return Equals(other);
            }
            return false;
        }

        public static bool operator ==(PanoseFamily a, PanoseFamily b) =>
            a.FamilyType == b.FamilyType && a.SerifStyle == b.SerifStyle && a.Weight == b.Weight && a.Proportion == b.Proportion && a.Contrast == b.Contrast &&
                a.StrokeVariation == b.StrokeVariation && a.ArmStyle == b.ArmStyle && a.Letterform == b.Letterform && a.Midline == b.Midline && a.XHeight == b.XHeight;

        public static bool operator !=(PanoseFamily a, PanoseFamily b) =>
            a.FamilyType != b.FamilyType || a.SerifStyle != b.SerifStyle || a.Weight != b.Weight || a.Proportion != b.Proportion || a.Contrast != b.Contrast ||
                a.StrokeVariation != b.StrokeVariation || a.ArmStyle != b.ArmStyle || a.Letterform != b.Letterform || a.Midline != b.Midline || a.XHeight != b.XHeight;
    }
}
