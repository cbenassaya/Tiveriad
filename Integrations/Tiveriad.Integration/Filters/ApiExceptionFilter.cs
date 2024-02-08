using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tiveriad.Integration.Core.Exceptions;

namespace Tiveriad.Integration.Filters;

public class ApiExceptionFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        var tiveriadIntegrationException = context.Exception as TiveriadIntegrationException;
        var logger =
            context.HttpContext.RequestServices.GetService(typeof(ILogger<ApiExceptionFilter>)) as
                ILogger<ApiExceptionFilter>;


        logger?.LogError(context.Exception.Message, context.Exception, context.HttpContext.Request);

        if (tiveriadIntegrationException != null)

            context.Result = new BadRequestObjectResult(tiveriadIntegrationException.Message);
        else
            context.Result = new ObjectResult(context.Exception.Message)
                { StatusCode = StatusCodes.Status400BadRequest };

        return Task.CompletedTask;
    }
}