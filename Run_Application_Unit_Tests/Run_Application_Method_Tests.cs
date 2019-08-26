using System;
using System.Collections.Generic;
using Pencil_Durability_Kata;
using Xunit;

namespace Run_Application_Unit_Tests
{
    public class Run_Application_Method_Tests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void AllTextAppendedToPaper(int listLength)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);
            var beforeWriteTextCount = sut.GetStationaryText().Count;
            var wordList = new List<string>();
            for (int i = 0; i < listLength; i++)
            {
                wordList.Add("word");
            }

            sut.WriteTextToPaper(wordList);

            Assert.Equal(sut.GetStationaryText().Count, beforeWriteTextCount + listLength);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("write")]
        public void OneReturnsWrite(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);

            var result = sut.ValidateUserActionRequest(userInput);

            Assert.True(result == UserActionSelection.write);
        }

        [Theory]
        [InlineData("2")]
        [InlineData("sharpen")]
        public void TwoReturnsSharpen(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);

            var result = sut.ValidateUserActionRequest(userInput);

            Assert.True(result == UserActionSelection.sharpen);
        }

        [Theory]
        [InlineData("3")]
        [InlineData("erase")]
        public void ThreeReturnsErase(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);

            var result = sut.ValidateUserActionRequest(userInput);

            Assert.True(result == UserActionSelection.erase);
        }

        [Theory]
        [InlineData("haha")]
        [InlineData("Adam")]
        public void ReturnsIndexOfLastOccurrenceOfUserInput(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var pencilDrawer = new Stack<IWritingUtensil>();
            paper.Text.Add(userInput);
            paper.Text.Add("test");
            paper.Text.Add(userInput);
            var sut = new RunApplication(paper, pencil, pencilDrawer);

            var result = sut.FindEraseRequestIndexInPaperText(userInput);

            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData("haha")]
        [InlineData("Adam")]
        public void UserRequestFoundInPaperText(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            paper.Text.Add(userInput);
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);

            var result = sut.UserRequestInPaperText(userInput);

            Assert.True(result);
        }

        [Theory]
        [InlineData("haha")]
        [InlineData("Adam")]
        public void UserRequestNotFoundInPaperText(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            paper.Text.Add(userInput);
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);

            var result = sut.UserRequestInPaperText("test");

            Assert.False(result);
        }

        [Theory]
        [InlineData("Y")]
        [InlineData("y")]
        public void YReturnsTrue(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);

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
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);

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
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);
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
            var pencilDrawer = new Stack<IWritingUtensil>();
            var sut = new RunApplication(paper, pencil, pencilDrawer);
            var charToEdit = ' ';

            var result = sut.CreateCharForEditString(userInput, charToEdit);

            Assert.True(result == userInput);
        }
    }
}
