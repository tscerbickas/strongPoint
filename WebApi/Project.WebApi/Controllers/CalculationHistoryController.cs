using Microsoft.AspNetCore.Mvc;
using Project.WebApi.Models;
using Project.WebApi.Models.Common;
using Project.WebApi.Services;
using System.Net.Mime;

namespace Project.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class CalculationHistoryController : BaseController
{
    private readonly ICalculationHistoryService _calculationHistoryService;

    public CalculationHistoryController(ICalculationHistoryService calculationHistoryService)
    {
        _calculationHistoryService = calculationHistoryService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(List<CalculationHistoryItemViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(CancellationToken ct)
    {
        const int itemCount = 10;

        var items = await _calculationHistoryService.GetAsync(UniqueIdentifier, itemCount, ct);
        return Ok(items);
    }
}
