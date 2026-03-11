using Microsoft.EntityFrameworkCore;
using Vehicle.Domain.Entities;

namespace Vehicle.Infrastructure.Data;

public class VehicleDbContext : DbContext
{
    public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
        modelBuilder.Entity<Usuario>().HasIndex(u => u.Login).IsUnique();
        modelBuilder.Entity<Usuario>().Property(u => u.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Veiculo>().HasKey(v => v.Id);
        modelBuilder.Entity<Veiculo>().Property(v => v.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Veiculo>().Property(v => v.Valor).HasPrecision(18, 2);
    }
}
