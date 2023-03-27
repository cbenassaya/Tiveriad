#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.FluentBuilders;

public class ReturnStepBuilder<TData, TStepBody, TParentStep> : IContainerStepBuilder<TData, TStepBody, TParentStep>
    where TStepBody : IStepBody
    where TParentStep : IStepBody
{
    private readonly IStepBuilder<TData, TParentStep> _referenceBuilder;

    public ReturnStepBuilder(IWorkflowBuilder<TData> workflowBuilder, WorkflowStep<TStepBody> step,
        IStepBuilder<TData, TParentStep> referenceBuilder)
    {
        WorkflowBuilder = workflowBuilder;
        Step = step;
        _referenceBuilder = referenceBuilder;
    }

    public IWorkflowBuilder<TData> WorkflowBuilder { get; }

    public WorkflowStep<TStepBody> Step { get; set; }

    public IStepBuilder<TData, TParentStep> Do(Action<IWorkflowBuilder<TData>> builder)
    {
        builder.Invoke(WorkflowBuilder);
        Step.Children.Add(Step.Id + 1); //TODO: make more elegant

        return _referenceBuilder;
    }
}