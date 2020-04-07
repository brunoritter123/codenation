using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Controllers;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Codenation.Challenge
{
    public class QuoteControllerTest
    {
        private Mock<ScriptsContext> fakeContext;
        private List<Quote> fakeData = new List<Quote>();

        public QuoteControllerTest()
        {
            fakeData.AddRange(new List<Quote>() {
                new Quote() { Id = 1, Actor = "Eric", Detail = "Ni" },
                new Quote() { Id = 2, Actor = "Terry", Detail = "Ni" },
                new Quote() { Id = 3, Actor = "Graham", Detail = "Ni" }
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
        public void Should_Returns_Not_Found_When_Get_Any_Quote_By_Non_Exists_Actor()
        {
            var fakeService = new QuoteService(fakeContext.Object, new RandomService());
            var controller = new QuoteController(fakeService);

            var actual = controller.GetAnyQuote("Brian");
            Assert.NotNull(actual);
            Assert.IsType<NotFoundResult>(actual.Result);
        }

        [Fact]
        public void GetAnyQuoteTest_Actor_ReturnRandom()
        {
            var fakeService = new QuoteService(fakeContext.Object, new RandomService());
            var controller = new QuoteController(fakeService);
            var actualActionResult = controller.GetAnyQuote("Graham");
            var expected = fakeContext.Object.Quotes.FirstOrDefault(x => x.Id == 3);

            var actualResult = Assert.IsType<OkObjectResult>(actualActionResult.Result);
            var actual = Assert.IsType<QuoteView>(actualResult.Value);

            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public void GetAnyQuoteTest_NotActor_ReturnRandom()
        {
            var fakeService = new QuoteService(fakeContext.Object, new RandomService());
            var controller = new QuoteController(fakeService);
            var actualActionResult = controller.GetAnyQuote();
            var actualResult = Assert.IsType<OkObjectResult>(actualActionResult.Result);
            var actual = Assert.IsType<QuoteView>(actualResult.Value);

            Assert.InRange(actual.Id, fakeContext.Object.Quotes.First().Id, fakeContext.Object.Quotes.Last().Id);
        }

        //[Fact]
        //public void GetAnyQuoteTest_NotActor_ReturnNull()
        //{
        //    var fakeRandom = new Mock<IRandomService>();
        //    fakeRandom.Setup(x => x.RandomInteger(It.IsAny<int>())).Returns(0);
        //    var fakeService = new QuoteService(fakeContext.Object, fakeRandom.Object);
        //    var controller = new QuoteController(fakeService);

        //    // Criando um backup dos dados
        //    var quotes = fakeContext.Object.Quotes.ToList();

        //    // Deletando os dados
        //    fakeContext.Object.Quotes.RemoveRange(quotes);
        //    fakeContext.Object.SaveChanges();

        //    var actual = controller.GetAnyQuote();

        //    // Restaurando os dados
        //    fakeContext.Object.Quotes.AddRange(quotes);
        //    fakeContext.Object.SaveChanges();

        //    Assert.NotNull(actual);
        //    Assert.IsType<NoContentResult>(actual.Result);
        //}
    }
}
