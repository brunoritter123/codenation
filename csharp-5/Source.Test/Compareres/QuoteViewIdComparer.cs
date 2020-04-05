using Codenation.Challenge.Models;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class QuoteViewIdComparer : IEqualityComparer<QuoteView>
    {
        public bool Equals(QuoteView x, QuoteView y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(QuoteView obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}