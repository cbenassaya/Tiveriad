#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Primitives;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface IWorkflowBuilder
{
    List<WorkflowStep> Steps { get; }

    int LastStep { get; }

    IWorkflowBuilder<T> UseData<T>();

    WorkflowDefinition Build(string id, int version);

    void AddStep(WorkflowStep step);

    void AttachBranch(IWorkflowBuilder branch);
}

public interface IWorkflowBuilder<TData> : IWorkflowBuilder, IWorkflowModifier<TData, InlineStepBody>
{
    IStepBuilder<TData, TStep> StartWith<TStep>(Action<IStepBuilder<TData, TStep>> stepSetup = null)
        where TStep : IStepBody;

    IStepBuilder<TData, InlineStepBody> StartWith(Func<IStepExecutionContext, ExecutionResult> body);

    IStepBuilder<TData, ActionStepBody> StartWith(Action<IStepExecutionContext> body);

    IEnumerable<WorkflowStep> GetUpstreamSteps(int id);

    IWorkflowBuilder<TData> UseDefaultErrorBehavior(WorkflowErrorHandling behavior, TimeSpan? retryInterval = null);

    IWorkflowBuilder<TData> CreateBranch();
}