#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Tests.PassingData;

public class AddNumbers : StepBodyAsync
{
    public int Input1 { get; set; }

    public int Input2 { get; set; }

    public int Output { get; set; }


    public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
        Output = Input1 + Input2;
        return ExecutionResult.Next();
    }
}