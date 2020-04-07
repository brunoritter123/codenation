using System;
using System.Collections.Generic;
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
            int quoteCount = _context.Quotes.Count();
            if (quoteCount == 0)
                return null;

            int quoteRandom = _randomService.RandomInteger(quoteCount);
            return _context.Quotes.Skip(quoteRandom).FirstOrDefault();
        }

        public Quote GetAnyQuote(string actor)
        {
            List<Quote> quotesActor = _context.Quotes.Where(q => q.Actor == actor).ToList();
            int quoteCount = quotesActor.Count();

            if (quoteCount == 0)
                return null;

            int quoteRandom = _randomService.RandomInteger(quoteCount);
            return quotesActor.Skip(quoteRandom).FirstOrDefault();
        }
    }
}