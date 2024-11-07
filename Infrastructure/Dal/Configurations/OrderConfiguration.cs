using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация Order для базы данных
/// </summary>
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id");
        
        builder.Property(p => p.OrderDate)
            .IsRequired()
            .HasColumnName("order_date");
        
        builder.Property(p => p.StoreId)
            .IsRequired()
            .HasColumnName("store_id");
        
        builder.Property(p => p.UserId)
            .IsRequired()
            .HasColumnName("user_id");
        
        builder.HasOne(p => p.Store)
            .WithMany(s => s.Orders)
            .HasForeignKey(p => p.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p => p.OrderInstruments)
            .WithOne(p => p.Order)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}