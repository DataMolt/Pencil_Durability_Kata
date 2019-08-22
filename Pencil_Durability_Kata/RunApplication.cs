using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class RunApplication
    {
        private IStationary _stationary;

        private IWritingUtensil _writingUtensil;

        private Stack<IWritingUtensil> _pencilDrawer;

        public RunApplication(IStationary stationary, IWritingUtensil writingUtensil, Stack<IWritingUtensil> pencilDrawer)
        {
            _stationary = stationary;
            _writingUtensil = writingUtensil;
            _pencilDrawer = pencilDrawer;
        }

        public List<string> GetStationaryText()
        {
            return _stationary.Text;
        }

        public void RunApp()
        {
            while (true)
            {
                //Console.Clear();
                //WritePaperContentsToConsole();

                var selectedAction = RequestUserAction();

                Write();
            }
        }

        public void Write()
        {
            var writeToPaper = new List<string>();
            var userInput = _writingUtensil.GetUserInput();
            var wordArray = _writingUtensil.BuildWordArray(userInput);
            foreach (var word in wordArray)
            {
                var wordForWriting = _writingUtensil.BuildWordForWritingToPaper(word);
                writeToPaper.Add(wordForWriting);
                if (wordForWriting.Length < word.Length)
                {
                    AlertUserPencilNeedsSharpening();
                    break;
                }
            }
            WriteTextToPaper(writeToPaper);
        }

        public UserActionSelection ValidateUserActionRequest(string selectionToValidate)
        {
            UserActionSelection userSelection;
            if (Enum.TryParse(selectionToValidate, true, out userSelection) && Enum.IsDefined(typeof(UserActionSelection), userSelection))
            {
                return userSelection;
            }
            else
            {
                return 0;
            }
        }

        public UserActionSelection RequestUserAction()
        {
            UserActionSelection userSelection;
            while (true)
            {
                Console.Clear();
                WritePaperContentsToConsole();
                Console.WriteLine("What would you like to do? \n (1) Write to paper\n");
                var selectionToValidate = Console.ReadLine();
                userSelection = ValidateUserActionRequest(selectionToValidate);
                if (userSelection != 0)
                {
                    return userSelection;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number!\n");
                    Console.ReadKey();
                }
            }
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
                Console.WriteLine("Your paper is currently blank! Select 'Write' to write to it!\n");
            }
        }

        public void SharpenPencil()
        {
            _writingUtensil.ResetPencilDurability();
            _writingUtensil.ReducePencilLength();
            AlertUserPencilLengthReduced();
            Console.ReadKey();
        }

        public void AlertUserPencilNeedsSharpening()
        {
            Console.WriteLine("Your pencil is out of lead and needs to be sharpened.");
        }

        public void AlertUserPencilLengthReduced()
        {
            Console.WriteLine($"Your pencil's gotten smaller. You can sharpen your pencil {_writingUtensil.PencilSize} more time(s).");
        }
    }
}
