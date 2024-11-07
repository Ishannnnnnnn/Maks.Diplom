using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Dal.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal;

/// <summary>
/// Контекст базы данных
/// </summary>
public class MusicStoreDbContext : DbContext
{
    public DbSet<User> Users { get; init; }
    public DbSet<Order> Orders { get; init; }
    public DbSet<Store> Stores { get; init; }
    public DbSet<Instrument> Instruments { get; init; }
    
    public DbSet<InstrumentStore> InstrumentStores { get; init; }
    public DbSet<OrderInstrument> OrderInstruments { get; init; }
    
    public MusicStoreDbContext()
    {
    }

    public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=MusicStore;Username=postgres;Password=7733");
    }

    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Category>();
        modelBuilder.HasPostgresEnum<Role>();
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new StoreConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new InstrumentConfiguration());
        modelBuilder.ApplyConfiguration(new OrderInstrumentConfiguration());
        modelBuilder.ApplyConfiguration(new InstrumentStoreConfiguration());
    }
}