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
            // act
            var sut = new Pencil();
            var num = sut.FindCharReductionRate(letter);

            // assert
            Assert.Equal(1, num);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        public void CapitalLettersReturnReductionRateOfTwo(char letter)
        {
            // act
            var sut = new Pencil();
            var num = sut.FindCharReductionRate(letter);

            // assert
            Assert.Equal(2, num);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(40)]
        [InlineData(400)]
        [InlineData(4000)]
        [InlineData(40000)]
        public void ReduceDurabilityByWeightOfCharacter(int reduceBy)
        {
            // act
            var sut = new Pencil();
            sut.ReducePointDurability(reduceBy);

            // assert
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
            // act
            var sut = new Pencil();
            var num = sut.ReducePointDurability(reduceBy);

            // assert
            Assert.False(num);
        }

        [Theory]
        [InlineData(40001)]
        public void IfCharacterWeightExceedsDurabilityReduceToZero(int reduceBy)
        {
            // act
            var sut = new Pencil();
            sut.ReducePointDurability(reduceBy);

            // assert
            Assert.Equal(0, sut.PointDurability);
        }

        [Theory]
        [InlineData(40001)]
        public void ReturnTrueIfReducebyExceedsPointDurability(int reduceBy)
        {
            // act
            var sut = new Pencil();
            var num = sut.ReducePointDurability(reduceBy);

            // assert
            Assert.True(num);
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
            // act
            var sut = new Pencil();
            var word = new string('a', wordLength);
            var num = sut.BuildWordForWritingToPaper(word);

            // assert
            Assert.True(40000 >= num.Length);
        }

        
        [Theory]
        [InlineData("This is a string")]
        public void UserInputConvertedToStringArray(string userInput)
        {
            // act
            var sut = new Pencil();
            var num = sut.BuildWordArray(userInput);

            // assert
            Assert.IsType<string[]>(num);
        }

        [Fact]
        public void RandomizerReturnsNumberBetweenOneAndThree()
        {
            // act
            var sut = new Pencil();
            var num = sut.GeneratePencilLength();

            // assert
            Assert.True((num >= 1) && (num <= 3));
        }

        [Fact]
        public void PencilLengthReducedByOne()
        {
            // act
            var sut = new Pencil();
            var initialPencilSize = sut.PencilSize;
            sut.ReducePencilLength();

            // assert
            Assert.Equal(initialPencilSize - 1, sut.PencilSize);
        }

        [Fact]
        public void PencilDurabilyResetsTo40000()
        {
            // act
            var sut = new Pencil();
            sut.ResetPencilDurability();

            // assert
            Assert.Equal(40000, sut.PointDurability);
        }
    }
}
