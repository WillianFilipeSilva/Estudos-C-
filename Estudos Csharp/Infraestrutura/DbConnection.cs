using Microsoft.EntityFrameworkCore;

namespace Estudos_Csharp.Infraestrutura
{
    public class DbConnection : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<LivroLocado> LivrosLocados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=biblioteca;User Id=postgres;Password=@pilar123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroLocado>()
                .HasOne(ll => ll.Solicitante)
                .WithMany(s => s.Locacoes)
                .HasForeignKey(ll => ll.SolicitanteId);

            modelBuilder.Entity<LivroLocado>()
                .HasOne(ll => ll.Livro)
                .WithMany()
                .HasForeignKey(ll => ll.LivroId);
        }
    }
}
