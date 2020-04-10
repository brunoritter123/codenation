using RestauranteCodenation.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteCodenation.Domain
{
    public class Cardapio : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<AgendaCardapio> AgendaCardapio { get; set; }
        public List<Prato> Pratos { get; set; }
    }
}
