using Microsoft.EntityFrameworkCore;

namespace Estudos_Csharp.Infraestrutura
{
    public class DbConnection : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<LivroLocado> LivrosLocados { get; set; }
        public DbSet<LivroEstoque> LivrosEstoque { get; set; }
        public DbSet<LocacaoFinalizada> LocacoesFinalizadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=biblioteca;User Id=postgres;Password=@pilar123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroLocado>()
                .HasOne(ll => ll.Solicitante)
                .WithMany(s => s.Locacoes)
                .HasForeignKey(ll => ll.SolicitanteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LivroLocado>()
                .HasOne(ll => ll.Livro)
                .WithMany()
                .HasForeignKey(ll => ll.LivroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LocacaoFinalizada>()
                .HasOne(lf => lf.Solicitante)
                .WithMany(s => s.LocacoesFinalizadas)
                .HasForeignKey(lf => lf.SolicitanteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LocacaoFinalizada>()
                .HasOne(lf => lf.LivroLocado)
                .WithMany()
                .HasForeignKey(lf => lf.LivroLocadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LivroEstoque>()
                .HasOne(le => le.Livro)
                .WithMany()
                .HasForeignKey(le => le.LivroId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
