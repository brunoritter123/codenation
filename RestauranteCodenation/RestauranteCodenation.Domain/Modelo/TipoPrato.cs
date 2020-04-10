using RestauranteCodenation.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteCodenation.Domain
{
    public class TipoPrato : IEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Prato> Pratos { get; set; }
    }
}
