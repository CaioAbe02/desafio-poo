using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Db;

public class DbContexto : DbContext
{
  public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

  public DbSet<Proprietario> Proprietarios => Set<Proprietario>();
  public DbSet<Casa> Casas => Set<Casa>();
  public DbSet<Apartamento> Apartamentos => Set<Apartamento>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Proprietario>()
      .HasMany<Casa>()
      .WithOne(i => i.Proprietario)
      .HasForeignKey(i => i.ProprietarioId)
      .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Proprietario>()
      .HasMany<Apartamento>()
      .WithOne(i => i.Proprietario)
      .HasForeignKey(i => i.ProprietarioId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}