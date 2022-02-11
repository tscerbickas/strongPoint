using Microsoft.AspNetCore.Mvc;
using Project.WebApi.Models;
using Project.WebApi.Models.Common;
using Project.WebApi.Services;
using System.Net.Mime;

namespace Project.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class KineticEnergyCalculatorController : BaseController
    {
        private readonly ICalculationHistoryService _calculationHistoryService;
        private readonly IKineticImpactService _kineticImpactService;

        private readonly IKineticEnergyCalculator _calculator;

        private readonly ILogger<KineticEnergyCalculatorController> _logger;

        public KineticEnergyCalculatorController(IKineticEnergyCalculator calculator,
            ICalculationHistoryService calculationHistoryService,
            IKineticImpactService kineticImpactService,
            ILogger<KineticEnergyCalculatorController> logger)
        {
            _calculationHistoryService = calculationHistoryService;
            _kineticImpactService = kineticImpactService;

            _calculator = calculator;

            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(InvalidModelStateModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(KineticEnergyCalculatorViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> CalculateAsync([FromBody] KineticEnergyCalculatorModel request, CancellationToken ct)
        {
            (var mass, var velocity) = request;

            var kineticEnergy = _calculator.Calculate(mass, velocity);
            (var impactResultId, var impactDescription) = await _kineticImpactService.GetImpactResultAsync(kineticEnergy, ct);

            await _calculationHistoryService.AddAsync(mass, velocity, kineticEnergy, impactResultId, UniqueIdentifier, ct);

            var response = new KineticEnergyCalculatorViewModel(kineticEnergy, impactDescription);
            return Ok(response);
        }
    }
}
