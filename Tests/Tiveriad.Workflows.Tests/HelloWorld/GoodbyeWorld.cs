using Microsoft.Extensions.Logging;
using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

namespace Tiveriad.Workflows.Tests.HelloWorld;

public class GoodbyeWorld : StepBody
{

    private ILogger _logger;

    public GoodbyeWorld(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<GoodbyeWorld>();
    }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("Goodbye world");
        _logger.LogInformation("Hi there!");
        return ExecutionResult.Next();
    }
}