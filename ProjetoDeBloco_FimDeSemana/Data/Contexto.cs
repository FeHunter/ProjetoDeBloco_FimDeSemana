using Microsoft.EntityFrameworkCore;
using ProjetoDeBloco_FimDeSemana.Models;

namespace ProjetoDeBloco_FimDeSemana.Data
{
    public class Contexto : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<CardapioPersonalizado> CardapiosPersonalizados { get; set; }
        public DbSet<ItemCardapio> ItensDoCardapio { get; set; }
        public DbSet<GerenciaReserva> Reservas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre Usuario e Evento (Um usuário pode criar muitos eventos)
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Eventos)
                .HasForeignKey(e => e.UsuarioId);

            // Relacionamento entre Evento e Cardapio (Um evento tem um cardápio opcional)
            modelBuilder.Entity<Cardapio>()
                .HasOne(c => c.Evento)
                .WithOne(e => e.Cardapio)
                .HasForeignKey<Cardapio>(c => c.EventoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento entre Cardapio e ItemDoCardapio (Um cardápio tem muitos itens)
            modelBuilder.Entity<ItemCardapio>()
                .HasOne(i => i.Cardapio)
                .WithMany(c => c.ItensDoCardapio)
                .HasForeignKey(i => i.CardapioId);

            // Relacionamento entre Evento e CardapioPersonalizado (Um evento pode ter vários cardápios personalizados)
            modelBuilder.Entity<CardapioPersonalizado>()
                .HasOne(cp => cp.Evento)
                .WithMany(e => e.CardapiosPersonalizados)
                .HasForeignKey(cp => cp.EventoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
