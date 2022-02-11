using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Project.WebApi.Swagger;

public class AddRequiredHeaderParameter : IOperationFilter
{
    private static readonly string UniqueIdentifierDevelopmentValue = "2836d188-d6e2-4eb8-ae1f-3eeebe8cff78";

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = Const.UniqueIdentifierKey,
            In = ParameterLocation.Header,
            Description = "Unique indentifier (GUID) to track calculation history.",
            Required = true,
            Schema = new OpenApiSchema { Type = "string", Default = new OpenApiString(UniqueIdentifierDevelopmentValue) }
        });
    }
}
