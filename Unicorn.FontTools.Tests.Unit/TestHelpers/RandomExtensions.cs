using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Extensions;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.OpenType;

namespace Unicorn.FontTools.Tests.Unit.TestHelpers
{
    public static class RandomExtensions
    {
        public static WidthSet NextAfmWidthSet(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return new WidthSet(random.NextNullableDecimal(), random.NextNullableDecimal(), random.NextNullableDecimal());
        }

        public static Vector NextAfmVector(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return new Vector(random.NextDecimal(), random.NextDecimal());
        }

        public static Vector? NextNullableAfmVector(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextAfmVector(random);
        }

        public static BoundingBox NextAfmBoundingBox(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return new BoundingBox(random.NextDecimal(), random.NextDecimal(), random.NextDecimal(), random.NextDecimal());
        }

        public static BoundingBox? NextNullableAfmBoundingBox(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextAfmBoundingBox(random);
        }

        public static Character NextAfmCharacter(this Random random, IList<string> existingCharacters = null)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return NextAfmCharacter(random, random.NextNullableShort(), existingCharacters);
        }

        public static Character NextAfmCharacter(this Random random, string name, IList<string> existingCharacters = null)
        {
            return NextAfmCharacter(random, name, random.NextNullableShort(), existingCharacters);
        }

        public static Character NextAfmCharacter(this Random random, short? code, IList<string> existingCharacters = null)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (existingCharacters is null)
            {
                existingCharacters = Array.Empty<string>();
            }
            string name;
            if (random.Next(10) == 0)
            {
                name = null;
            }
            else
            {
                do
                {
                    name = random.NextString(random.Next(1, 16));
                } while (existingCharacters.Contains(name));
            }
            return NextAfmCharacter(random, name, code, existingCharacters);
        }

        public static Character NextAfmCharacter(this Random random, string name, short? code, IList<string> existingCharacters = null)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (existingCharacters is null)
            {
                existingCharacters = Array.Empty<string>();
            }
            int ligCount = random.Next(3);
            InitialLigatureSet[] ligatures = new InitialLigatureSet[ligCount];
            for (int i = 0; i < ligCount; ++i)
            {
                if (existingCharacters.Count == 0)
                {
                    ligatures[i] = new InitialLigatureSet(random.NextString(random.Next(1, 16)), random.NextString(random.Next(1, 16)));
                }
                else
                {
                    ligatures[i] = new InitialLigatureSet(existingCharacters[random.Next(existingCharacters.Count)],
                        existingCharacters[random.Next(existingCharacters.Count)]);
                }
            }
            return new Character(code, name, random.NextAfmWidthSet(), random.NextAfmWidthSet(), random.NextNullableAfmVector(),
                random.NextNullableAfmBoundingBox(), ligatures);
        }

        public static LigatureSet NextAfmLigatureSet(this Random random, IList<string> doNotUseAsSecondCharacterName)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (doNotUseAsSecondCharacterName is null)
            {
                doNotUseAsSecondCharacterName = Array.Empty<string>();
            }
            string secondName;
            do
            {
                secondName = random.NextString(random.Next(1, 20));
            } while (doNotUseAsSecondCharacterName.Contains(secondName));
            
            return new LigatureSet(NextAfmCharacter(random, random.NextString(random.Next(1, 16))), NextAfmCharacter(random, secondName),
                NextAfmCharacter(random, random.NextString(random.Next(1, 16))));
        }

        public static KerningPair NextAfmKerningPair(this Random random, IList<string> doNotUseAsSecondCharacterName)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (doNotUseAsSecondCharacterName is null)
            {
                doNotUseAsSecondCharacterName = Array.Empty<string>();
            }
            string secondName;
            do
            {
                secondName = random.NextString(random.Next(1, 20));
            } while (doNotUseAsSecondCharacterName.Contains(secondName));

            return new KerningPair(NextAfmCharacter(random, random.NextString(random.Next(1, 16))), NextAfmCharacter(random, secondName), NextAfmVector(random));
        }

        public static DirectionMetrics NextAfmDirectionMetrics(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            bool? fixedPitch = random.NextNullableBoolean();
            Vector? width = null;
            if (!fixedPitch.HasValue || fixedPitch.Value)
            {
                width = NextNullableAfmVector(random);
            }
            return new DirectionMetrics(random.NextNullableDecimal(), random.NextNullableDecimal(), random.NextNullableDecimal(), width, fixedPitch);
        }

        public static DirectionMetrics? NextNullableAfmDirectionMetrics(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextAfmDirectionMetrics(random);
        }

        private static readonly FontKind[] _validFontKindValues = new[] { FontKind.Cff, FontKind.TrueType };

        public static FontKind NextOpenTypeFontKind(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return _validFontKindValues[random.Next(_validFontKindValues.Length)];
        }

        public static Tag NextOpenTypeTag(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return new Tag(Encoding.ASCII.GetBytes(random.NextString(4)));
        }

        private static readonly PlatformId[] _platformIds = new[] { PlatformId.Unicode, PlatformId.Macintosh, PlatformId.Windows, PlatformId.Custom };

        public static PlatformId NextOpenTypePlatformId(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return _platformIds[random.Next(_platformIds.Length)];
        }

        public static FontFlags NextOpenTypeFontFlags(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return (FontFlags)(random.Next(32) | (random.NextBoolean() ? 2048 : 0) | (random.NextBoolean() ? 4096 : 0) | (random.NextBoolean() ? 8192 : 0) |
                (random.NextBoolean() ? 16384 : 0));
        }

        public static MacStyleFlags NextOpenTypeMacStyleFlags(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return (MacStyleFlags)random.Next(128);
        }

        public static FontDirectionHint NextOpenTypeFontDirectionHint(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return (FontDirectionHint)random.Next(-2, 3);
        }

        public static HorizontalMetricRecord NextOpenTypeHorizontalMetricRecord(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return new HorizontalMetricRecord(random.NextUShort(), random.NextShort());
        }

        private static readonly NameField[] _nameFields = new[] 
        { 
            NameField.CopyrightNotice, 
            NameField.Family, 
            NameField.Subfamily, 
            NameField.UniqueID, 
            NameField.FullName, 
            NameField.Version, 
            NameField.PostScriptName, 
            NameField.TrademarkNotice, 
            NameField.Manufacturer, 
            NameField.Description, 
            NameField.Description, 
            NameField.VendorURI, 
            NameField.DesignerURI, 
            NameField.LicenceDescription, 
            NameField.LicenceURI, 
            NameField.TypographicFamily, 
            NameField.TypographicSubfamily, 
            NameField.MacintoshMenuName, 
            NameField.SampleText, 
            NameField.PostScriptCIDName, 
            NameField.WWSFamilyName, 
            NameField.WWSSubfamilyName, 
            NameField.LightBackgroundPalette, 
            NameField.DarkBackgroundPalette, 
            NameField.PostScriptFamilyPrefix, 
        };

        public static NameField NextOpenTypeNameField(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return _nameFields[random.Next(_nameFields.Length)];
        }

        public static NameRecord NextOpenTypeNameRecord(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return new NameRecord(NextOpenTypePlatformId(random), random.NextUShort(), random.NextUShort(), NextOpenTypeNameField(random), 
                random.NextString(random.Next(128)), random.NextBoolean());
        }

        public static HighByteSubheaderRecord NextOpenTypeHighByteSubheaderRecord(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return new HighByteSubheaderRecord(random.NextByte(), random.NextByte(), random.NextShort(), random.NextUShort());
        }

        public static SegmentSubheaderRecord NextOpenTypeSegmentSubheaderRecord(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return new SegmentSubheaderRecord(random.NextUShort(), random.NextUShort(), random.NextShort(), random.Next());
        }

        private static readonly EmbeddingPermissionsFlags[] _exclusiveEmbeddingPermissionsFlags = new[] 
        { 
            EmbeddingPermissionsFlags.Installable, 
            EmbeddingPermissionsFlags.Restricted, 
            EmbeddingPermissionsFlags.Printing, 
            EmbeddingPermissionsFlags.Editable, 
        };

        public static EmbeddingPermissionsFlags NextOpenTypeEmbeddingPermissionsFlags(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return _exclusiveEmbeddingPermissionsFlags[random.Next(_exclusiveEmbeddingPermissionsFlags.Length)] | 
                (random.NextBoolean() ? EmbeddingPermissionsFlags.BitmapOnly : 0) | (random.NextBoolean() ? EmbeddingPermissionsFlags.NoSubsetting : 0);
        }

        private static readonly IBMFamily[] _validIBMFamilyValues = new[]
        {
            IBMFamily.None,
            IBMFamily.OldstyleSerif_None,
            IBMFamily.OldstyleSerif_IBMRoundedLegibility,
            IBMFamily.OldstyleSerif_Garalde,
            IBMFamily.OldstyleSerif_Venetian,
            IBMFamily.OldstyleSerif_ModifiedVenetian,
            IBMFamily.OldstyleSerif_DutchTraditional,
            IBMFamily.OldstyleSerif_DutchModern,
            IBMFamily.OldstyleSerif_Contemporary,
            IBMFamily.OldstyleSerif_Calligraphic,
            IBMFamily.OldstyleSerif_Miscellaneous,
            IBMFamily.TransitionalSerif_None,
            IBMFamily.TransitionalSerif_DirectLine,
            IBMFamily.TransitionalSerif_Script,
            IBMFamily.TransitionalSerif_Miscellaneous,
            IBMFamily.ModernSerif_None,
            IBMFamily.ModernSerif_Italian,
            IBMFamily.ModernSerif_Script,
            IBMFamily.ModernSerif_Miscellaneous,
            IBMFamily.ClarendonSerif_None,
            IBMFamily.ClarendonSerif_Clarendon,
            IBMFamily.ClarendonSerif_Modern,
            IBMFamily.ClarendonSerif_Traditional,
            IBMFamily.ClarendonSerif_Newspaper,
            IBMFamily.ClarendonSerif_StubSerif,
            IBMFamily.ClarendonSerif_Monotone,
            IBMFamily.ClarendonSerif_Typewriter,
            IBMFamily.ClarendonSerif_Miscellaneous,
            IBMFamily.SlabSerif_None,
            IBMFamily.SlabSerif_Monotone,
            IBMFamily.SlabSerif_Humanist,
            IBMFamily.SlabSerif_Geometric,
            IBMFamily.SlabSerif_Swiss,
            IBMFamily.SlabSerif_Typewriter,
            IBMFamily.SlabSerif_Miscellaneous,
            IBMFamily.FreeformSerif_None,
            IBMFamily.FreeformSerif_Modern,
            IBMFamily.FreeformSerif_Miscellaneous,
            IBMFamily.SansSerif_None,
            IBMFamily.SansSerif_IBMNeoGrotesqueGothic,
            IBMFamily.SansSerif_Humanist,
            IBMFamily.SansSerif_LowXRoundGeometric,
            IBMFamily.SansSerif_HighXRoundGeometric,
            IBMFamily.SansSerif_NeoGrotesqueGothic,
            IBMFamily.SansSerif_ModifiedNeoGrotesqueGothic,
            IBMFamily.SansSerif_TypewriterGothic,
            IBMFamily.SansSerif_Matrix,
            IBMFamily.SansSerif_Miscellaneous,
            IBMFamily.Ornamentals_None,
            IBMFamily.Ornamentals_Engraver,
            IBMFamily.Ornamentals_BlackLetter,
            IBMFamily.Ornamentals_Decorative,
            IBMFamily.Ornamentals_ThreeDimensional,
            IBMFamily.Ornamentals_Miscellaneous,
            IBMFamily.Scripts_None,
            IBMFamily.Scripts_Uncials,
            IBMFamily.Scripts_BrushJoined,
            IBMFamily.Scripts_FormalJoined,
            IBMFamily.Scripts_MonotoneJoined,
            IBMFamily.Scripts_Calligraphic,
            IBMFamily.Scripts_BrushUnjoined,
            IBMFamily.Scripts_FormalUnjoined,
            IBMFamily.Scripts_MonotoneUnjoined,
            IBMFamily.Scripts_Miscellaneous,
            IBMFamily.Symbolic_None,
            IBMFamily.Symbolic_MixedSerif,
            IBMFamily.Symbolic_OldStyleSerif,
            IBMFamily.Symbolic_NeoGrotesqueSansSerif,
            IBMFamily.Symbolic_Miscellaneous,
        };

        public static IBMFamily NextOpenTypeIBMFamily(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return _validIBMFamilyValues[random.Next(_validIBMFamilyValues.Length)];
        }

        public static PanoseFamily NextOpenTypePanoseFamily(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            byte[] data = new byte[10];
            random.NextBytes(data);
            return new PanoseFamily(data, 0);
        }

        public static LowerUnicodeRangeFlags NextOpenTypeLowerUnicodeRangeFlags(this Random random)
        {
            return (LowerUnicodeRangeFlags)random.NextULong();
        }

        public static UpperUnicodeRangeFlags NextOpenTypeUpperUnicodeRangeFlags(this Random random)
        {
            return (UpperUnicodeRangeFlags)random.NextULong();
        }

        public static OS2StyleFlags NextOpenTypeOS2StyleFlags(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return (OS2StyleFlags)random.Next(1024);
        }

        public static SupportedCodePageFlags NextOpenTypeSupportedCodePageFlags(this Random random)
        {
            return (SupportedCodePageFlags)random.NextULong();
        }

        public static CalculationStyle NextOpenTypeCalculationStyle(this Random random)
        {
            return random.NextBoolean() ? CalculationStyle.Windows : CalculationStyle.Macintosh;
        }

        private static PostScriptTableVersion[] _validPostScriptTableVersions = new[] 
        { 
            PostScriptTableVersion.One, 
            PostScriptTableVersion.Two, 
            PostScriptTableVersion.TwoPointFive, 
            PostScriptTableVersion.Three, 
            PostScriptTableVersion.Four 
        };

        public static PostScriptTableVersion NextOpenTypePostScriptTableVersion(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            return _validPostScriptTableVersions[random.Next(_validPostScriptTableVersions.Length)];
        }
    }
}
