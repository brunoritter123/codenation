using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Services;
using Xunit;

namespace Codenation.Challenge
{
    public class RandomServiceTest
    {
        [Fact]
        public void Should_Generate_Random_Number_When_Get_Random_Integer()
        {
            var service = new RandomService();
            var numbers = new List<int>();
            for (var i = 0; i < 100; i++)
                numbers.Add(service.RandomInteger(50));
            Assert.True(numbers.Sum() / numbers[0] != numbers.Count);
        }

        [Fact]
        public void RandomIntegerTest_NumberOne()
        {
            var service = new RandomService();
            int numberOne = 0;
            for (var i = 0; i < 200; i++)
                if (service.RandomInteger(2) == 1)
                    numberOne++;

            Assert.True(numberOne > 80 && numberOne < 120);
        }

    }

}