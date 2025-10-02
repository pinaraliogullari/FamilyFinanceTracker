using FinancialTrack.Domain.Entities;
using FinancialTrack.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialTrack.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            
            new Category { Id = 1, Name = "Giyim", IsCustom = false, FinancialRecordType = FinancialRecordType.Expense },
            new Category { Id = 2, Name = "Yiyecek", IsCustom = false, FinancialRecordType = FinancialRecordType.Expense },
            new Category { Id = 3, Name = "Ulaşım", IsCustom = false, FinancialRecordType = FinancialRecordType.Expense },
            new Category { Id = 4, Name = "Sağlık", IsCustom = false, FinancialRecordType = FinancialRecordType.Expense },
            new Category { Id = 5, Name = "Eğlence", IsCustom = false, FinancialRecordType = FinancialRecordType.Expense },

            new Category { Id = 6, Name = "Maaş", IsCustom = false, FinancialRecordType = FinancialRecordType.Income },
            new Category { Id = 7, Name = "Freelance", IsCustom = false, FinancialRecordType = FinancialRecordType.Income },
            new Category { Id = 8, Name = "Yatırım", IsCustom = false, FinancialRecordType = FinancialRecordType.Income },
            new Category { Id = 9, Name = "Kira Geliri", IsCustom = false, FinancialRecordType = FinancialRecordType.Income },
            new Category { Id = 10, Name = "Diğer Gelir", IsCustom = false, FinancialRecordType = FinancialRecordType.Income }
        );
 
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