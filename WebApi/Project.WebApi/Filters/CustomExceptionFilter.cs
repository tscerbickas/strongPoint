using Microsoft.AspNetCore.Mvc.Filters;
using Project.WebApi.Extensions;
using Project.WebApi.Models.Common;
using System.Net;
using System.Net.Mime;

namespace Project.WebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(IWebHostEnvironment env, ILogger<CustomExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = MediaTypeNames.Application.Json;


            _logger.LogError(context.Exception, "Unexpected exception occurred");

            if (context.Exception is UnauthorizedAccessException)
            {
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var errorMsg = "Missing unique indentifier in header";

                context.ExceptionHandled = true;

                response.WriteAsync(new ErrorModel(response.StatusCode, errorMsg).ToJson());
                return;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            var errorDetails = new ErrorModel(response.StatusCode, _commonErrorMessage);

            if (_env.IsDevelopment())
            {
                return;
            }

            context.ExceptionHandled = true;
            response.WriteAsync(errorDetails.ToJson());
        }

        private static readonly string _commonErrorMessage = "Bad Request";
    }
}
