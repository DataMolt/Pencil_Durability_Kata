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
            var sut = new RunApplication();
            var beforeWriteTextCount = sut.Paper.Text.Count;
            var wordList = new List<string>();
            for (int i = 0; i < listLength; i++)
            {
                wordList.Add("word");
            }

            sut.WriteTextToPaper(wordList);

            Assert.Equal(sut.Paper.Text.Count, beforeWriteTextCount + listLength);
        }
    }
}
