using System;
using System.Collections.Generic;
using System.Text;
using Pencil_Durability_Kata;
using Xunit;

namespace Helper_Unit_Tests
{
    public class Helper_Unit_Tests
    {
        // WRITE HELPERS

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void AllTextAppendedToPaper(int listLength)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new WriteAndSharpenHelper(paper, pencil);
            var beforeWriteTextCount = 0;
            var wordList = new List<string>();
            for (int i = 0; i < listLength; i++)
            {
                wordList.Add("word");
            }

            sut.WriteTextToPaper(wordList);

            Assert.Equal(listLength, beforeWriteTextCount + listLength);
        }

        // ERASE HELPERS

        [Theory]
        [InlineData("haha")]
        [InlineData("Adam")]
        public void ReturnsIndexOfLastOccurrenceOfUserInput(string userInput)
        {
            var paper = new Paper();
            paper.Text.Add(userInput);
            paper.Text.Add("test");
            paper.Text.Add(userInput);
            var sut = new EraseHelper(paper);

            var result = sut.FindEraseRequestIndexInPaperText(userInput);

            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData("haha")]
        [InlineData("Adam")]
        public void UserRequestFoundInPaperText(string userInput)
        {
            var paper = new Paper();
            paper.Text.Add(userInput);
            var sut = new EraseHelper(paper);

            var result = sut.UserRequestInPaperText(userInput);

            Assert.True(result);
        }

        [Theory]
        [InlineData("haha")]
        [InlineData("Adam")]
        public void UserRequestNotFoundInPaperText(string userInput)
        {
            var paper = new Paper();
            paper.Text.Add(userInput);
            var sut = new EraseHelper(paper);

            var result = sut.UserRequestInPaperText("test");

            Assert.False(result);
        }

        // EDIT HELPERS

        [Theory]
        [InlineData("Y")]
        [InlineData("y")]
        public void YReturnsTrue(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var result = sut.AskUserToEditText(userInput);

            Assert.True(result);
        }

        [Theory]
        [InlineData("N")]
        [InlineData("n")]
        [InlineData("abcd")]
        public void AnythingButYReturnsFalse(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var result = sut.AskUserToEditText(userInput);

            Assert.False(result);
        }

        [Theory]
        [InlineData('N')]
        [InlineData('n')]
        [InlineData('!')]
        [InlineData('.')]
        public void NonWhitespaceReturnsAt(char userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var charToEdit = 'A';
            var result = sut.CreateCharForEditString(userInput, charToEdit);

            Assert.True(result == '@');
        }

        [Theory]
        [InlineData('N')]
        public void WhitespaceReturnsEditChar(char userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var charToEdit = ' ';

            var result = sut.CreateCharForEditString(userInput, charToEdit);

            Assert.True(result == userInput);
        }

        [Theory]
        [InlineData("Nn")]
        public void EditAreaSmallerThanEditString(string editArea)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var result = sut.CheckIfEditAreaSmallerThanEditString(editArea, 3);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Nnn")]
        public void EditAreaLargerThanEditString(string editArea)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            paper.Text.Add("aa");
            var sut = new EditHelper(paper, pencil);

            var result = sut.CheckIfEditAreaSmallerThanEditString(editArea, 2);

            Assert.False(result);
        }

        [Fact]
        public void ReturnStringInNextIndex()
        {
            var paper = new Paper();
            var pencil = new Pencil();
            paper.Text.Add("aa");
            paper.Text.Add("bb");
            var sut = new EditHelper(paper, pencil);

            var result = sut.GetStringToAppendToEditArea(0);

            Assert.True(result == " bb");
        }

        [Fact]
        public void LastIndexReturnsEmptyString()
        {
            var paper = new Paper();
            var pencil = new Pencil();
            paper.Text.Add("aa");
            var sut = new EditHelper(paper, pencil);

            var result = sut.GetStringToAppendToEditArea(0);

            Assert.True(result == "");
        }

        [Theory]
        [InlineData(0, "a", 0, " ")]
        public void ReturnEditStringWhenEditAreaIsBlank(int eraseIndex, string editString, int editStringIndex, string editArea)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var result = sut.GetCharToAppendToEditedArea(eraseIndex, editString, editStringIndex, editArea);

            Assert.Equal('a', result);
        }

        [Theory]
        [InlineData(0, "a", 0, "b")]
        public void ReturnAtWhenEditAreaIsBlank(int eraseIndex, string editString, int editStringIndex, string editArea)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var result = sut.GetCharToAppendToEditedArea(eraseIndex, editString, editStringIndex, editArea);

            Assert.Equal('@', result);
        }

        [Theory]
        [InlineData('a')]
        [InlineData('!')]
        [InlineData('.')]
        [InlineData('z')]
        public void PointReductionReturnsOne(char addToEditedString)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var result = sut.GetPointReductionFromAddToEditedString(addToEditedString);

            Assert.True(result == 1);
        }

        [Theory]
        [InlineData('A')]
        public void PointReductionReturnsTwo(char addToEditedString)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var sut = new EditHelper(paper, pencil);

            var result = sut.GetPointReductionFromAddToEditedString(addToEditedString);

            Assert.True(result == 2);
        }

        [Theory]
        [InlineData("Nnn", "Aaaa")]
        public void ReturnLeftoverOriginalCharacters(string appendToEditedString, string editArea)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var editedString = new StringBuilder();
            editedString.Append(appendToEditedString);
            var sut = new EditHelper(paper, pencil);

            sut.AppendRemainingOriginalCharsToEditedString(editedString, editArea);

            Assert.True(editedString.ToString() == "Nnna");
        }


    }
}
