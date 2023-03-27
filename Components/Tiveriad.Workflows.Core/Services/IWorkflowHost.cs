#region

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Models.LifeCycleEvents;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface IWorkflowHost : IWorkflowController, IActivityController, IHostedService
{
    //public dependencies to allow for extension method access
    IPersistenceProvider PersistenceStore { get; }
    IDistributedLockProvider LockProvider { get; }
    IWorkflowRegistry Registry { get; }
    IWorkflowOptions Options { get; }
    IQueueProvider QueueProvider { get; }
    ILogger Logger { get; }

    /// <summary>
    ///     Start the workflow host, this enable execution of workflows
    /// </summary>
    void Start();

    /// <summary>
    ///     Stop the workflow host
    /// </summary>
    void Stop();


    event StepErrorEventHandler OnStepError;
    event LifeCycleEventHandler OnLifeCycleEvent;
    void ReportStepError(WorkflowInstance workflow, WorkflowStep step, Exception exception);
}

public delegate void StepErrorEventHandler(WorkflowInstance workflow, WorkflowStep step, Exception exception);

public delegate void LifeCycleEventHandler(LifeCycleEvent evt);