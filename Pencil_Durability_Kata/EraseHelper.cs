using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class EraseHelper : IEraseHelper
    {
        public IStationary _stationary { get; set; }

        public EraseHelper(IStationary stationary)
        {
            _stationary = stationary;
        }

        public string GetUserEraseRequest()
        {
            Console.WriteLine(string.Join(" ", _stationary.Text));
            Console.WriteLine("\n");
            Console.WriteLine("What word would you like to erase?");
            return Console.ReadLine();
        }

        public bool UserRequestInPaperText(string userInput)
        {
            return _stationary.Text.Contains(userInput);
        }

        public void AlertUserRequestNotFoundInText()
        {
            Console.Write("Couldn't find that word. Please try another.");
            Console.ReadKey();
        }

        public int FindEraseRequestIndexInPaperText(string userInput)
        {
            int foundIndex = 0;
            for (int textIndex = _stationary.Text.Count - 1; textIndex > -1; textIndex--)
            {
                if (_stationary.Text[textIndex] == userInput)
                {
                    foundIndex = textIndex;
                    break;
                }
            }
            return foundIndex;
        }
    }
}
