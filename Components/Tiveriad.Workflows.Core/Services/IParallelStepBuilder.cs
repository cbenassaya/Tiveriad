#region

using Tiveriad.Workflows.Core.Primitives;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface IParallelStepBuilder<TData, TStepBody>
    where TStepBody : IStepBody
{
    IParallelStepBuilder<TData, TStepBody> Do(Action<IWorkflowBuilder<TData>> builder);
    IStepBuilder<TData, Sequence> Join();
}