using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.WebApi.DataAccess.Entities;

namespace Project.WebApi.DataAccess.Configuration
{
    public class KineticImpactResultConfiguration : IEntityTypeConfiguration<KineticImpactResult>
    {
        public void Configure(EntityTypeBuilder<KineticImpactResult> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);

            List<KineticImpactResult> items = new List<KineticImpactResult>()
            {
                new KineticImpactResult(0, "Will not cause any harm."),
                new KineticImpactResult(1000, "Will break the windows."),
                new KineticImpactResult(10000, "Will destroy small city."),
                new KineticImpactResult(1000000, "Will destroy a nation."),
                new KineticImpactResult(10000000, "Will destroy a whole word.")
            };

            builder.HasData(items);
        }
    }
}
