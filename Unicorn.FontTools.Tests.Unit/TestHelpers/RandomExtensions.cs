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

#pragma warning disable CA5394 // Do not use insecure randomness

        public static WidthSet NextAfmWidthSet(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return new WidthSet(random.NextNullableDecimal(), random.NextNullableDecimal(), random.NextNullableDecimal());
        }

        public static Vector NextAfmVector(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return new Vector(random.NextDecimal(), random.NextDecimal());
        }

        public static Vector? NextNullableAfmVector(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
            }
            return new BoundingBox(random.NextDecimal(), random.NextDecimal(), random.NextDecimal(), random.NextDecimal());
        }

        public static BoundingBox? NextNullableAfmBoundingBox(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextAfmDirectionMetrics(random);
        }

        

        

        
        

        

        

        

        

        

        

        

        private static readonly EmbeddingPermissions[] _exclusiveEmbeddingPermissionsFlags = new[] 
        { 
            EmbeddingPermissions.Installable, 
            EmbeddingPermissions.Restricted, 
            EmbeddingPermissions.Printing, 
            EmbeddingPermissions.Editable, 
        };

        public static EmbeddingPermissions NextOpenTypeEmbeddingPermissionsFlags(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return _exclusiveEmbeddingPermissionsFlags[random.Next(_exclusiveEmbeddingPermissionsFlags.Length)] | 
                (random.NextBoolean() ? EmbeddingPermissions.BitmapOnly : 0) | (random.NextBoolean() ? EmbeddingPermissions.NoSubsetting : 0);
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
                throw new ArgumentNullException(nameof(random));
            }
            return _validIBMFamilyValues[random.Next(_validIBMFamilyValues.Length)];
        }

        public static PanoseFamily NextOpenTypePanoseFamily(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            byte[] data = new byte[10];
            random.NextBytes(data);
            return new PanoseFamily(data, 0);
        }

        [CLSCompliant(false)]
        public static LowerUnicodeRangeFlags NextOpenTypeLowerUnicodeRangeFlags(this Random random)
        {
            return (LowerUnicodeRangeFlags)random.NextULong();
        }

        public static UpperUnicodeRangeFlags NextOpenTypeUpperUnicodeRangeFlags(this Random random)
        {
            return (UpperUnicodeRangeFlags)random.NextULong();
        }

        public static OS2StyleProperties NextOpenTypeOS2StyleFlags(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (OS2StyleProperties)random.Next(1024);
        }

        [CLSCompliant(false)]
        public static SupportedCodePageFlags NextOpenTypeSupportedCodePageFlags(this Random random)
        {
            return (SupportedCodePageFlags)random.NextULong();
        }

        public static CalculationStyle NextOpenTypeCalculationStyle(this Random random)
        {
            return random.NextBoolean() ? CalculationStyle.Windows : CalculationStyle.Macintosh;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
