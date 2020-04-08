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
            int quotesCount = _context.Quotes.Count();
            int randomIndex = _randomService.RandomInteger(quotesCount);
            return _context.Quotes.ElementAtOrDefault(randomIndex);
        }

        public Quote GetAnyQuote(string actor)
        {
            var quotes = _context.Quotes.Where(q => q.Actor == actor).ToList();

            int quotesCount = quotes.Count();
            int randomIndex = _randomService.RandomInteger(quotesCount);
            return quotes.ElementAtOrDefault(randomIndex);
        }
    }
}