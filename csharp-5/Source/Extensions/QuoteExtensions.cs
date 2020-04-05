using Codenation.Challenge.Models;

namespace Codenation.Challenge.Extensions
{
    public static class QuoteExtensions
    {
        public static QuoteView ToApiView(this Quote quote)
        {
            if (quote is null)
                return null;

            return new QuoteView()
            {
                Id = quote.Id,
                Actor = quote.Actor,
                Detail = quote.Detail
            };
        }
    }
}
