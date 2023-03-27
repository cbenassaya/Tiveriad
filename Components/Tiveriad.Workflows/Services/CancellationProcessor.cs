#region

using Microsoft.Extensions.Logging;
using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services;

public class CancellationProcessor : ICancellationProcessor
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IExecutionResultProcessor _executionResultProcessor;
    protected readonly ILogger _logger;

    public CancellationProcessor(IExecutionResultProcessor executionResultProcessor, ILoggerFactory logFactory,
        IDateTimeProvider dateTimeProvider)
    {
        _executionResultProcessor = executionResultProcessor;
        _logger = logFactory.CreateLogger<CancellationProcessor>();
        _dateTimeProvider = dateTimeProvider;
    }

    public void ProcessCancellations(WorkflowInstance workflow, WorkflowDefinition workflowDef,
        WorkflowExecutorResult executionResult)
    {
        foreach (var step in workflowDef.Steps.Where(x => x.CancelCondition != null))
        {
            var func = step.CancelCondition.Compile();
            var cancel = false;
            try
            {
                cancel = (bool)func.DynamicInvoke(workflow.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(default, ex, ex.Message);
            }

            if (cancel)
            {
                var toCancel = workflow.ExecutionPointers.Where(x =>
                        x.StepId == step.Id && x.Status != PointerStatus.Complete &&
                        x.Status != PointerStatus.Cancelled)
                    .ToList();

                foreach (var ptr in toCancel)
                {
                    if (step.ProceedOnCancel)
                        _executionResultProcessor.ProcessExecutionResult(workflow, workflowDef, ptr, step,
                            ExecutionResult.Next(), executionResult);

                    ptr.EndTime = _dateTimeProvider.UtcNow;
                    ptr.Active = false;
                    ptr.Status = PointerStatus.Cancelled;

                    foreach (var descendent in workflow.ExecutionPointers.FindByScope(ptr.Id).Where(x =>
                                 x.Status != PointerStatus.Complete && x.Status != PointerStatus.Cancelled))
                    {
                        descendent.EndTime = _dateTimeProvider.UtcNow;
                        descendent.Active = false;
                        descendent.Status = PointerStatus.Cancelled;
                    }
                }
            }
        }
    }
}