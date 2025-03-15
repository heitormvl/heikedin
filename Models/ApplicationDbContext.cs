using Microsoft.EntityFrameworkCore;

namespace heikedin.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FormModel> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FormModel>(entity =>
            {
                entity.ToTable("Forms");
                entity.HasIndex(e => e.CPF).IsUnique();
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.CPF).IsRequired();
                entity.Property(e => e.DataNascimento).IsRequired();
                entity.Property(e => e.Curso).IsRequired();
                entity.Property(e => e.Descricao).IsRequired();
            });
        }
    }
}
