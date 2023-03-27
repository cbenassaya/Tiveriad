#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class WaitFor : StepBody
{
    public string EventKey { get; set; }

    public string EventName { get; set; }

    public DateTime EffectiveDate { get; set; }

    public object EventData { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        if (!context.ExecutionPointer.EventPublished)
        {
            var effectiveDate = DateTime.MinValue;

            if (EffectiveDate != null) effectiveDate = EffectiveDate;

            return ExecutionResult.WaitForEvent(EventName, EventKey, effectiveDate);
        }

        EventData = context.ExecutionPointer.EventData;
        return ExecutionResult.Next();
    }
}