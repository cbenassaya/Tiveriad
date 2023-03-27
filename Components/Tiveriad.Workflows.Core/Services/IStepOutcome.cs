#region

using Tiveriad.Workflows.Core.Models;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface IStepOutcome
{
    string ExternalNextStepId { get; set; }
    string Label { get; set; }
    int NextStep { get; set; }

    bool Matches(object data);
    bool Matches(ExecutionResult executionResult, object data);
}