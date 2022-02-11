using Microsoft.EntityFrameworkCore;
using Project.WebApi.DataAccess.Configuration;
using Project.WebApi.DataAccess.Entities;

namespace Project.WebApi.DataAccess;

/// <summary>
/// Add-Migration Init -OutputDir "DataAccess/Migrations"
/// </summary>
public class DatabaseContext : DbContext
{
    public DbSet<CalculationHistory> CalculationHistory { get; set; }
    public DbSet<KineticImpactResult> KineticImpatResults { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CalculationHistoryConfiguration());
        builder.ApplyConfiguration(new KineticImpactResultConfiguration());
    }
}

