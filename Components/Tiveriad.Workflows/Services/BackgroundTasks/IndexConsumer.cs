#region

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.BackgroundTasks;

public class IndexConsumer : QueueConsumer, IBackgroundTask
{
    private readonly Dictionary<string, int> _errorCounts = new();
    private readonly ILogger _logger;
    private readonly ObjectPool<IPersistenceProvider> _persistenceStorePool;
    private readonly ISearchIndex _searchIndex;

    public IndexConsumer(IPooledObjectPolicy<IPersistenceProvider> persistencePoolPolicy, IQueueProvider queueProvider,
        ILoggerFactory loggerFactory, ISearchIndex searchIndex, IWorkflowOptions options)
        : base(queueProvider, loggerFactory, options)
    {
        _persistenceStorePool = new DefaultObjectPool<IPersistenceProvider>(persistencePoolPolicy);
        _searchIndex = searchIndex;
        _logger = loggerFactory.CreateLogger(GetType());
    }

    protected override QueueType Queue => QueueType.Index;
    protected override bool EnableSecondPasses => true;

    protected override async Task ProcessItem(string itemId, CancellationToken cancellationToken)
    {
        try
        {
            var workflow = await FetchWorkflow(itemId);

            WorkflowActivity.Enrich(workflow, "index");
            await _searchIndex.IndexWorkflow(workflow);
            lock (_errorCounts)
            {
                _errorCounts.Remove(itemId);
            }
        }
        catch (Exception e)
        {
            Logger.LogWarning(default(EventId), $"Error indexing workfow - {itemId} - {e.Message}");
            var errCount = 0;
            lock (_errorCounts)
            {
                if (!_errorCounts.ContainsKey(itemId))
                    _errorCounts.Add(itemId, 0);

                _errorCounts[itemId]++;
                errCount = _errorCounts[itemId];
            }

            if (errCount < 5)
            {
                await QueueProvider.QueueWork(itemId, Queue);
                return;
            }

            if (errCount < 20)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                await QueueProvider.QueueWork(itemId, Queue);
                return;
            }

            lock (_errorCounts)
            {
                _errorCounts.Remove(itemId);
            }

            Logger.LogError(default, e, $"Unable to index workfow - {itemId} - {e.Message}");
        }
    }

    private async Task<WorkflowInstance> FetchWorkflow(string id)
    {
        var store = _persistenceStorePool.Get();
        try
        {
            return await store.GetWorkflowInstance(id);
        }
        finally
        {
            _persistenceStorePool.Return(store);
        }
    }
}