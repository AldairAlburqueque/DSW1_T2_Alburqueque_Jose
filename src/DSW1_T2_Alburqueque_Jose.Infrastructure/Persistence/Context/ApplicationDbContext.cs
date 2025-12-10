using DSW1_T2_Alburqueque_Jose.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Book>()
          .HasIndex(b => b.ISBN)
          .IsUnique(); // asegura ISBN único

      modelBuilder.Entity<Loan>()
          .Property(l => l.Status)
          .HasMaxLength(20);
    }
  }
}
