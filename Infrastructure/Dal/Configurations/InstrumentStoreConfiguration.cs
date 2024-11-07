using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация InstrumentStore для базы данных
/// </summary>
public class InstrumentStoreConfiguration : IEntityTypeConfiguration<InstrumentStore>
{
    public void Configure(EntityTypeBuilder<InstrumentStore> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id");
        
        builder.Property(p => p.InstrumentId)
            .IsRequired()
            .HasColumnName("instrument_id");
        
        builder.Property(p => p.StoreId)
            .IsRequired()
            .HasColumnName("store_id");
        
        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnName("amount");
        
        builder.HasOne(p => p.Instrument)
            .WithMany(u => u.InstrumentStores)
            .HasForeignKey(p => p.InstrumentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Store)
            .WithMany(u => u.InstrumentStores)
            .HasForeignKey(p => p.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}