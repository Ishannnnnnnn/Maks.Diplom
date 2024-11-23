using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация User для базы данных
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id");
        
        builder.OwnsOne(p => p.FullName, fullName =>
        {
            fullName.Property(f => f.Name)
                .IsRequired()
                .HasColumnName("name");

            fullName.Property(f => f.Surname)
                .IsRequired()
                .HasColumnName("surname");

            fullName.Property(f => f.Patronymic)
                .IsRequired()
                .HasColumnName("patronymic");
        });
        
        builder.Property(p => p.Nickname)
            .IsRequired()
            .HasColumnName("nickname");
        
        builder.Property(p => p.Email)
            .IsRequired()
            .HasColumnName("email");
        
        builder.Property(p => p.Password)
            .IsRequired()
            .HasColumnName("password");
        
        builder.Property(p => p.Role)
            .IsRequired()
            .HasDefaultValue(Role.None)
            .HasColumnName("role");
        
        builder.Property(p => p.RegistrationDate)
            .IsRequired()
            .HasColumnName("registration_date")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp without time zone");
        
        builder.Property(p => p.Balance)
            .IsRequired()
            .HasColumnName("balance");
        
        builder.Property(p => p.Purchases)
            .IsRequired()
            .HasColumnName("purchases");
        
        builder.Property(p => p.MoneySpend)
            .IsRequired()
            .HasColumnName("money_spend");
        
        builder.Property(p => p.AvatarUrl)
            .IsRequired()
            .HasColumnName("avatar_url");
        
        builder.HasMany(p => p.Orders)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}