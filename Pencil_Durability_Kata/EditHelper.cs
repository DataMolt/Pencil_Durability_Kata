using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class EditHelper : IEditHelper
    {
        public IStationary _stationary { get; set; }
        public IWritingUtensil _writingUtensil { get; set; }

        public EditHelper(IStationary stationary, IWritingUtensil writingUtensil)
        {
            _stationary = stationary;
            _writingUtensil = writingUtensil;
        }

        public bool AskUserToEditText()
        {
            Console.Clear();
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
            if (charInEditArea != ' ')
            {
                return '@';
            }
            else
            {
                return charInEditString;
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

        public string GetStringToAppendToEditArea(int eraseIndex)
        {
            if (eraseIndex < _stationary.Text.Count - 1)
            {
                var stringToAppend = " " + _stationary.Text[eraseIndex + 1];
                _stationary.Text.RemoveAt(eraseIndex + 1);
                return stringToAppend;
            }
            else
            {
                return "";
            }
        }

        public char GetCharToAppendToEditedArea(int eraseIndex, string editString, int editStringIndex, string editArea)
        {
            char addToEditedString;
            if (eraseIndex == _stationary.Text.Count - 1 && editStringIndex > editArea.Length - 1)
            {
                addToEditedString = editString[editStringIndex];
            }
            else
            {
                addToEditedString = CreateCharForEditString(editString[editStringIndex], editArea[editStringIndex]);
            }
            return addToEditedString;
        }

        public int GetPointReductionFromAddToEditedString(char addToEditedString)
        {
            return _writingUtensil.FindCharReductionRate(addToEditedString);
        }

        public void AppendRemainingOriginalCharsToEditedString(StringBuilder buildEditedString, string editArea)
        {
            if (buildEditedString.Length < editArea.Length)
            {
                for (int i = buildEditedString.Length; i < editArea.Length; i++)
                {
                    buildEditedString.Append(editArea[i]);
                }
            }
        }
    }
}
