using Pencil_Durability_Kata;
using System;
using Xunit;

namespace Pencil_Durability_Unit_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        public void CheckForTwo(char letter)
        {
            // act
            var sut = new Pencil();
            var num = sut.FindCharReductionRate(letter);

            // assert
            Assert.Equal(2, num);
        }

        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('.')]
        [InlineData(',')]
        [InlineData('!')]
        public void CheckForOne(char letter)
        {
            // act
            var sut = new Pencil();
            var num = sut.FindCharReductionRate(letter);

            // assert
            Assert.Equal(1, num);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(40)]
        [InlineData(400)]
        [InlineData(4000)]
        [InlineData(40000)]
        public void OutputEqualsWordLength(int wordLength)
        {
            // act
            var sut = new Pencil();
            var word = new string('a', wordLength);
            var num = sut.FindWordLength(word);

            // assert
            Assert.Equal(word.Length, num);
        }

        [Theory]
        [InlineData(40001)]
        public void OutputExceedsDurability(int wordLength)
        {
            // act
            var sut = new Pencil();
            var word = new string('a', wordLength);
            var num = sut.FindWordLength(word);

            // assert
            Assert.Equal(40000, num);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(40)]
        [InlineData(400)]
        [InlineData(4000)]
        [InlineData(40000)]
        public void CorrectDurrabilityReduction(int wordLength)
        {
            // act
            var sut = new Pencil();
            var word = new string('a', wordLength);
            var num = sut.FindWordLength(word);

            // assert
            Assert.Equal(40000-num, sut.PointDurability);
        }
    }
}
