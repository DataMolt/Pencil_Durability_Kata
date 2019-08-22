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
    }
}
