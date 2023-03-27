#region

using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Tiveriad.Workflows.Core.Models.LifeCycleEvents;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services;

public class LifeCycleEventPublisher : ILifeCycleEventPublisher, IDisposable
{
    private readonly ILifeCycleEventHub _eventHub;
    private readonly ILogger _logger;
    private readonly IWorkflowOptions _workflowOptions;
    private Task _dispatchTask;
    private BlockingCollection<LifeCycleEvent> _outbox;

    public LifeCycleEventPublisher(ILifeCycleEventHub eventHub, IWorkflowOptions workflowOptions,
        ILoggerFactory loggerFactory)
    {
        _eventHub = eventHub;
        _workflowOptions = workflowOptions;
        _outbox = new BlockingCollection<LifeCycleEvent>();
        _logger = loggerFactory.CreateLogger(GetType());
    }

    public void Dispose()
    {
        _outbox.Dispose();
    }

    public void PublishNotification(LifeCycleEvent evt)
    {
        if (_outbox.IsAddingCompleted || !_workflowOptions.EnableLifeCycleEventsPublisher)
            return;

        _outbox.Add(evt);
    }

    public void Start()
    {
        if (_dispatchTask != null) throw new InvalidOperationException();

        if (_outbox.IsAddingCompleted) _outbox = new BlockingCollection<LifeCycleEvent>();

        _dispatchTask = new Task(Execute);
        _dispatchTask.Start();
    }

    public void Stop()
    {
        _outbox.CompleteAdding();
        _dispatchTask.Wait();
        _dispatchTask = null;
    }

    private async void Execute()
    {
        foreach (var evt in _outbox.GetConsumingEnumerable())
            try
            {
                await _eventHub.PublishNotification(evt);
            }
            catch (Exception ex)
            {
                _logger.LogError(default, ex, ex.Message);
            }
    }
}