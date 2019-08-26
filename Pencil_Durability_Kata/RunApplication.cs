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
                var selectedAction = RequestUserAction();
                switch (selectedAction)
                {
                    case UserActionSelection.write:
                        Write();
                        break;
                    case UserActionSelection.sharpen:
                        SharpenPencil();
                        break;
                    case UserActionSelection.erase:
                        Erase();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Write()
        {
            Console.Clear();
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

        public void SharpenPencil()
        {
            if (_writingUtensil.PencilSize > 0)
            {
                _writingUtensil.ResetPencilDurability();
                _writingUtensil.ReducePencilLength();
                AlertUserPencilLengthReduced();
            }
            else
            {
                AlertUserPencilCannotBeSharpened();
            }
        }

        public void Erase()
        {
            Console.Clear();
            var userInput = GetUserEraseRequest();
            int userInputIndex;
            if (UserRequestInPaperText(userInput))
            {
                userInputIndex = FindEraseRequestIndexInPaperText(userInput);
                var wordToErase = _stationary.Text[userInputIndex];
                var eraseResults = _writingUtensil.BuildWordForErasing(wordToErase);
                _stationary.Text[userInputIndex] = eraseResults;
            }
            else
            {
                AlertUserRequestNotFoundInText();
            }
        }

        public void Edit(int eraseIndex)
        {
            var continueToEdit = AskUserToEditText();
            if (continueToEdit)
            {
                Console.WriteLine("Enter text to replace the erased area: ");
                var userInput = AskUserForEditString();
                var editArea = _stationary.Text[eraseIndex];
            }
        }


        // erase methods
        public string GetUserEraseRequest()
        {
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


        // edit methods
        public bool AskUserToEditText()
        {
            Console.WriteLine("Would you like to edit your erased text?");
            Console.Write("Enter 'Y' to edit. Enter any other key to return: ");
            var userInput = Console.ReadLine();
            if (userInput.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AskUserToEditText(string userInput)
        {
            Console.WriteLine("Would you like to edit your erased text?");
            Console.Write("Enter 'Y' to edit. Enter any other key to return: ");
            if (userInput.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AskUserForEditString()
        {
            Console.Clear();
            Console.WriteLine("Enter text to replace the erased area: ");
            return Console.ReadLine();
        }

        public char CreateCharForEditString(char charInEditString, char charInEditArea)
        {
            if (charInEditArea == ' ')
            {
                return charInEditString;
            }
            else
            {
                return '@';
            }
        }

        public bool CheckIfEditAreaSmallerThanEditString(string editArea, int editStringIndex)
        {
            if (editStringIndex > editArea.Length - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // welcome page methods
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
                Console.Write("(1) Write to paper\n(2) Sharpen pencil\nPlease select a numbered action: ");
                var selectionToValidate = Console.ReadLine();
                userSelection = ValidateUserActionRequest(selectionToValidate);
                if (userSelection != 0)
                {
                    return userSelection;
                }
                else
                {
                    Console.Write("Please enter a valid number!");
                    Console.ReadKey();
                }
            }
        }


        // write and sharpen
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
            Console.Write($"Your pencil's gotten smaller. You can sharpen your pencil {_writingUtensil.PencilSize} more time(s).");
            Console.ReadKey();
        }

        public void AlertUserPencilCannotBeSharpened()
        {
            Console.Write("Your pencil is too small to be sharpened!");
            Console.ReadKey();
        }
    }
}
