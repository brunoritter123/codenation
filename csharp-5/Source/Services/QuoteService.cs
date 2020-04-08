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
            int random = _randomService.RandomInteger(_context.Quotes.Count());
            return _context.Quotes.ElementAtOrDefault(random);
        }

        public Quote GetAnyQuote(string actor)
        {
            List<Quote> quotes = _context.Quotes.Where(q => q.Actor == actor).ToList();

            int random = _randomService.RandomInteger(quotes.Count());
            return quotes.ElementAtOrDefault(random);
        }
    }
}