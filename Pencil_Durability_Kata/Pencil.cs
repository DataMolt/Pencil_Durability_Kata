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
            //PointDurability = 10;
            EraserDurability = 20000;
        }

        // Write to paper methods
        private string GetWriteInput()
        {
            Console.WriteLine("Enter a string to write: ");
            return Console.ReadLine();
        }

        private string[] BuildWordArray(string writeInput)
        {
            return writeInput.Split(" ");
        }

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

        private void ReducePointDurability(int reduceBy)
        {
            PointDurability -= reduceBy;
        }

        public int FindWordLength(string word)
        {
            for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
            {
                var reduceBy = FindCharReductionRate(word[letterIndex]);
                if (reduceBy <= PointDurability)
                {
                    ReducePointDurability(reduceBy);
                }
                else
                {
                    return letterIndex;
                }
            }
            return word.Length;
        }

        // Put it all together
        public List<string> Write()
        {
            var writeToPaper = new List<string>();
            var writeInput = GetWriteInput();
            var wordArray = BuildWordArray(writeInput);
            foreach (var word in wordArray)
            {
                if (this.PointDurability > 0)
                {
                    var wordLength = FindWordLength(word);
                    writeToPaper.Add(word.Substring(0, wordLength));
                }
                else
                {
                    break;
                }
            }
            return writeToPaper;
        }
    }
}
