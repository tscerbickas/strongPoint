using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.WebApi.DataAccess.Entities;

namespace Project.WebApi.DataAccess.Configuration;

public class CalculationHistoryConfiguration : IEntityTypeConfiguration<CalculationHistory>
{
    public void Configure(EntityTypeBuilder<CalculationHistory> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.KineticEnergy).HasPrecision(18, 9);

        builder.HasOne(c => c.ImpactResult);
    }
}

