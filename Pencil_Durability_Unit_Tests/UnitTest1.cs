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
    }
}
