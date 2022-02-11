using Microsoft.EntityFrameworkCore;
using Project.WebApi.DataAccess;
using Project.WebApi.DataAccess.Entities;

namespace Project.WebApi.Services;

public interface IKineticImpactService
{
    Task<KineticImpactResult> GetImpactResultAsync(double kineticEnergity, CancellationToken ct = default);
}

public class KineticImpactService : IKineticImpactService
{
    private readonly DatabaseContext _context;

    private readonly ILogger<KineticImpactService> _logger;

    public KineticImpactService(DatabaseContext context, ILogger<KineticImpactService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<KineticImpactResult> GetImpactResultAsync(double kineticEnergity, CancellationToken ct)
    {
        _logger.LogInformation("Retrieving KineticImpactResult by kineticEnergity:{energy}", kineticEnergity);

        return _context.KineticImpatResults
            .OrderByDescending(c => c.KineticEnergity)
            .FirstAsync(c => c.KineticEnergity < kineticEnergity);
    }
}
