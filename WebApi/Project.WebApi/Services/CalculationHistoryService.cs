using Microsoft.EntityFrameworkCore;
using Project.WebApi.DataAccess;
using Project.WebApi.DataAccess.Entities;
using Project.WebApi.Models;

namespace Project.WebApi.Services
{
    public interface ICalculationHistoryService
    {
        Task<List<CalculationHistoryItemViewModel>> GetAsync(Guid uniqueIdentifier, int itemCount, CancellationToken ct);
        Task AddAsync(double mass, double velocity, double kineticEnergy, Guid impactResultId, Guid uniqueIdentifier, CancellationToken ct = default);
    }

    public class CalculationHistoryService : ICalculationHistoryService
    {
        private readonly DatabaseContext _context;

        private readonly ILogger<CalculationHistoryService> _logger;

        public CalculationHistoryService(DatabaseContext context, ILogger<CalculationHistoryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(double mass, double velocity, double kineticEnergy, Guid impactResultId, Guid uniqueIdentifier, CancellationToken ct)
        {
            _logger.LogInformation("Creating new history entry - mass:{mass}, velocity:{velocity}, impactresultId:{impactId}, uniqueIdentifier:{uid}", mass, velocity, impactResultId, uniqueIdentifier);

            var calculationHistory = new CalculationHistory(velocity, mass, kineticEnergy, impactResultId, uniqueIdentifier);

            await _context.CalculationHistory.AddAsync(calculationHistory);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<List<CalculationHistoryItemViewModel>> GetAsync(Guid uniqueIdentifier, int itemCount, CancellationToken ct)
        {
            _logger.LogInformation("Retrieving lastest {itemCount} items from CalculationHistory by uniqueIndentifier:{uid}", itemCount, uniqueIdentifier);

            return await _context.CalculationHistory
                .TagWith(nameof(GetAsync))
                .Where(c => c.UniqueIdentifier == uniqueIdentifier)
                .OrderByDescending(c => c.ModifiedDate)
                .Take(itemCount)
                .AsNoTracking()
                .Select(c => new CalculationHistoryItemViewModel
                {
                    Id = c.Id,
                    KineticEnergy = c.KineticEnergy,
                    Velocity = c.Velicoty,
                    Mass = c.Mass,
                    Description = c.ImpactResult.Description,
                })
                .ToListAsync(ct);
        }
    }
}
