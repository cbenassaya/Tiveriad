using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Tiveriad.Multitenancy.Core.Exceptions;

namespace Tiveriad.Multitenancy.Apis.Filters;

public class ApiExceptionFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        var multiTenancyException = context.Exception as MultiTenancyException;
        var logger =
            context.HttpContext.RequestServices.GetService(typeof(ILogger<ApiExceptionFilter>)) as
                ILogger<ApiExceptionFilter>;


        logger?.LogError(context.Exception.Message, context.Exception, context.HttpContext.Request);

        if (multiTenancyException != null)

            context.Result = new BadRequestObjectResult(multiTenancyException.Message);
        else
            context.Result = new ObjectResult(context.Exception.Message)
                { StatusCode = StatusCodes.Status500InternalServerError };

        return Task.CompletedTask;
    }
}