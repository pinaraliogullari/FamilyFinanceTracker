using FinancialTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialTrack.Persistence.Configurations;

public class FinancialRecordConfiguration:IEntityTypeConfiguration<FinancialRecord>
{
    public void Configure(EntityTypeBuilder<FinancialRecord> builder)
    {
        builder.Property(fr => fr.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(fr => fr.Description)
            .HasMaxLength(500);

        builder.Property(fr => fr.CreatedDate)
            .IsRequired(); 
    }
}