using Tiveriad.ServiceResolvers;

namespace Tiveriad.Workflows.Core.Services;

public interface IWorkflowOptions
{
    public Func<IServiceResolver, IPersistenceProvider> PersistenceFactory { get; }
    public IQueueProvider QueueProvider { get; }
    public IDistributedLockProvider DistributedLockProvider { get; }
    public ILifeCycleEventHub LifeCycleEventHub { get; }
    public ISearchIndex SearchIndex { get; }
    TimeSpan PollInterval { get; }
    TimeSpan IdleTime { get; }
    TimeSpan ErrorRetryInterval { get; }
    int MaxConcurrentWorkflows { get; }
    bool EnableWorkflows { get; set; }
    bool EnableEvents { get; set; }
    bool EnableIndexes { get; set; }
    bool EnablePolling { get; set; }
    bool EnableLifeCycleEventsPublisher { get; set; }
    void UsePersistence(Func<IServiceResolver, IPersistenceProvider> factory);
    void UseDistributedLockManager(Func<IServiceResolver, IDistributedLockProvider> factory);
    void UseQueueProvider(Func<IServiceResolver, IQueueProvider> factory);
    void UseEventHub(Func<IServiceResolver, ILifeCycleEventHub> factory);
    void UseSearchIndex(Func<IServiceResolver, ISearchIndex> factory);
    void UsePollInterval(TimeSpan interval);
    void UseErrorRetryInterval(TimeSpan interval);
    void UseIdleTime(TimeSpan interval);
    void UseMaxConcurrentWorkflows(int maxConcurrentWorkflows);
}