using System;

namespace Codenation.Challenge.Services
{
    public class RandomService : IRandomService
    {
        private readonly Random _random;
        public RandomService()
        {
            _random = new Random();
        }

        public int RandomInteger(int max)
        {
            return _random.Next(max);
        }
    }
}