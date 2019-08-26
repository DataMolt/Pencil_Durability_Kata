using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public interface IEditHelper
    {
        IStationary _stationary { get; set; }

        bool AskUserToEditText();

        bool AskUserToEditText(string userInput);

        string AskUserForEditString();

        char CreateCharForEditString(char charInEditString, char charInEditArea);

        bool CheckIfEditAreaSmallerThanEditString(string editArea, int editStringIndex);

        string GetStringToAppendToEditArea(int eraseIndex);

        char GetCharToAppendToEditedArea(int eraseIndex, string editString, int editStringIndex, string editArea);

        int GetPointReductionFromAddToEditedString(char addToEditedString);

        void AppendRemainingOriginalCharsToEditedString(StringBuilder buildEditedString, string editArea);
    }
}
