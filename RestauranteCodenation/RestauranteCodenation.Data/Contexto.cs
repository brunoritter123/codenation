using Microsoft.EntityFrameworkCore;
using RestauranteCodenation.Data.Map;
using RestauranteCodenation.Domain;
using System;

namespace RestauranteCodenation.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Cardapio> Cardapio { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Prato> Prato { get; set; }
        public DbSet<TipoPrato> TipoPrato { get; set; }
        public DbSet<Agenda> DiaCardapio { get; set; }
        public DbSet<PratosIngredientes> PratosIngredientes{ get; set; }
        public DbSet<AgendaCardapio> AgendaCardapio { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendaCardapioMap());
            modelBuilder.ApplyConfiguration(new AgendaMap());
            modelBuilder.ApplyConfiguration(new CardapioMap());
            modelBuilder.ApplyConfiguration(new IngredienteMap());
            modelBuilder.ApplyConfiguration(new PratoMap());
            modelBuilder.ApplyConfiguration(new PratosIngredientesMap());
            modelBuilder.ApplyConfiguration(new TipoPratoMap());

            base.OnModelCreating(modelBuilder);
        }
    }

}
