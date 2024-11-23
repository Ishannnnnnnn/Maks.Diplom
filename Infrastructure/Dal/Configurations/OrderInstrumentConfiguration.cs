using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация OrderInstrument для базы данных
/// </summary>
public class OrderInstrumentConfiguration : IEntityTypeConfiguration<OrderInstrument>
{
    public void Configure(EntityTypeBuilder<OrderInstrument> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id");
        
        builder.Property(p => p.InstrumentId)
            .IsRequired()
            .HasColumnName("instrument_id");
        
        builder.Property(p => p.OrderId)
            .IsRequired()
            .HasColumnName("order_id");
        
        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnName("amount");
        
        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnName("price");
        
        builder.HasOne(p => p.Instrument)
            .WithMany(u => u.OrderInstruments)
            .HasForeignKey(p => p.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Order)
            .WithMany(u => u.OrderInstruments)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}