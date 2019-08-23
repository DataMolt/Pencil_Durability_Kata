using Pencil_Durability_Kata;
using System;
using System.Collections.Generic;
using Xunit;

namespace Pencil_Unit_Tests
{
    public class Pencil_Methods_Tests
    {
        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('.')]
        [InlineData(',')]
        [InlineData('!')]
        public void LowercaseLettersReturnReductionRateOfOne(char letter)
        {
            var sut = new Pencil();
            var result = sut.FindCharReductionRate(letter);

            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        public void CapitalLettersReturnReductionRateOfTwo(char letter)
        {
            var sut = new Pencil();
            var result = sut.FindCharReductionRate(letter);

            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(40)]
        [InlineData(400)]
        [InlineData(4000)]
        [InlineData(40000)]
        public void ReduceDurabilityByWeightOfCharacter(int reduceBy)
        {
            var sut = new Pencil();

            sut.ReducePointDurability(reduceBy);

            Assert.Equal(40000-reduceBy, sut.PointDurability);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(40)]
        [InlineData(400)]
        [InlineData(4000)]
        [InlineData(40000)]
        public void ReturnFalseIfReducebySmallerThanDurability(int reduceBy)
        {
            var sut = new Pencil();
            var result = sut.ReducePointDurability(reduceBy);

            Assert.False(result);
        }

        [Theory]
        [InlineData(40001)]
        public void IfCharacterWeightExceedsDurabilityReduceToZero(int reduceBy)
        {
            var sut = new Pencil();

            sut.ReducePointDurability(reduceBy);

            Assert.Equal(0, sut.PointDurability);
        }

        [Theory]
        [InlineData(40001)]
        public void ReturnTrueIfReducebyExceedsPointDurability(int reduceBy)
        {
            var sut = new Pencil();
            var result = sut.ReducePointDurability(reduceBy);

            Assert.True(result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(40)]
        [InlineData(400)]
        [InlineData(4000)]
        [InlineData(40000)]
        [InlineData(40001)]
        public void WordLengthShouldNotExceedDurability(int wordLength)
        {
            var sut = new Pencil();
            var word = new string('a', wordLength);
            var result = sut.BuildWordForWritingToPaper(word);

            Assert.True(40000 >= result.Length);
        }

        [Theory]
        [InlineData("This is a string")]
        public void UserInputConvertedToStringArray(string userInput)
        {
            var sut = new Pencil();
            var result = sut.BuildWordArray(userInput);

            Assert.IsType<string[]>(result);
        }

        [Fact]
        public void RandomizerReturnsNumberBetweenOneAndThree()
        {
            var sut = new Pencil();
            var result = sut.GeneratePencilLength();

            Assert.True((result >= 1) && (result <= 3));
        }

        [Fact]
        public void PencilLengthReducedByOne()
        {
            var sut = new Pencil();
            var initialPencilSize = sut.PencilSize;

            sut.ReducePencilLength();

            Assert.Equal(initialPencilSize - 1, sut.PencilSize);
        }

        [Fact]
        public void PencilDurabilyResetsTo40000()
        {
            var sut = new Pencil();

            sut.ResetPencilDurability();

            Assert.Equal(40000, sut.PointDurability);
        }

        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('!')]
        public void LowercaseLettersReturnEraserReductionOfOne(char letter)
        {
            var sut = new Pencil();
            var result = sut.FindEraserReductionRate(letter);

            Assert.Equal(1, result);
        }
    }
}
