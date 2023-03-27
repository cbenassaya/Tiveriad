#region

using Tiveriad.Workflows.Core.Models;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface ISyncWorkflowRunner
{
    Task<WorkflowInstance> RunWorkflowSync<TData>(string workflowId, int version, TData data, string reference,
        TimeSpan timeOut, bool persistSate = true)
        where TData : new();

    Task<WorkflowInstance> RunWorkflowSync<TData>(string workflowId, int version, TData data, string reference,
        CancellationToken token, bool persistSate = true)
        where TData : new();
}