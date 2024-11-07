using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация Instrument для базы данных
/// </summary>
public class InstrumentConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id");
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("name");
        
        builder.Property(p => p.Category)
            .IsRequired()
            .HasDefaultValue(Category.None)
            .HasColumnName("category");
        
        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnName("price");
        
        builder.HasMany(p => p.OrderInstruments)
            .WithOne(p => p.Instrument)
            .HasForeignKey(p => p.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p => p.InstrumentStores)
            .WithOne(p => p.Instrument)
            .HasForeignKey(p => p.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}