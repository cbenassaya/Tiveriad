#region

using Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;

public class Model
{
    public DateTime? DateTime { get; set; }
}

public class Middleware : IMiddleware<Model, Context, Configuration>
{
    public Task Run(Context context, Model model)
    {
        model.DateTime = DateTime.Now;
        return Task.CompletedTask;
    }
}

public class MiddlewareWithException : IMiddleware<Model, Context, Configuration>
{
    public Task Run(Context context, Model model)
    {
        throw new NullReferenceException("TestError");
    }
}