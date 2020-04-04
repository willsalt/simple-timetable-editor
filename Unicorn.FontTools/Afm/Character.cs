using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicorn.FontTools.Afm
{
    public class Character
    {
        public short? Code { get; private set; }

        public string Name { get; private set; }

        public WidthSet XWidth { get; private set; }

        public WidthSet YWidth { get; private set; }

        public Vector? VVector { get; private set; }

        public BoundingBox? BoundingBox { get; private set; }

        public LigatureSetCollection Ligatures { get; private set; }

        private List<InitialLigatureSet> InitialLigatures { get; set; }

        internal Character(short? code, string name, WidthSet xWidth, WidthSet yWidth, Vector? vvector, BoundingBox? boundingBox, 
            IEnumerable<InitialLigatureSet> ligatures)
        {
            Code = code;
            Name = name;
            XWidth = xWidth;
            YWidth = yWidth;
            VVector = vvector;
            BoundingBox = boundingBox;
            Ligatures = null;
            InitialLigatures = ligatures?.ToList();
        }

        public void ProcessLigatures(IDictionary<string, Character> charmap)
        {
            if (charmap is null)
            {
                throw new ArgumentNullException(nameof(charmap));
            }

            if (InitialLigatures is null || InitialLigatures.Count == 0)
            {
                if (Ligatures is null)
                {
                    Ligatures = new LigatureSetCollection(null);
                }
                return;
            }

            List<LigatureSet> processedLigatures = new List<LigatureSet>(InitialLigatures.Count);
            foreach (InitialLigatureSet rawLigature in InitialLigatures)
            {
                if (!charmap.TryGetValue(rawLigature.Second, out Character second))
                {
                    throw new AfmFormatException($"Character {rawLigature.Second} not found in font.");
                }
                if (!charmap.TryGetValue(rawLigature.Ligature, out Character ligature))
                {
                    throw new AfmFormatException($"Character {rawLigature.Ligature} not found in font.");
                }
                processedLigatures.Add(new LigatureSet(this, second, ligature));
            }

            Ligatures = new LigatureSetCollection(processedLigatures);
        }
    }
}
