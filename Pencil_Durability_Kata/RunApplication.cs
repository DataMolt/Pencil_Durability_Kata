using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class RunApplication
    {
        public Pencil Pencil { get; set; }
        public Paper Paper { get; set; }


        public RunApplication()
        {
            Pencil = new Pencil();
            Paper = new Paper();
        }

        public void RunApp()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(string.Join(" ", Paper.Text));
                Write();
            }
        }

        public void Write()
        {
            var writeToPaper = new List<string>();
            var userInput = Pencil.GetUserInput();
            var wordArray = Pencil.BuildWordArray(userInput);
            foreach (var word in wordArray)
            {
                var wordForWriting = Pencil.BuildWordForWritingToPaper(word);
                writeToPaper.Add(wordForWriting);
                if (wordForWriting.Length < word.Length)
                {
                    if (Pencil.PencilSize > 0)
                    {
                        Pencil.SharpenPencil();
                    }

                    break;
                }
            }
            WriteTextToPaper(writeToPaper);
        }

        public void WriteTextToPaper(List<string> wordList)
        {
            Paper.Text.AddRange(wordList);
        }

        public void AlertUserPencilNeedsSharpening()
        {
            Console.WriteLine("Your pencil is out of lead and needs to be sharpened.");
        }
    }
}
