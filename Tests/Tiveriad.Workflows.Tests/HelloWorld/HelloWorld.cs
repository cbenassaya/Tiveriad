using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

namespace Tiveriad.Workflows.Tests.HelloWorld;

public class HelloWorld : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("Hello world");
        return ExecutionResult.Next();
    }
}