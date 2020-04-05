using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;
            
        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var quoteCount = _context.Quotes.Count();
            if (quoteCount == 0)
                return null;

            int quoteRandom = 1 + _randomService.RandomInteger(quoteCount);
            return _context.Quotes.Take(quoteRandom).LastOrDefault();
        }

        public Quote GetAnyQuote(string actor)
        {
            var quotesActor = _context.Quotes.Where(x => x.Actor == actor);
            int quoteCount = quotesActor.Count();

            if (quoteCount == 0)
                return null;

            int quoteRandom = 1 + _randomService.RandomInteger(quoteCount);
            return quotesActor.Take(quoteRandom).LastOrDefault();
        }
    }
}