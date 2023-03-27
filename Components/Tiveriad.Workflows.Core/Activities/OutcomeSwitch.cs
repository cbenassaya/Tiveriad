#region

using Tiveriad.Workflows.Core.Exceptions;
using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class OutcomeSwitch : ContainerStepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        if (context.PersistenceData == null)
        {
            var result = ExecutionResult.Branch(new List<object> { context.Item },
                new ControlPersistenceData { ChildrenActive = true });
            result.OutcomeValue = GetPreviousOutcome(context);
            return result;
        }

        if (context.PersistenceData is ControlPersistenceData &&
            (context.PersistenceData as ControlPersistenceData).ChildrenActive)
        {
            if (context.Workflow.IsBranchComplete(context.ExecutionPointer.Id))
            {
                return ExecutionResult.Next();
            }

            var result = ExecutionResult.Persist(context.PersistenceData);
            result.OutcomeValue = GetPreviousOutcome(context);
            return result;
        }

        throw new CorruptPersistenceDataException();
    }

    private object GetPreviousOutcome(IStepExecutionContext context)
    {
        var prevPointer = context.Workflow.ExecutionPointers.FindById(context.ExecutionPointer.PredecessorId);
        return prevPointer.Outcome;
    }
}