﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteCodenation.Data;

namespace RestauranteCodenation.Data.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200403013405_MeuPrimeiroBanco")]
    partial class MeuPrimeiroBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestauranteCodenation.Domain.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.AgendaCardapio", b =>
                {
                    b.Property<int>("IdAgenda")
                        .HasColumnType("int");

                    b.Property<int>("IdCardapio")
                        .HasColumnType("int");

                    b.HasKey("IdAgenda", "IdCardapio");

                    b.HasIndex("IdCardapio");

                    b.ToTable("AgendaCardapio");
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.Cardapio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cardapio");
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.Prato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CardapioId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("IdTipoPrato")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CardapioId");

                    b.HasIndex("IdTipoPrato");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.PratosIngredientes", b =>
                {
                    b.Property<int>("IdPrato")
                        .HasColumnType("int");

                    b.Property<int>("IdIngrediente")
                        .HasColumnType("int");

                    b.HasKey("IdPrato", "IdIngrediente");

                    b.HasIndex("IdIngrediente");

                    b.ToTable("PratosIngredientes");
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.TipoPrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoPrato");
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.AgendaCardapio", b =>
                {
                    b.HasOne("RestauranteCodenation.Domain.Agenda", "Agenda")
                        .WithMany("AgendaCardapio")
                        .HasForeignKey("IdAgenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteCodenation.Domain.Cardapio", "Cardapio")
                        .WithMany("AgendaCardapio")
                        .HasForeignKey("IdCardapio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.Prato", b =>
                {
                    b.HasOne("RestauranteCodenation.Domain.Cardapio", null)
                        .WithMany("Pratos")
                        .HasForeignKey("CardapioId");

                    b.HasOne("RestauranteCodenation.Domain.TipoPrato", "TipoPrato")
                        .WithMany("Pratos")
                        .HasForeignKey("IdTipoPrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestauranteCodenation.Domain.PratosIngredientes", b =>
                {
                    b.HasOne("RestauranteCodenation.Domain.Ingrediente", "Ingrediente")
                        .WithMany("PratosIngredientes")
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteCodenation.Domain.Prato", "Prato")
                        .WithMany("PratosIngredientes")
                        .HasForeignKey("IdPrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
