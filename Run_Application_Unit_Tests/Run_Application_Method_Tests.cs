using System;
using System.Collections.Generic;
using Pencil_Durability_Kata;
using Xunit;

namespace Run_Application_Unit_Tests
{
    public class Run_Application_Method_Tests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("write")]
        public void OneReturnsWrite(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var pencilDrawer = new Stack<IWritingUtensil>();
            var eraseHelper = new EraseHelper(paper);
            var editHelper = new EditHelper(paper, pencil);
            var writeAndSharpenHelper = new WriteAndSharpenHelper(paper, pencil);
            var sut = new RunApplication(paper, pencil, pencilDrawer, eraseHelper, editHelper, writeAndSharpenHelper);

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
            var eraseHelper = new EraseHelper(paper);
            var editHelper = new EditHelper(paper, pencil);
            var writeAndSharpenHelper = new WriteAndSharpenHelper(paper, pencil);
            var sut = new RunApplication(paper, pencil, pencilDrawer, eraseHelper, editHelper, writeAndSharpenHelper);

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
            var eraseHelper = new EraseHelper(paper);
            var editHelper = new EditHelper(paper, pencil);
            var writeAndSharpenHelper = new WriteAndSharpenHelper(paper, pencil);
            var sut = new RunApplication(paper, pencil, pencilDrawer, eraseHelper, editHelper, writeAndSharpenHelper);

            var result = sut.ValidateUserActionRequest(userInput);

            Assert.True(result == UserActionSelection.erase);
        }

        [Theory]
        [InlineData("4")]
        [InlineData("newPencil")]
        public void FourReturnsNewPencil(string userInput)
        {
            var paper = new Paper();
            var pencil = new Pencil();
            var pencilDrawer = new Stack<IWritingUtensil>();
            var eraseHelper = new EraseHelper(paper);
            var editHelper = new EditHelper(paper, pencil);
            var writeAndSharpenHelper = new WriteAndSharpenHelper(paper, pencil);
            var sut = new RunApplication(paper, pencil, pencilDrawer, eraseHelper, editHelper, writeAndSharpenHelper);

            var result = sut.ValidateUserActionRequest(userInput);

            Assert.True(result == UserActionSelection.newPencil);
        }
    }
}
