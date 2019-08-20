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
            //PointDurability = 40000;
            PointDurability = 10;

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

        public List<string> Write()
        {
            var writeToPaper = new List<string>();
            var userInput = GetUserInput();
            var wordArray = BuildWordArray(userInput);
            foreach (var word in wordArray)
            {
                var wordForWriting = BuildWordForWritingToPaper(word);
                writeToPaper.Add(wordForWriting);
                if (wordForWriting.Length < word.Length)
                {
                    if (PencilSize > 0)
                    {
                        SharpenPencil();
                    }

                    break;
                }
            }
            return writeToPaper;
        }

        public List<string> Write(string stringToWrite)
        {
            var writeToPaper = new List<string>();
            var userInput = stringToWrite;
            var wordArray = BuildWordArray(userInput);
            foreach (var word in wordArray)
            {
                var wordForWriting = BuildWordForWritingToPaper(word);
                writeToPaper.Add(wordForWriting);
                if (wordForWriting.Length < word.Length)
                {
                    if (PencilSize > 0)
                    {
                        SharpenPencil();
                    }
                    break;
                }
            }
            return writeToPaper;
        }

        // Sharpen methods
        public void ReducePencilLength()
        {
            PencilSize -= 1;
        }

        public void ResetPencilDurability()
        {
            //PointDurability = 40000;
            PointDurability = 10;
        }

        public void AlertUserPencilIsBeingSharpened()
        {
            Console.WriteLine("Your pencil is out of lead and needs to be sharpened. Sharpening pencil now.");
        }

        public void AlertUserPencilLengthReduced()
        {
            Console.WriteLine($"Your pencil's gotten smaller. You can sharpen your pencil {PencilSize} more time(s).");
        }

        public void SharpenPencil()
        {
            AlertUserPencilIsBeingSharpened();
            ResetPencilDurability();
            ReducePencilLength();
            AlertUserPencilLengthReduced();
            Console.ReadKey();
        }

        // Create new pencil methods
        public void AlertUserNewPencilIsBeingMade()
        {
            Console.WriteLine("Your pencil can no longer write! Creating a new pencil now.");
        }
    }
}
