using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project.WebApi.Extensions;
using Project.WebApi.Models.Common;

namespace Project.WebApi.Filters;

public class ModelStateFilter : IActionFilter
{
    private readonly ILogger<ModelStateFilter> _logger;

    public ModelStateFilter(ILogger<ModelStateFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var props = GetInvalidProperties(context.ModelState);

            var errorModel = new InvalidModelStateModel(400, "Invalid model state", props);

            _logger.LogWarning("Request modelState is invalid:{modelState}", context.ModelState.ToJson());

            context.Result = new BadRequestObjectResult(errorModel);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }

    private List<InvalidPoperty> GetInvalidProperties(ModelStateDictionary modelState)
    {
        List<InvalidPoperty> invalidProperties = new();

        foreach (var item in modelState)
        {
            var property = item.Key;
            var errorMessages = item.Value?.Errors?.Select(c => c.ErrorMessage).Where(c => !string.IsNullOrWhiteSpace(c)).ToList();

            invalidProperties.Add(new InvalidPoperty(property, errorMessages));
        }
        return invalidProperties;
    }
}
