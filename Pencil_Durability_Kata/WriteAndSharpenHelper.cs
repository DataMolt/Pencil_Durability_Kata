using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class WriteAndSharpenHelper : IWriteAndSharpenHelper
    {
        public IStationary _stationary { get; set; }

        public IWritingUtensil _writingUtensil { get; set; }

        public WriteAndSharpenHelper(IStationary stationary, IWritingUtensil writingUtensil)
        {
            _stationary = stationary;
            _writingUtensil = writingUtensil;
        }

        public void WriteTextToPaper(List<string> wordList)
        {
            _stationary.Text.AddRange(wordList);
        }

        public void WritePaperContentsToConsole()
        {
            if (_stationary.Text.Count >= 1)
            {
                Console.WriteLine(string.Join(" ", _stationary.Text));
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Your paper is currently blank! Select 'Write' to write to it!\n\n");
            }
        }

        public void AlertUserPencilNeedsSharpening()
        {
            Console.Write("Your pencil is out of lead and needs to be sharpened.");
            Console.ReadKey();
        }

        public void AlertUserPencilLengthReduced()
        {
            Console.Write($"\nYour pencil's gotten smaller. You can sharpen your pencil {_writingUtensil.PencilSize} more time(s).");
            Console.ReadKey();
        }

        public void AlertUserPencilCannotBeSharpened()
        {
            Console.Write("\nYour pencil is too small to be sharpened!");
            Console.ReadKey();
        }
    }
}
