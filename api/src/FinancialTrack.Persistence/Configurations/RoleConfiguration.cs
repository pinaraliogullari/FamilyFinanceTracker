using FinancialTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialTrack.Persistence.Configurations;

public class RoleConfiguration:IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData
        (
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "User" }
        );
        builder.Property(r=>r.Name).IsRequired().HasMaxLength(50);
        builder.Property(r=>r.CreatedDate).IsRequired();


        builder.HasMany(r=>r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);
    }
}