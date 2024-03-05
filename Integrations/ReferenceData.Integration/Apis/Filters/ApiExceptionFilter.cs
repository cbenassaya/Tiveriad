#region

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReferenceData.Integration.Core.Exceptions;

#endregion

namespace ReferenceData.Integration.Apis.Filters;

public class ApiExceptionFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        var tiveriadIntegrationException = context.Exception as ReferenceDataException;
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