using FinancialTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialTrack.Persistence.Configurations;

public class RoleConfiguration:IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(r=>r.Name).IsRequired().HasMaxLength(50);
        builder.Property(r=>r.CreatedDate).IsRequired();


        builder.HasMany(r=>r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);
    }
}