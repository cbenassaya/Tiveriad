#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.DefaultProviders;

public class TransientMemoryPersistenceProvider : IPersistenceProvider
{
    private readonly ISingletonMemoryProvider _innerService;

    public TransientMemoryPersistenceProvider(ISingletonMemoryProvider innerService)
    {
        _innerService = innerService;
    }

    public bool SupportsScheduledCommands => false;

    public Task<string> CreateEvent(Event newEvent, CancellationToken _ = default)
    {
        return _innerService.CreateEvent(newEvent);
    }

    public Task<string> CreateEventSubscription(EventSubscription subscription, CancellationToken _ = default)
    {
        return _innerService.CreateEventSubscription(subscription);
    }

    public Task<string> CreateNewWorkflow(WorkflowInstance workflow, CancellationToken _ = default)
    {
        return _innerService.CreateNewWorkflow(workflow);
    }

    public void EnsureStoreExists()
    {
        _innerService.EnsureStoreExists();
    }

    public Task<Event> GetEvent(string id, CancellationToken _ = default)
    {
        return _innerService.GetEvent(id);
    }

    public Task<IEnumerable<string>> GetEvents(string eventName, string eventKey, DateTime asOf,
        CancellationToken _ = default)
    {
        return _innerService.GetEvents(eventName, eventKey, asOf);
    }

    public Task<IEnumerable<string>> GetRunnableEvents(DateTime asAt, CancellationToken _ = default)
    {
        return _innerService.GetRunnableEvents(asAt);
    }

    public Task<IEnumerable<string>> GetRunnableInstances(DateTime asAt, CancellationToken _ = default)
    {
        return _innerService.GetRunnableInstances(asAt);
    }

    public Task<IEnumerable<EventSubscription>> GetSubscriptions(string eventName, string eventKey, DateTime asOf,
        CancellationToken _ = default)
    {
        return _innerService.GetSubscriptions(eventName, eventKey, asOf);
    }

    public Task<WorkflowInstance> GetWorkflowInstance(string Id, CancellationToken _ = default)
    {
        return _innerService.GetWorkflowInstance(Id);
    }

    public Task<IEnumerable<WorkflowInstance>> GetWorkflowInstances(IEnumerable<string> ids,
        CancellationToken _ = default)
    {
        return _innerService.GetWorkflowInstances(ids);
    }

    public Task<IEnumerable<WorkflowInstance>> GetWorkflowInstances(WorkflowStatus? status, string type,
        DateTime? createdFrom, DateTime? createdTo, int skip, int take)
    {
        return _innerService.GetWorkflowInstances(status, type, createdFrom, createdTo, skip, take);
    }

    public Task MarkEventProcessed(string id, CancellationToken _ = default)
    {
        return _innerService.MarkEventProcessed(id);
    }

    public Task MarkEventUnprocessed(string id, CancellationToken _ = default)
    {
        return _innerService.MarkEventUnprocessed(id);
    }

    public Task PersistErrors(IEnumerable<ExecutionError> errors, CancellationToken _ = default)
    {
        return _innerService.PersistErrors(errors);
    }

    public Task PersistWorkflow(WorkflowInstance workflow, CancellationToken _ = default)
    {
        return _innerService.PersistWorkflow(workflow);
    }

    public async Task PersistWorkflow(WorkflowInstance workflow, List<EventSubscription> subscriptions,
        CancellationToken cancellationToken = default)
    {
        await PersistWorkflow(workflow, cancellationToken);

        foreach (var subscription in subscriptions) await CreateEventSubscription(subscription, cancellationToken);
    }

    public Task TerminateSubscription(string eventSubscriptionId, CancellationToken _ = default)
    {
        return _innerService.TerminateSubscription(eventSubscriptionId);
    }

    public Task<EventSubscription> GetSubscription(string eventSubscriptionId, CancellationToken _ = default)
    {
        return _innerService.GetSubscription(eventSubscriptionId);
    }

    public Task<EventSubscription> GetFirstOpenSubscription(string eventName, string eventKey, DateTime asOf,
        CancellationToken _ = default)
    {
        return _innerService.GetFirstOpenSubscription(eventName, eventKey, asOf);
    }

    public Task<bool> SetSubscriptionToken(string eventSubscriptionId, string token, string workerId, DateTime expiry,
        CancellationToken _ = default)
    {
        return _innerService.SetSubscriptionToken(eventSubscriptionId, token, workerId, expiry);
    }

    public Task ClearSubscriptionToken(string eventSubscriptionId, string token, CancellationToken _ = default)
    {
        return _innerService.ClearSubscriptionToken(eventSubscriptionId, token);
    }

    public Task ScheduleCommand(ScheduledCommand command)
    {
        throw new NotImplementedException();
    }

    public Task ProcessCommands(DateTimeOffset asOf, Func<ScheduledCommand, Task> action,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}