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
    }
}
