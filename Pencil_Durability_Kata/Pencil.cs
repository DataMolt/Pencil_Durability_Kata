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
        public int PencilSize { get; set; }

        // Create pencil methods
        public Pencil()
        {
            PointDurability = 40000;
            EraserDurability = 20000;
            PencilSize = GeneratePencilLength();
        }

        public int GeneratePencilLength()
        {
            Random random = new Random();
            return random.Next(1, 4);
        }

        // Get user input methods
        public string GetUserInput()
        {
            Console.WriteLine("Enter a string to write: ");
            return Console.ReadLine();
        }

        public string[] BuildWordArray(string userInput)
        {
            return userInput.Split(" ");
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

        // Sharpen methods
        public void ReducePencilLength()
        {
            PencilSize -= 1;
        }

        public void ResetPencilDurability()
        {
            PointDurability = 40000;
        }

        // Create new pencil methods
        public void AlertUserNewPencilIsBeingMade()
        {
            Console.WriteLine("Your pencil can no longer write! Creating a new pencil now.");
        }
    }
}
