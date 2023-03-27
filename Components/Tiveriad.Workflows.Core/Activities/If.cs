#region

using Tiveriad.Workflows.Core.Exceptions;
using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class If : ContainerStepBody
{
    public bool Condition { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        if (context.PersistenceData == null)
        {
            if (Condition)
                return ExecutionResult.Branch(new List<object> { context.Item },
                    new ControlPersistenceData { ChildrenActive = true });

            return ExecutionResult.Next();
        }

        if (context.PersistenceData is ControlPersistenceData &&
            (context.PersistenceData as ControlPersistenceData).ChildrenActive)
        {
            if (context.Workflow.IsBranchComplete(context.ExecutionPointer.Id)) return ExecutionResult.Next();

            return ExecutionResult.Persist(context.PersistenceData);
        }

        throw new CorruptPersistenceDataException();
    }
}