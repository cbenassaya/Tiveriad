#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Primitives;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.FluentBuilders;

public class ParallelStepBuilder<TData, TStepBody> : IParallelStepBuilder<TData, TStepBody>
    where TStepBody : IStepBody
{
    private readonly IStepBuilder<TData, Sequence> _referenceBuilder;
    private readonly IStepBuilder<TData, TStepBody> _stepBuilder;

    public ParallelStepBuilder(IWorkflowBuilder<TData> workflowBuilder, IStepBuilder<TData, TStepBody> stepBuilder,
        IStepBuilder<TData, Sequence> referenceBuilder)
    {
        WorkflowBuilder = workflowBuilder;
        Step = stepBuilder.Step;
        _stepBuilder = stepBuilder;
        _referenceBuilder = referenceBuilder;
    }

    public IWorkflowBuilder<TData> WorkflowBuilder { get; }

    public WorkflowStep<TStepBody> Step { get; set; }

    public IParallelStepBuilder<TData, TStepBody> Do(Action<IWorkflowBuilder<TData>> builder)
    {
        var lastStep = WorkflowBuilder.LastStep;
        builder.Invoke(WorkflowBuilder);

        if (lastStep == WorkflowBuilder.LastStep)
            throw new NotSupportedException("Empty Do block not supported");

        Step.Children.Add(lastStep + 1); //TODO: make more elegant

        return this;
    }

    public IStepBuilder<TData, Sequence> Join()
    {
        return _referenceBuilder;
    }
}