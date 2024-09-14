﻿using Microsoft.EntityFrameworkCore;
using ProjetoDeBloco_FimDeSemana.Models;

namespace ProjetoDeBloco_FimDeSemana.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<CardapioPersonalizado> CardapiosPersonalizados { get; set; }
        public DbSet<ItemCardapio> ItensDoCardapio { get; set; }
        public DbSet<GerenciaReserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre Usuario e Evento (Um usuário pode criar muitos eventos)
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Eventos)
                .HasForeignKey(e => e.UsuarioId);
        }
    }
}
