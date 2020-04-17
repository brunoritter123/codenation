using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CountryTest
    {

        [Fact]
        public void Should_Return_10_Itens_When_Get_Top_10_States()
        {            
            var states = new Country();
            var expected = new State[10] {
                    new State("Amazonas", "AM"),
                    new State("Pará", "PA"),
                    new State("Mato Grosso", "MT"),
                    new State("Minas Gerais", "MG"),
                    new State("Bahia", "BA"),
                    new State("Mato Grosso do Sul", "MS"),
                    new State("Goiás", "GO"),
                    new State("Maranhão", "MA"),
                    new State("Rio Grande do Sul", "RS"),
                    new State("Tocantins", "TO")
            };

            var top = states.Top10StatesByArea();

            Assert.Equal(expected, top, new StateAcronymComparer());
        }
    }
}
