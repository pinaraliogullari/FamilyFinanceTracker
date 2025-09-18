using FinancialTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialTrack.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(sc => sc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(sc => sc.IsCustom)
            .IsRequired();

        builder.Property(sc => sc.CreatedDate)
            .IsRequired();

        builder.HasMany(c => c.FinancialRecords)
            .WithOne(fr => fr.Category)
            .HasForeignKey(fr => fr.CategoryId);
    }
}