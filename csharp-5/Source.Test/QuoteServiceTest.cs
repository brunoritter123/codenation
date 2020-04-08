using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Codenation.Challenge
{
    public class QuoteServiceTest
    {
        private Mock<ScriptsContext> fakeContext;
        private List<Quote> fakeData = new List<Quote>();

        public QuoteServiceTest()
        {
            fakeData.AddRange(new List<Quote>() {
                new Quote() { Id = 1, Actor = "Eric", Detail = "Ni" },
                new Quote() { Id = 2, Actor = "Terry", Detail = "Ni" },
                new Quote() { Id = 3, Actor = "Graham", Detail = "Ni" },
                new Quote() { Id = 4, Actor = "Graham", Detail = "Ni" },
            });

            var fakeQuotes = fakeData.AsQueryable();
            var fakeDbSet = new Mock<DbSet<Quote>>();
            fakeDbSet.As<IQueryable<Quote>>().Setup(x => x.Provider).Returns(fakeQuotes.Provider);
            fakeDbSet.As<IQueryable<Quote>>().Setup(x => x.Expression).Returns(fakeQuotes.Expression);
            fakeDbSet.As<IQueryable<Quote>>().Setup(x => x.ElementType).Returns(fakeQuotes.ElementType);
            fakeDbSet.As<IQueryable<Quote>>().Setup(x => x.GetEnumerator()).Returns(fakeQuotes.GetEnumerator());

            this.fakeContext = new Mock<ScriptsContext>();
            this.fakeContext.Setup(x => x.Quotes).Returns(fakeDbSet.Object);
        }

        [Fact]
        public void Should_Returns_Null_When_Get_Any_Quote_By_Non_Exists_Actor()
        {
            var fakeService = new QuoteService(fakeContext.Object, new RandomService());
            var actual = fakeService.GetAnyQuote("Brian");
            Assert.Null(actual);
        }

        [Fact]
        public void GetAnyQuoteTest_Actor_ReturnRandom()
        {
            var fakeService = new QuoteService(fakeContext.Object, new RandomService());
            long totalId3 = 0;

            for (var i = 0; i < 100; i++)
                if (fakeService.GetAnyQuote("Graham").Id == 3)
                    totalId3++;

            Assert.True(totalId3 > 35 && totalId3 < 65);
        }

        [Fact]
        public void GetAnyQuoteTest_NotActor_ReturnRandom()
        {
            var fakeService = new QuoteService(fakeContext.Object, new RandomService());
            var quoteRandom = new List<Quote>();

            for (var i = 0; i < 100; i++)
                quoteRandom.Add(fakeService.GetAnyQuote());

            foreach (var quote in fakeContext.Object.Quotes)
            {
                Assert.Contains(quote, quoteRandom, new QuoteIdComparer());
            }
        }
    }
}
