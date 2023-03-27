#region

using Microsoft.Extensions.Logging;
using Tiveriad.Workflows.Core.Services;
using Tiveriad.Workflows.Services.DefaultProviders;

#endregion

namespace Tiveriad.Workflows;

public class WorkflowOptions : IWorkflowOptions
{
    private Func<IServiceResolver, ILifeCycleEventHub> _eventHubFactory;
    private Func<IServiceResolver, IDistributedLockProvider> _lockFactory;
    private Func<IServiceResolver, IQueueProvider> _queueFactory;
    private Func<IServiceResolver, ISearchIndex> _searchIndexFactory;

    public WorkflowOptions(IServiceResolver serviceResolver)
    {
        ServiceResolver = serviceResolver;
        PollInterval = TimeSpan.FromSeconds(10);
        IdleTime = TimeSpan.FromMilliseconds(100);
        ErrorRetryInterval = TimeSpan.FromSeconds(60);

        _queueFactory = sp => new SingleNodeQueueProvider();
        _lockFactory = sp => new SingleNodeLockProvider();
        PersistenceFactory = sp => new TransientMemoryPersistenceProvider(serviceResolver.GetService<ISingletonMemoryProvider>());
        _searchIndexFactory = sp => new NullSearchIndex();
        _eventHubFactory = sp => new SingleNodeEventHub(sp.GetService<ILoggerFactory>());
    }

    public IServiceResolver ServiceResolver { get; }

    public Func<IServiceResolver, IPersistenceProvider> PersistenceFactory { get; private set; }
    public IQueueProvider QueueProvider => _queueFactory(ServiceResolver);
    public IDistributedLockProvider DistributedLockProvider => _lockFactory(ServiceResolver);
    public ILifeCycleEventHub LifeCycleEventHub => _eventHubFactory(ServiceResolver);
    public ISearchIndex SearchIndex => _searchIndexFactory(ServiceResolver);
    public TimeSpan PollInterval { get; private set; }
    public TimeSpan IdleTime { get; private set; }
    public TimeSpan ErrorRetryInterval { get; private set; }
    public int MaxConcurrentWorkflows { get; private set; } = Math.Max(Environment.ProcessorCount, 4);

    public bool EnableWorkflows { get; set; } = true;
    public bool EnableEvents { get; set; } = true;
    public bool EnableIndexes { get; set; } = true;
    public bool EnablePolling { get; set; } = true;
    public bool EnableLifeCycleEventsPublisher { get; set; } = true;

    public void UsePersistence(Func<IServiceResolver, IPersistenceProvider> factory)
    {
        PersistenceFactory = factory;
    }

    public void UseDistributedLockManager(Func<IServiceResolver, IDistributedLockProvider> factory)
    {
        _lockFactory = factory;
    }

    public void UseQueueProvider(Func<IServiceResolver, IQueueProvider> factory)
    {
        _queueFactory = factory;
    }

    public void UseEventHub(Func<IServiceResolver, ILifeCycleEventHub> factory)
    {
        _eventHubFactory = factory;
    }

    public void UseSearchIndex(Func<IServiceResolver, ISearchIndex> factory)
    {
        _searchIndexFactory = factory;
    }

    public void UsePollInterval(TimeSpan interval)
    {
        PollInterval = interval;
    }

    public void UseErrorRetryInterval(TimeSpan interval)
    {
        ErrorRetryInterval = interval;
    }

    public void UseIdleTime(TimeSpan interval)
    {
        IdleTime = interval;
    }

    public void UseMaxConcurrentWorkflows(int maxConcurrentWorkflows)
    {
        MaxConcurrentWorkflows = maxConcurrentWorkflows;
    }
}