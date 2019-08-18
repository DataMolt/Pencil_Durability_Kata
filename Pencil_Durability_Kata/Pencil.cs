using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class Pencil
    {
        public int PointDurability { get; set; }
        public int EraserDurability { get; set; }

        public Pencil()
        {
            PointDurability = 40000;
            EraserDurability = 20000;
        }

        // Get user input methods

        // Reduce durability methods
        public int FindCharReductionRate(char charToReduceBy)
        {
            int reduceDurabilityBy = 0;
            if (char.IsUpper(charToReduceBy))
            {
                reduceDurabilityBy += 2;
            }
            else
            {
                reduceDurabilityBy += 1;
            }
            return reduceDurabilityBy;
        }

        public bool ReducePointDurability(int reduceBy)
        {
            if (PointDurability >= reduceBy)
            {
                PointDurability -= reduceBy;
                return false;
            }
            else
            {
                PointDurability = 0;
                return true;
            }
        }

        // Writing to paper methods
        public string BuildWordForWritingToPaper(string word)
        {
            for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
            {
                var reductionRate = FindCharReductionRate(word[letterIndex]);
                var exceedsPointDurability = ReducePointDurability(reductionRate);
                if (exceedsPointDurability)
                {
                    return word.Substring(0, letterIndex);
                }
            }
            return word;
        }
    }
}
