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

        private IEraseHelper _eraseHelper;

        private IEditHelper _editHelper;

        private IWriteAndSharpenHelper _writeAndSharpenHelper;

        public RunApplication(IStationary stationary, IWritingUtensil writingUtensil, Stack<IWritingUtensil> pencilDrawer, IEraseHelper eraseHelper,
            IEditHelper editHelper, IWriteAndSharpenHelper writeAndSharpenHelper)
        {
            _stationary = stationary;
            _writingUtensil = writingUtensil;
            _pencilDrawer = pencilDrawer;
            _eraseHelper = eraseHelper;
            _editHelper = editHelper;
            _writeAndSharpenHelper = writeAndSharpenHelper;
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
                    case UserActionSelection.newPencil:
                        BuildNewPencil();
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
                    _writeAndSharpenHelper.AlertUserPencilNeedsSharpening();
                    break;
                }
            }
            _writeAndSharpenHelper.WriteTextToPaper(writeToPaper);
        }

        public void SharpenPencil()
        {
            if (_writingUtensil.PencilSize > 0)
            {
                _writingUtensil.ResetPencilDurability();
                _writingUtensil.ReducePencilLength();
                _writeAndSharpenHelper.AlertUserPencilLengthReduced();
            }
            else
            {
                _writeAndSharpenHelper.AlertUserPencilCannotBeSharpened();
            }
        }

        public void Erase()
        {
            Console.Clear();
            var userInput = _eraseHelper.GetUserEraseRequest();
            int userInputIndex;
            if (_eraseHelper.UserRequestInPaperText(userInput))
            {
                userInputIndex = _eraseHelper.FindEraseRequestIndexInPaperText(userInput);
                var wordToErase = _stationary.Text[userInputIndex];
                var eraseResults = _writingUtensil.BuildWordForErasing(wordToErase);
                _stationary.Text[userInputIndex] = eraseResults;
                Edit(userInputIndex);
            }
            else
            {
                _eraseHelper.AlertUserRequestNotFoundInText();
            }
        }

        public void Edit(int eraseIndex)
        {
            var continueToEdit = _editHelper.AskUserToEditText();
            if (continueToEdit)
            {
                Console.WriteLine("Enter text to replace the erased area: ");
                var editString = _editHelper.AskUserForEditString();
                var editArea = _stationary.Text[eraseIndex];
                StringBuilder buildEditedString = new StringBuilder();
                for (int editStringIndex = 0; editStringIndex < editString.Length; editStringIndex++)
                {
                    var editAreaSmallerThanEditString =
                        _editHelper.CheckIfEditAreaSmallerThanEditString(editArea, editStringIndex);
                    if (editAreaSmallerThanEditString)
                    {
                        editArea += _editHelper.GetStringToAppendToEditArea(eraseIndex);
                    }

                    char addToEditedString = _editHelper.GetCharToAppendToEditedArea(eraseIndex, editString, editStringIndex, editArea);
                    int eraserReductionRate = _editHelper.GetPointReductionFromAddToEditedString(addToEditedString);

                    if (_writingUtensil.PointDurability >= eraserReductionRate)
                    {
                        buildEditedString.Append(addToEditedString);
                        _writingUtensil.ReducePointDurability(eraserReductionRate);
                    }
                }

                _editHelper.AppendRemainingOriginalCharsToEditedString(buildEditedString, editArea);

                _stationary.Text[eraseIndex] = buildEditedString.ToString();
            }
        }

        // write test for this
        public void BuildNewPencil()
        {
            if (_pencilDrawer.Count != 0)
            {
                _writingUtensil = _pencilDrawer.Pop();
                Console.WriteLine($"\nYou now have a new pencil. You have {_pencilDrawer.Count} pencil(s) left.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nYou've run out of extra pencils!");
                Console.ReadKey();
            }
        }

        public void DisplayPencilStats()
        {
            Console.WriteLine($"Point Durability: {_writingUtensil.PointDurability}     Eraser Durability: {_writingUtensil.EraserDurability}\n");
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
                _writeAndSharpenHelper.WritePaperContentsToConsole();
                DisplayPencilStats();
                Console.Write("(1) Write to paper\n(2) Sharpen pencil\n(3) Erase text from paper" +
                    "\n(4) Retrieve new pencil\nPlease select a numbered action: ");
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
    }
}
