using Microsoft.EntityFrameworkCore;
using ProjetoDeBloco_FimDeSemana.Models;

namespace ProjetoDeBloco_FimDeSemana.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Usuario> Produtos { get; set; }
    }
}
