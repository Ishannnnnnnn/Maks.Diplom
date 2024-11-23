using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация Store для базы данных
/// </summary>
public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id");
        
        builder.OwnsOne(p => p.Address, address =>
        {
            address.Property(f => f.City)
                .IsRequired()
                .HasColumnName("city");

            address.Property(f => f.Street)
                .IsRequired()
                .HasColumnName("street");

            address.Property(f => f.HouseNumber)
                .IsRequired()
                .HasColumnName("house_number");
        });
        
        builder.Property(p => p.Phone)
            .IsRequired()
            .HasColumnName("phone");
        
        builder.HasMany(p => p.Orders)
            .WithOne(p => p.Store)
            .HasForeignKey(p => p.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p => p.InstrumentStores)
            .WithOne(p => p.Store)
            .HasForeignKey(p => p.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}