using Pencil_Durability_Kata;
using System;
using Xunit;

namespace Pencil_Durability_Unit_Tests
{
    public class UnitTest1
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
    }
}
