#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class SagaContainer<TStepBody> : WorkflowStep<TStepBody>
    where TStepBody : IStepBody
{
    public override bool ResumeChildrenAfterCompensation => false;
    public override bool RevertChildrenAfterCompensation => true;

    public override void PrimeForRetry(ExecutionPointer pointer)
    {
        base.PrimeForRetry(pointer);
        pointer.PersistenceData = null;
    }
}