using Codenation.Challenge.Models;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class QuoteIdComparer : IEqualityComparer<Quote>
    {
        public bool Equals(Quote x, Quote y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Quote obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}