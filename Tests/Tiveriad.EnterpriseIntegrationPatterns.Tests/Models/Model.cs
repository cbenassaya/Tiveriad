#region

using Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;

public class Model
{
    public DateTime? DateTime { get; set; }
    public string Name { get; set; }
}

public class Middleware : IMiddleware<Context,Model,  Configuration>
{


    public Task Run(Context context, RequestDelegate<Context, Model, Configuration> next)
    {
        context.Model.DateTime = DateTime.Now;
        return next(context);
    }
}

public class MiddlewareWithException : IMiddleware< Context,Model,  Configuration>
{
    public Task Run(Context context, RequestDelegate<Context, Model, Configuration> next)
    {
        throw new NullReferenceException("TestError");
    }
}