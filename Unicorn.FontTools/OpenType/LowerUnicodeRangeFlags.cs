﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.FontTools.OpenType
{
    public enum LowerUnicodeRangeFlags : ulong
    {
        BasicLatin = 0x1UL,
        Latin1Supplement = 0x2UL,
        LatinExtendedA = 0x4UL,
        LatinExtendedB = 0x8UL,
        IPAExtensions = 0x10UL,
        SpacingModifiers = 0x20UL,
        CombiningDiacriticalMarks = 0x40UL,
        GreekAndCoptic = 0x80UL,
        Coptic = 0x100UL,
        Cyrillic = 0x200UL,
        Armenian = 0x400UL,
        Hebrew = 0x800UL,
        Vai = 0x1000UL,
        Arabic = 0x2000UL,
        NKo = 0x4000UL,
        Devanagari = 0x8000UL,
        Bengali = 0x1_0000UL,
        Gurmukhi = 0x2_0000UL,
        Gujurati = 0x4_0000UL,
        Oriya = 0x8_0000UL,
        Tamil = 0x10_0000UL,
        Telugu = 0x20_0000UL,
        Kannada = 0x40_0000UL,
        Malayalam = 0x80_0000UL,
        Thai = 0x100_0000UL,
        Lao = 0x200_0000UL,
        Georgian = 0x400_0000UL,
        Balinese = 0x800_0000UL,
        HangulJamo = 0x1000_0000UL,
        LatinExtendedAdditional = 0x2000_0000UL,
        GreekExtended = 0x4000_0000UL,
        GeneralPunctuation = 0x8000_0000UL,
        SuperscriptsSubscripts = 0x1_0000_0000UL,
        Currency = 0x2_0000_0000UL,
        CombiningDiacriticalsForSymbols = 0x4_0000_0000UL,
        LetterlikeSymbols = 0x8_0000_0000UL,
        NumberForms = 0x10_0000_0000UL,
        Arrows = 0x20_0000_0000UL,
        MathsOperators = 0x40_0000_0000UL,
        MiscTechnical = 0x80_0000_0000UL,
        ControlPictures = 0x100_0000_0000UL,
        OCR = 0x200_0000_0000UL,
        EnclosedAlphanumerics = 0x400_0000_0000UL,
        BoxDrawing = 0x800_0000_0000UL,
        BlockElements = 0x1000_0000_0000UL,
        GeometricShapes = 0x2000_0000_0000UL,
        MiscSymbols = 0x4000_0000_0000UL,
        Dingbats = 0x8000_0000_0000UL,
        CJKSymbols = 0x1_0000_0000_0000UL,
        Hiragana = 0x2_0000_0000_0000UL,
        Katakana = 0x4_0000_0000_0000UL,
        Bopomofo = 0x8_0000_0000_0000UL,
        HangulCompatiblityJamo = 0x10_0000_0000_0000UL,
        PhagsPa = 0x20_0000_0000_0000UL,
        EnclosedCJKLetters = 0x40_0000_0000_0000UL,
        CJKCompatibility = 0x80_0000_0000_0000UL,
        HangulSyllables = 0x100_0000_0000_0000UL,
        NonPlane0 = 0x200_0000_0000_0000UL,
        Phoenician = 0x400_0000_0000_0000UL,
        CJKUnifiedIdeographs = 0x800_0000_0000_0000UL,
        PrivateUseArea0 = 0x1000_0000_0000_0000UL,
        CJKStrokes = 0x2000_0000_0000_0000UL,
        AlphabeticPresentationForms = 0x4000_0000_0000_0000UL,
        ArabicPresentationFormsA = 0x8000_0000_0000_0000UL,
    }
}
